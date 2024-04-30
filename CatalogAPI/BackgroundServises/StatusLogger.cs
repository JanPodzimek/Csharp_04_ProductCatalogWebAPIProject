using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StatusService;

public class StatusLogger : BackgroundService
{
    private readonly ILogger<StatusLogger> _logger;
    private TimeSpan _timeout = TimeSpan.FromSeconds(60);
    private HttpClient _httpClient;

    public StatusLogger(ILogger<StatusLogger> logger)
    {
        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _httpClient = new HttpClient();
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _httpClient.Dispose();
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                var result = await _httpClient.GetAsync("https://localhost:7046/swagger/index.html");

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("The application is running. Status code: {StatusCode}", result.StatusCode);
                }
                else
                {
                    _logger.LogError("The application is down. Status code: {StatusCode}", result.StatusCode);
                }
            }
            await Task.Delay(10000, stoppingToken);
        }
    }
}
