using CompanyName.MyProjectName.BuildingBlocks.Framework;
using CompanyName.MyProjectName.Patients.API;
using CompanyName.MyProjectName.Patients.Application;
using CompanyName.MyProjectName.Patients.Domain;
using CompanyName.MyProjectName.Patients.Infrastructure;

var builder = WebApplication.CreateBuilder(args).AddMicroFramework();
builder.Services
    .AddApplication()
    .AddDomain()
    .AddInfrastructure(builder.Configuration);
var app = builder.Build();
app.MapGet("/", (AppInfo appInfo) => appInfo).WithTags("API").WithName("Info");

app.MapGet("/ping", () => "pong").WithTags("API").WithName("Pong");

app.MapHealthChecks("/health").WithTags("API").WithName("Health");
app.UseMicroFramework();
Jobs.Register();
app.Run();