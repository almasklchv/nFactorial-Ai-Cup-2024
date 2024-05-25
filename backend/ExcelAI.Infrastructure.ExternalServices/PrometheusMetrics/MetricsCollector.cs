using Prometheus;

namespace ExcelAI.Infrastructure.ExternalServices.PrometheusMetrics
{
    public class MetricsCollector
    {
        public Counter EndpointRequestCounter { get; set; } = Metrics.CreateCounter(
            name: "endpoint_requests_total",
            help: "Total number of requests to a specific endpoint",
            configuration: new CounterConfiguration()
            {
                LabelNames = new[]
                    {
                        "endpoint"
                    }
            });

    }
}
