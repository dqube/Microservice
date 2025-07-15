namespace CompanyName.MyProjectName.BuildingBlocks.Storage;

public interface ICachePolicyManager
{
    void SetPolicy(string keyPattern, CachePolicy policy);

    CachePolicy GetPolicy(string key);

    void RemovePolicy(string keyPattern);
}