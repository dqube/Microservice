namespace CompanyName.MyProjectName.BuildingBlocks.Storage;

public interface IHybridCacheSerializer
{
    byte[] Serialize<T>(T value);

    T Deserialize<T>(byte[] bytes);
}
