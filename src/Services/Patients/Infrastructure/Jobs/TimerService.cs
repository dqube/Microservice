using Hangfire;
using Microsoft.Extensions.Logging;

namespace CompanyName.MyProjectName.Patients.Infrastructure.Jobs;

[DisableConcurrentExecution(timeoutInSeconds: 300)]
internal class TimerService : ITimerService
{
    private readonly ILogger<TimerService> logger;

    public TimerService(ILogger<TimerService> logger)
    {
        this.logger = logger;
    }

    public async Task PrintNow()
    {
        logger.LogInformation($"Job Started: {nameof(TimerService)}, started at {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}.");
        await Task.CompletedTask;
    }
}