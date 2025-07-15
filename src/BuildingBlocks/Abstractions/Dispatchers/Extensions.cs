using System.Reflection;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Attributes;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Abstractions.Dispatchers;

public static class Extensions
{
    public static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services
            .AddSingleton<IDispatcher, InMemoryDispatcher>()
            .AddSingleton<ICommandDispatcher, CommandDispatcher>()
            .AddSingleton<IEventDispatcher, EventDispatcher>()
            .AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddSingleton<IQueryDispatcher, QueryDispatcher>();
}