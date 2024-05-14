namespace CompanyName.MyProjectName.BuildingBlocks.Saga;

public interface ISagaContext
{
    SagaId SagaId { get; }

    string Originator { get; }

    IReadOnlyCollection<ISagaContextMetadata> Metadata { get; }

    ISagaContextMetadata GetMetadata(string key);

    bool TryGetMetadata(string key, out ISagaContextMetadata metadata);

    SagaContextError SagaContextError { get; set; }
}
