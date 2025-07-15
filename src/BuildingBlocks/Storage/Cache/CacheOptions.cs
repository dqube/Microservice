namespace CompanyName.MyProjectName.BuildingBlocks.Storage;

public sealed record CacheOptions
{
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; init; }

    public TimeSpan? SlidingExpiration { get; init; }

    public string Region { get; init; }
}
