namespace CompanyName.MyProjectName.BuildingBlocks.Saga;

public interface ISagaContextBuilder
{
    ISagaContextBuilder WithSagaId(SagaId sagaId);

    ISagaContextBuilder WithOriginator(string originator);

    ISagaContextBuilder WithMetadata(string key, object value);

    ISagaContextBuilder WithMetadata(ISagaContextMetadata sagaContextMetadata);

    ISagaContext Build();
}
