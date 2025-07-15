using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Handlers;
using CompanyName.MyProjectName.BuildingBlocks.Transactions.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.MyProjectName.BuildingBlocks.Transactions;

public static class Extensions
{
    public static IServiceCollection AddTransactionalDecorators(this IServiceCollection services)
    {
        services.AddTransient(typeof(ICommandHandler<>), typeof(TransactionalCommandHandlerDecorator<>));
        services.AddTransient(typeof(IEventHandler<>), typeof(TransactionalEventHandlerDecorator<>));

        return services;
    }

    public static IServiceCollection AddOutboxInstantSenderDecorators(this IServiceCollection services)
    {
        services.AddTransient(typeof(ICommandHandler<>), typeof(OutboxInstantSenderCommandHandlerDecorator<>));
        services.AddTransient(typeof(IEventHandler<>), typeof(OutboxInstantSenderEventHandlerDecorator<>));

        return services;
    }
}