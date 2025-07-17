using CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Core;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.CQRS.Pipeline;

// Pipeline registry
public interface IPipelineRegistry
{
    PipelineConfiguration GetConfiguration(Type messageType);
    void ConfigurePipeline(Type messageType, Action<PipelineConfiguration> configure);
    void ConfigurePipeline<TMessage>(Action<PipelineConfiguration> configure) where TMessage : IMessage;
}

public class PipelineConfiguration
{
    public List<Type> BehaviorTypes { get; } = new List<Type>();
    public PipelineType PipelineType { get; set; } = PipelineType.CommandPipeline;
}
