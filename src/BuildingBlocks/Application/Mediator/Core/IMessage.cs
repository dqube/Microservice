namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

// Marker interface
public interface IMessage
{
}

public interface IMessage<out TResult>
{
}