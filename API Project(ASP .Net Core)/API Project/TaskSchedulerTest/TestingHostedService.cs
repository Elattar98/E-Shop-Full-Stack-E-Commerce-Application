namespace API_Project.TaskSchedulerTest
{
    public class TestingHostedService : IHostedService
    {
        private readonly ILogger<TestingHostedService> _logger;
        public TestingHostedService(ILogger<TestingHostedService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Task Has Started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Task Has Stopped");
            return Task.CompletedTask;
        }
    }
}
