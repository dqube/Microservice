namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Pipeline;

// Pipeline configuration
public interface IPipelineConfiguration
{
    PipelineType Type { get; }
    IEnumerable<Type> BehaviorTypes { get; }
}
