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
    public class UpdateParentescosCommandHandler : IRequestHandler<UpdateParentescosCommand, bool>
    {
        private readonly IParentescosRepository _parentescosRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;

        public UpdateParentescosCommandHandler(IParentescosRepository parentescosRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService)
        {
            _parentescosRepository = parentescosRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;

        }

        public async Task<bool> Handle(UpdateParentescosCommand command, CancellationToken cancellationToken)
        {

            var parentescosToUpdate = await _parentescosRepository.GetByIdAsync(command.Id);

            if (parentescosToUpdate == null) throw new NotFoundException();

            parentescosToUpdate.Update(command.Id, command.Descripcion, command.CodigoSSS);

            _parentescosRepository.Update(parentescosToUpdate);

            await _parentescosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            Guid transactionId = Guid.NewGuid();
           // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);


            return true;
        }
    }
}