using CompanyName.MyProjectName.BuildingBlocks.Saga.Persistence;

namespace CompanyName.MyProjectName.BuildingBlocks.Saga.Builders;

internal sealed class SagaContextBuilder : ISagaContextBuilder
{
    private SagaId _sagaId;
    private string _originator;
#pragma warning disable SA1214 // Readonly fields should appear before non-readonly fields
    private readonly List<ISagaContextMetadata> _metadata;
#pragma warning restore SA1214 // Readonly fields should appear before non-readonly fields

    public SagaContextBuilder()
        => _metadata = new List<ISagaContextMetadata>();

    public ISagaContextBuilder WithSagaId(SagaId sagaId)
    {
        _sagaId = sagaId;
        return this;
    }

    public ISagaContextBuilder WithOriginator(string originator)
    {
        _originator = originator;
        return this;
    }

    public ISagaContextBuilder WithMetadata(string key, object value)
    {
        var metadata = new SagaContextMetadata(key, value);
        _metadata.Add(metadata);
        return this;
    }

    public ISagaContextBuilder WithMetadata(ISagaContextMetadata sagaContextMetadata)
    {
        _metadata.Add(sagaContextMetadata);
        return this;
    }

    public ISagaContext Build()
        => SagaContext.Create(_sagaId, _originator, _metadata);
}
