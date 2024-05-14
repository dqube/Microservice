using CompanyName.MyProjectName.BuildingBlocks.Framework;

var builder = WebApplication.CreateBuilder(args).AddMicroFramework();
var app = builder.Build();
app.MapGet("/", (AppInfo appInfo) => appInfo).WithTags("API").WithName("Info");

app.MapGet("/ping", () => "pong").WithTags("API").WithName("Pong");

app.MapHealthChecks("/health").WithTags("API").WithName("Health");
app.UseMicroFramework().Run();