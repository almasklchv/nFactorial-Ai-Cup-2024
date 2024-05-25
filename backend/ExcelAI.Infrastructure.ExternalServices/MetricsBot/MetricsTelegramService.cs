using ExcelAI.Infrastructure.ExternalServices.MetricsBot.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace ExcelAI.Infrastructure.ExternalServices.MetricsBot
{
    public class MetricsTelegramService : IMetricsBot
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<MetricsTelegramService> logger;

        public MetricsTelegramService(IConfiguration configuration,
                              ILogger<MetricsTelegramService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }


        public async Task SendMetric(MetricData data)
        {
            var endpoint = configuration["Metrics:EndpointURL"] ??
                throw new Exception("Configuration for METRICS not found");

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.PostAsJsonAsync(endpoint, new
                {
                    request_type = data.RequestType.ToString(),
                    images_count = data.ImagesCount,
                    images_weight_KB = data.ImagesWeightKB,
                    tokens_spent = data.TokensSpent
                });
            }
            catch (Exception ex)
            {
                logger.LogError($"Error sending metric: {ex.Message}");
            }
        }
    }
}
