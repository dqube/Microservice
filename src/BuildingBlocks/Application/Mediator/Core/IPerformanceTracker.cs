namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

// Dummy IPerformanceTracker interface for demonstration
public interface IPerformanceTracker
{
    void StartTracking(string name);
    void StopTracking(string name);
}
