using ExcelAI.Infrastructure.ExternalServices.MetricsBot.Data;

namespace ExcelAI.Infrastructure.ExternalServices.MetricsBot
{
    public interface IMetricsBot
    {
        public Task SendMetric(MetricData data);
    }
}
