# .NET 9.0 Upgrade Plan

## Execution Steps

1. Validate that an .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade src/BuildingBlocks/Abstractions/CompanyName.MyProjectName.BuildingBlocks.Abstractions.csproj
4. Upgrade src/BuildingBlocks/Contexts/CompanyName.MyProjectName.BuildingBlocks.Contexts.csproj
5. Upgrade src/Services/Patients/Domain/CompanyName.MyProjectName.Patients.Domain.csproj
6. Upgrade src/BuildingBlocks/Messaging/CompanyName.MyProjectName.BuildingBlocks.Messaging.csproj
7. Upgrade src/BuildingBlocks/SQLServer/CompanyName.MyProjectName.BuildingBlocks.SQLServer.csproj
8. Upgrade src/BuildingBlocks/Jobs/CompanyName.MyProjectName.BuildingBlocks.Jobs.csproj
9. Upgrade src/Services/Patients/Application/CompanyName.MyProjectName.Patients.Application.csproj
10. Upgrade src/BuildingBlocks/HTTP/CompanyName.MyProjectName.BuildingBlocks.HTTP.csproj
11. Upgrade src/BuildingBlocks/Security/CompanyName.MyProjectName.BuildingBlocks.Security.csproj
12. Upgrade src/BuildingBlocks/Auth/CompanyName.MyProjectName.BuildingBlocks.Auth.csproj
13. Upgrade src/BuildingBlocks/Observability/CompanyName.MyProjectName.BuildingBlocks.Observability.csproj
14. Upgrade src/BuildingBlocks/API/CompanyName.MyProjectName.BuildingBlocks.API.csproj
15. Upgrade src/BuildingBlocks/Transactions/CompanyName.MyProjectName.BuildingBlocks.Transactions.csproj
16. Upgrade src/BuildingBlocks/Storage/CompanyName.MyProjectName.BuildingBlocks.Storage.csproj
17. Upgrade src/Services/Patients/Infrastructure/CompanyName.MyProjectName.Patients.Infrastructure.csproj
18. Upgrade src/BuildingBlocks/Framework/CompanyName.MyProjectName.BuildingBlocks.Framework.csproj
19. Upgrade src/Services/Patients/API/CompanyName.MyProjectName.Patients.API.csproj
20. Upgrade src/Tests/BuildingBlocks/Abstractions.Tests/CompanyName.MyProjectName.BuildingBlocks.Abstractions.Tests.csproj
21. Upgrade src/Gateway/CompanyName.MyProjectName.Gateway.API.csproj
22. Upgrade src/BuildingBlocks/WCF/CompanyName.MyProjectName.BuildingBlocks.Wcf.csproj
23. Upgrade src/BuildingBlocks/Saga/CompanyName.MyProjectName.BuildingBlocks.Saga.csproj
24. Run unit tests to validate upgrade in the projects listed below:
  src/Tests/BuildingBlocks/Abstractions.Tests/CompanyName.MyProjectName.BuildingBlocks.Abstractions.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

| Package Name                        | Current Version | New Version | Description                         |
|:------------------------------------|:---------------:|:-----------:|:------------------------------------|
| Azure.Identity                      |   1.12.1        |  1.14.2     | Deprecated dependency, upgrade recommended |
| FluentValidation.AspNetCore          |   11.3.0        |  11.3.1     | Deprecated version, upgrade recommended |
| Microsoft.AspNetCore.Authentication.Certificate |   8.0.4        |  9.0.7      | Recommended for .NET 9.0            |
| Microsoft.AspNetCore.Authentication.JwtBearer   |   8.0.4        |  9.0.7      | Recommended for .NET 9.0            |
| Microsoft.AspNetCore.Authorization   |   8.0.4        |  9.0.7      | Recommended for .NET 9.0            |
| Microsoft.EntityFrameworkCore        |   9.0.0-preview.3.24172.4 |  9.0.7      | Recommended for .NET 9.0            |
| Microsoft.EntityFrameworkCore.SqlServer |   9.0.0-preview.3.24172.4 |  9.0.7      | Recommended for .NET 9.0            |
| Microsoft.Extensions.Diagnostics.HealthChecks |   9.0.0-preview.3.24172.13 |  9.0.7      | Recommended for .NET 9.0            |
| Microsoft.Extensions.Http.Polly      |   9.0.0-preview.3.24172.13 |  9.0.7      | Recommended for .NET 9.0            |
| System.Security.Cryptography.Pkcs    |   8.0.0         |  9.0.7      | Recommended for .NET 9.0            |

