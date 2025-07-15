namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

public interface ICommandHandler<in TCommand>
    where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : class, ICommand<TResponse>
{
    Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
