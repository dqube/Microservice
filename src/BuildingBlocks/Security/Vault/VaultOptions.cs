namespace CompanyName.MyProjectName.BuildingBlocks.Security.Vault;

// Endpoint=https://idelearn.azconfig.io;Id=zqxa;Secret=LO1KGrpValdTdhoL82MK9mVeFkjTLeoNYmVDUDN2HuQ=
public sealed class VaultOptions
{
    public bool Enabled { get; set; } = false;

    public string Endpoint { get; set; } = string.Empty;
}
