﻿using System.Reflection;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Attributes;
using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Abstractions.Dispatchers;

public static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services, string project, IEnumerable<Assembly> assemblies = null)
    {
        assemblies ??= AppDomain.CurrentDomain.GetAssemblies()
               .Where(x => x.FullName is not null && x.FullName.Contains(project))
               .ToArray();

        services.Scan(s => s.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>))
                        .WithoutAttribute<DecoratorAttribute>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>))
                .WithoutAttribute<DecoratorAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>))
                .WithoutAttribute<DecoratorAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>))
                .WithoutAttribute<DecoratorAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }

    public static IServiceCollection AddDispatchers(this IServiceCollection services)
        => services
            .AddSingleton<IDispatcher, InMemoryDispatcher>()
            .AddSingleton<ICommandDispatcher, CommandDispatcher>()
            .AddSingleton<IEventDispatcher, EventDispatcher>()
            .AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddSingleton<IQueryDispatcher, QueryDispatcher>();
}