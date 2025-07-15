using Microsoft.Extensions.Configuration;

namespace CompanyName.MyProjectName.BuildingBlocks.Storage;

public sealed class HybridCacheOptions
{
    public string RedisConfiguration { get; set; }

    public int RedisDatabase { get; set; }

    public IHybridCacheSerializer Serializer { get; set; }

    public TimeSpan DefaultMemoryExpiration { get; set; } = TimeSpan.FromMinutes(15);

    public TimeSpan DefaultDistributedExpiration { get; set; } = TimeSpan.FromHours(1);
}
