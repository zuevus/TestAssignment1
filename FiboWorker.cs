using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Text.RegularExpressions;
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
            while (!stoppingToken.IsCancellationRequested)
            {
                int lposition = 0;
                Console.Write("Input number: ");
                while (true)
                {
                    string str = Console.ReadLine();
                    if (!String.IsNullOrEmpty(str) && Regex.IsMatch(str, @"([0-9]{1,3}$)"))
                    {
                        lposition = Int32.Parse(str);
                        break;
                    }
                    Console.WriteLine($"Incorrect input {str}. Please, try again.");
                }
                using (IServiceScope scope = serviceScopeFactory.CreateScope())
                {
                    IFiboService fiboService =
                        scope.ServiceProvider.GetRequiredService<IFiboService>();

                    var result = await fiboService.GetFiboAsync(stoppingToken, lposition);
                    if (result != null) logger.LogInformation(
                            "{Name} returned: {result} .", ClassName, result);
                }
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
