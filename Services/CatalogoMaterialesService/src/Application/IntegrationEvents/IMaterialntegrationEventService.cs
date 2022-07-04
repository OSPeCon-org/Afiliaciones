using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Events;

namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Application.IntegrationEvents
{

    public interface IMaterialIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt, Guid transacationId);
    }
}