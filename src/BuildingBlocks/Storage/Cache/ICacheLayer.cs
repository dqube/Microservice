namespace CompanyName.MyProjectName.BuildingBlocks.Storage;

public interface ICacheLayer : IDisposable, IAsyncDisposable
{
    string Name { get; }

    int Order { get; }

    bool IsAvailable { get; }

#nullable enable
    ValueTask<T?> GetAsync<T>(string key, CancellationToken token = default);
#nullable restore

    ValueTask SetAsync<T>(string key, T value, CacheOptions options = null, CancellationToken token = default);

    ValueTask RemoveAsync(string key, CancellationToken token = default);

    ValueTask<bool> ExistsAsync(string key, CancellationToken token = default);

    ValueTask ClearRegionAsync(string regionPrefix, CancellationToken token = default);
}
