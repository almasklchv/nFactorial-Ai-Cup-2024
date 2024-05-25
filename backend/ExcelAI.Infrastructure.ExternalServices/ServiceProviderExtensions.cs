using ExcelAI.Infrastructure.ExternalServices.MetricsBot;
using ExcelAI.Infrastructure.ExternalServices.OpenAI;
using ExcelAI.Infrastructure.ExternalServices.OpenAI.API;
using ExcelAI.Infrastructure.ExternalServices.OpenAI.Configuration;
using ExcelAI.Infrastructure.ExternalServices.OpenAI.MessageBuilders;
using ExcelAI.Infrastructure.ExternalServices.OpenAI.QueryConfigurations;
using ExcelAI.Infrastructure.ExternalServices.PrometheusMetrics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace ExcelAI.Infrastructure.ExternalServices
{
    public static class ServiceProviderExtensions
    {
        public static void AddOpenAIService(this IServiceCollection services)
        {
            services.AddTransient<IOpenAIService, OpenAIService>();
            services.AddTransient<IOpenAIAPI, OpenAIAPI>();
            services.AddTransient<IPromtsConfiguration, PromtsConfiguration>();
            services.AddTransient<IMessageBuilder, MessageBuilder>();
            services.AddTransient<IQueryConfiguration, DefaultQueryConfiguration>();
        }

        public static void AddMetricsService(this IServiceCollection services)
        {
            services.AddTransient<MetricsTelegramService>();

            services.AddSingleton<MetricsCollector>();
            services.AddHostedService<PrometheusMetricServer>();
        }
    }
}
