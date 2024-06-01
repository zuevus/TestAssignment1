namespace TestAssignment1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly  _fibo;

        public Worker(ILogger<Worker> logger, )
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
                var inputString = Console.ReadLine();
                if (inputString != null) { _logger.LogInformation(inputString); }
            }
        }
    }
}
