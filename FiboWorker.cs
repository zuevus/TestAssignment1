using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Xml;
using TestAssignment1.Service;

namespace TestAssignment1
{
    public class FiboWorker(
            IServiceScopeFactory serviceScopeFactory,
            ILogger<FiboWorker> logger) : BackgroundService
    {

        private const string ClassName = nameof(FiboWorker);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("{Name} is running.", ClassName);

            await DoWorkAsync(stoppingToken);
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(
                "{Name} is working.", ClassName);

            using (IServiceScope scope = serviceScopeFactory.CreateScope())
            {
                IFiboService fiboService =
                    scope.ServiceProvider.GetRequiredService<IFiboService>();

                var result = await fiboService.GetFiboAsync(stoppingToken, 100);
                if (result != null) logger.LogInformation(
                        "{Name} returned: {result} .", ClassName, result);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(
                "{Name} is stopping.", ClassName);

            await base.StopAsync(stoppingToken);
        }
    }
}
