namespace OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Abstractions;

public interface IDynamicIntegrationEventHandler
{
    Task Handle(dynamic eventData);
}
