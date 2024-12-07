namespace API_Project.TaskSchedulerTest
{
    public class TestingBackgroundService : BackgroundService
    {
        private readonly ILogger<TestingBackgroundService> _logger;

        public TestingBackgroundService(ILogger<TestingBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background service has stared");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Background service is working");
                await Task.Delay(10000);
            }

            _logger.LogInformation("Background service has ended");

        }
    }
}
