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
    public class UpdateDetalleDocumentacionCommandHandler : IRequestHandler<UpdateDetalleDocumentacionCommand, bool>
    {
        private readonly IDetalleDocumentacionRepository _documentacionRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;

        public UpdateDetalleDocumentacionCommandHandler(IDetalleDocumentacionRepository documentacionRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService)
        {
            _documentacionRepository = documentacionRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;

        }

        public async Task<bool> Handle(UpdateDetalleDocumentacionCommand command, CancellationToken cancellationToken)
        {

            var documentacionToUpdate = await _documentacionRepository.GetByIdAsync(command.Id);

            if (documentacionToUpdate == null) throw new NotFoundException();

            documentacionToUpdate.Update(command.Id, command.PlanId, command.ParentescoId, command.DocumentacionId, command.Obligatorio );

            _documentacionRepository.Update(documentacionToUpdate);

            await _documentacionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            Guid transactionId = Guid.NewGuid();
           // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);


            return true;
        }
    }
}