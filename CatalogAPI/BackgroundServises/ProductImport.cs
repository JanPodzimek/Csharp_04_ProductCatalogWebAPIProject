using CatalogAPI.API;
using CatalogAPI.XMLFeed;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Services;
public class ProductImport : BackgroundService
{
    private readonly ILogger<ProductImport> _logger;
    private TimeSpan _timeout = TimeSpan.FromSeconds(10);
    private XMLProductParser _xMLProductParser = new XMLProductParser();
    private IProductData _productRepository;

    public ProductImport(ILogger<ProductImport> logger, IProductData productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
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

            try
            {
                foreach (var feedItem in feed)
                {
                    var product = await _productRepository.GetProductByEanAsync(feedItem.Ean);
                    if (product != null)
                    {
                        product.Description = feedItem.Description;
                        product.Price = feedItem.Price;
                        product.Quantity = feedItem.Quantity;
                        product.PriceUpdated = feedItem.PriceUpdated;

                        await _productRepository.PutProduct(product);
                        _logger.LogInformation($"Product with EAN {product?.Ean?.ToString()} was updated.");
                    }
                    else
                    {
                        _logger.LogInformation($"Product with EAN {feedItem?.Ean?.ToString()} was not found");
                    }
                }

                _logger.LogInformation($"All products were successfully updated at {DateTime.Now.ToString()}");
            } 
            catch
            {
                _logger.LogError($"An unexpeted error occured during processing the XML file.");
                throw new Exception();
            }

            

            

            await Task.Delay(_timeout, stoppingToken);
        }
    }
}
