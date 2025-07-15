using CompanyName.MyProjectName.BuildingBlocks.Application.Clock;

namespace CompanyName.MyProjectName.BuildingBlocks.Infrastructure.Clock;

public sealed class UtcClock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}