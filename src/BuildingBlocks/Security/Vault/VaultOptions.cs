namespace CompanyName.MyProjectName.BuildingBlocks.Security.Vault;

public sealed class VaultOptions
{
    public bool Enabled { get; set; } = false;

    public string Endpoint { get; set; } = string.Empty;
}
