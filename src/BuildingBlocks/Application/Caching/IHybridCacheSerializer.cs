namespace CompanyName.MyProjectName.BuildingBlocks.Application.Caching;

public interface IHybridCacheSerializer
{
    byte[] Serialize<T>(T value);
    T? Deserialize<T>(byte[] bytes);
}
