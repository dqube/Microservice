using CompanyName.MyProjectName.BuildingBlocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompanyName.MyProjectName.BuildingBlocks.Infrastructure.Data.Internals;

internal sealed class DataInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    public DataInitializer(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var initializers = scope.ServiceProvider.GetServices<IDataInitializer>();
        foreach (var initializer in initializers)
        {
            await initializer.InitAsync(); // Removed the cancellationToken argument  
        }
    }
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}