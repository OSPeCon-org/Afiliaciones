using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Events;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents
{

    public interface IAfiliacionIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt, Guid transacationId);
    }
}