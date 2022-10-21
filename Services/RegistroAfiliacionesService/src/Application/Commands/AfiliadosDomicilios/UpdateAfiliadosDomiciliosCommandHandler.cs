using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Exceptions;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Events;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Abstractions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents;
using OSPeConTI.Afiliaciones.BuildingBlocks.IntegrationEventLogEF.Services;
using System.Data.Common;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class UpdateAfiliadosDomiciliosCommandHandler : IRequestHandler<UpdateAfiliadosDomiciliosCommand, bool>
    {
        private readonly IAfiliadosDomiciliosRepository _afiliadosDomiciliosRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;

        public UpdateAfiliadosDomiciliosCommandHandler(IAfiliadosDomiciliosRepository afiliadosDomiciliosRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService)
        {
            _afiliadosDomiciliosRepository = afiliadosDomiciliosRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;

        }

        public async Task<bool> Handle(UpdateAfiliadosDomiciliosCommand command, CancellationToken cancellationToken)
        {

            var afiliadosDomiciliosToUpdate = await _afiliadosDomiciliosRepository.GetByIdAsync(command.Id);

            if (afiliadosDomiciliosToUpdate == null) throw new NotFoundException();

            afiliadosDomiciliosToUpdate.Update(command.Id, command.AfiliadoId, command.Calle, command.Altura, command.Piso, command.Departamento, command.LocalidadesId, command.CodigoPostal);

            _afiliadosDomiciliosRepository.Update(afiliadosDomiciliosToUpdate);

            await _afiliadosDomiciliosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            Guid transactionId = Guid.NewGuid();
           // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);


            return true;
        }
    }
}