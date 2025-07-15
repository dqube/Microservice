namespace CompanyName.MyProjectName.BuildingBlocks.Storage;

public interface IHybridCache : IDisposable, IAsyncDisposable
{
    ValueTask<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, ValueTask<T>> factory,
        CacheOptions options = null,
        CancellationToken token = default);

#nullable enable
    ValueTask<T?> GetAsync<T>(string key, CancellationToken token = default);
#nullable disable

    ValueTask SetAsync<T>(string key, T value, CacheOptions options = null, CancellationToken token = default);

    ValueTask RemoveAsync(string key, CancellationToken token = default);

    ValueTask RefreshAsync(string key, CancellationToken token = default);

    ValueTask<bool> ExistsAsync(string key, CancellationToken token = default);

    ValueTask<CacheStats> GetStatsAsync(CancellationToken token = default);

    ValueTask ClearRegionAsync(string regionPrefix, CancellationToken token = default);
}
