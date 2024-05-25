using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Prometheus;


public class PrometheusMetricServer : IHostedService
{
    private readonly ILogger<PrometheusMetricServer> logger;

    private readonly IMetricServer metricServer
        = new MetricServer(5000);

    public PrometheusMetricServer(ILogger<PrometheusMetricServer> logger)
    {
        this.logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            this.metricServer.Start();
        }
        catch(Exception ex)
        {
            this.logger.LogError(ex.Message);
        }
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        try
        {
            this.metricServer.Stop();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex.Message);
        }
        return Task.CompletedTask;
    }
}
