namespace CompanyName.MyProjectName.BuildingBlocks.Saga.Managers;

internal interface ISagaPostProcessor
{
    Task ProcessAsync<TMessage>(
        ISaga saga,
        TMessage message,
        ISagaContext context,
        Func<TMessage, ISagaContext, Task> onCompleted,
        Func<TMessage, ISagaContext, Task> onRejected);
}