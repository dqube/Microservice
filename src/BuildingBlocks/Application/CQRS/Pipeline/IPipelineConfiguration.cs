namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Pipeline;

// Pipeline configuration
public interface IPipelineConfiguration
{
    PipelineType Type { get; }
    IEnumerable<Type> BehaviorTypes { get; }
}
