using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccess.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StatusService;

namespace Services;
public class ProductImport : BackgroundService
{
    private readonly ILogger<ProductImport> _logger;
    private HttpClient _httpClient;
    private TimeSpan _timeout = TimeSpan.FromSeconds(10);

    public ProductImport(ILogger<ProductImport> logger)
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
            try
            {
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing XML data.");
            }

            await Task.Delay(_timeout, stoppingToken);
        }
    }
}
