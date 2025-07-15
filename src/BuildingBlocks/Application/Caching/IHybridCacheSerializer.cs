namespace CompanyName.MyProjectName.BuildingBlocks.Application.Caching;
#nullable enable
public interface IHybridCacheSerializer
{
    byte[] Serialize<T>(T value);
    T? Deserialize<T>(byte[] bytes);
}
#nullable disable
