using Microsoft.Extensions.Logging;

namespace CompanyName.MyProjectName.Patients.Infrastructure.Jobs;

public class TimerService : ITimerService
{
    private readonly ILogger<TimerService> logger;

    public TimerService(ILogger<TimerService> logger)
    {
        this.logger = logger;
    }

    public void PrintNow()
    {
        logger.LogInformation($"Job Started: {nameof(TimerService)}, started at {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}.");
    }
}