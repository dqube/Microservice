namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

// Marker interface
public interface IMessage
{
}

public interface IMessage<out TResult>
{
}