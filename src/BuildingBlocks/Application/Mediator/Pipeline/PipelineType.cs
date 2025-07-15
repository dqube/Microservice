namespace CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Pipeline;

// Pipeline behavior (similar to MediatR but more flexible)

// Pipeline types
public enum PipelineType
{
    CommandPipeline,
    QueryPipeline,
    MessagePipeline,
    StreamPipeline
}