### Project upgrade details

#### src/BuildingBlocks/Abstractions/CompanyName.MyProjectName.BuildingBlocks.Abstractions.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - FluentValidation.AspNetCore should be updated from `11.3.0` to `11.3.1` (deprecated version)

#### src/BuildingBlocks/Contexts/CompanyName.MyProjectName.BuildingBlocks.Contexts.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/Services/Patients/Domain/CompanyName.MyProjectName.Patients.Domain.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/BuildingBlocks/Messaging/CompanyName.MyProjectName.BuildingBlocks.Messaging.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/BuildingBlocks/SQLServer/CompanyName.MyProjectName.BuildingBlocks.SQLServer.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Microsoft.EntityFrameworkCore should be updated from `9.0.0-preview.3.24172.4` to `9.0.7` (recommended for .NET 9.0)
  - Microsoft.EntityFrameworkCore.SqlServer should be updated from `9.0.0-preview.3.24172.4` to `9.0.7` (recommended for .NET 9.0)

#### src/BuildingBlocks/Jobs/CompanyName.MyProjectName.BuildingBlocks.Jobs.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/Services/Patients/Application/CompanyName.MyProjectName.Patients.Application.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/BuildingBlocks/HTTP/CompanyName.MyProjectName.BuildingBlocks.HTTP.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Microsoft.Extensions.Http.Polly should be updated from `9.0.0-preview.3.24172.13` to `9.0.7` (recommended for .NET 9.0)

#### src/BuildingBlocks/Security/CompanyName.MyProjectName.BuildingBlocks.Security.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Azure.Identity should be updated from `1.12.1` to `1.14.2` (deprecated dependency)

#### src/BuildingBlocks/Auth/CompanyName.MyProjectName.BuildingBlocks.Auth.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Microsoft.AspNetCore.Authentication.Certificate should be updated from `8.0.4` to `9.0.7` (recommended for .NET 9.0)
  - Microsoft.AspNetCore.Authentication.JwtBearer should be updated from `8.0.4` to `9.0.7` (recommended for .NET 9.0)
  - Microsoft.AspNetCore.Authorization should be updated from `8.0.4` to `9.0.7` (recommended for .NET 9.0)

#### src/BuildingBlocks/Observability/CompanyName.MyProjectName.BuildingBlocks.Observability.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - Microsoft.Extensions.Diagnostics.HealthChecks should be updated from `9.0.0-preview.3.24172.13` to `9.0.7` (recommended for .NET 9.0)

#### src/BuildingBlocks/API/CompanyName.MyProjectName.BuildingBlocks.API.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/BuildingBlocks/Transactions/CompanyName.MyProjectName.BuildingBlocks.Transactions.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/BuildingBlocks/Storage/CompanyName.MyProjectName.BuildingBlocks.Storage.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/Services/Patients/Infrastructure/CompanyName.MyProjectName.Patients.Infrastructure.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/BuildingBlocks/Framework/CompanyName.MyProjectName.BuildingBlocks.Framework.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/Services/Patients/API/CompanyName.MyProjectName.Patients.API.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/Tests/BuildingBlocks/Abstractions.Tests/CompanyName.MyProjectName.BuildingBlocks.Abstractions.Tests.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/Gateway/CompanyName.MyProjectName.Gateway.API.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

#### src/BuildingBlocks/WCF/CompanyName.MyProjectName.BuildingBlocks.Wcf.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
NuGet packages changes:
  - System.Security.Cryptography.Pkcs should be updated from `8.0.0` to `9.0.7` (recommended for .NET 9.0)

#### src/BuildingBlocks/Saga/CompanyName.MyProjectName.BuildingBlocks.Saga.csproj modifications
Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`
