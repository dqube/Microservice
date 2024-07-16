using CompanyName.MyProjectName.BuildingBlocks.Jobs;
using Hangfire;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CompanyName.MyProjectName.Patients.Infrastructure.Jobs;

[DisableConcurrentExecution(timeoutInSeconds: 300)]
[LogJobs]
internal class TimerService : ITimerService
{
    private readonly ILogger<TimerService> logger;

    public Settings Settings { get; }

    public TimerService(IOptionsSnapshot<Settings> options, ILogger<TimerService> logger)
    {
        Settings = options.Value;
        this.logger = logger;
    }

    [DisableConcurrentExecution(timeoutInSeconds: 300)]
    public async Task PrintNow()
    {
        logger.LogInformation($"Job Started: {nameof(TimerService)}, started at {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}.");
        await Task.CompletedTask;
    }
}