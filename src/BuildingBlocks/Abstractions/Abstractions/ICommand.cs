namespace CompanyName.MyProjectName.BuildingBlocks.Abstractions.Abstractions;

public interface ICommand<out TResponse> : IMessage
{
}

public interface ICommand : ICommand<Unit>
{
}