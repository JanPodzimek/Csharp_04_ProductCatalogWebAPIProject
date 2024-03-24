using CatalogAPI.API;
using CatalogAPI.XMLFeed;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Services;
public class ProductImport : BackgroundService
{
    private readonly ILogger<ProductImport> _logger;
    private TimeSpan _timeout = TimeSpan.FromSeconds(5);
    public XMLProductParser _xMLProductParser = new XMLProductParser();

    public ProductImport(ILogger<ProductImport> logger)
    {
        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        ApiHelper.InitializeClient();
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var feed = _xMLProductParser.ParseXml();

            if (feed != null)
            {
                foreach (var feedItem in feed)
                {
                    ProductPutModel? productPutModel = feedItem;
                    
                    
                    
                }
                    
                //_logger.LogInformation($"Products were successfully updated at {DateTime.Now}");
            }
            else
            {
                _logger.LogError("An error occurred while processing XML data.");
            }

            await Task.Delay(_timeout, stoppingToken);
        }
    }
}
