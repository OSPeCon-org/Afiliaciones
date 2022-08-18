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
    public class UpdateTipoDocumentoCommandHandler : IRequestHandler<UpdateTipoDocumentoCommand, bool>
    {
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;

        public UpdateTipoDocumentoCommandHandler(ITipoDocumentoRepository tipoDocumentoRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;

        }

        public async Task<bool> Handle(UpdateTipoDocumentoCommand command, CancellationToken cancellationToken)
        {

            var tipoDocumentoToUpdate = await _tipoDocumentoRepository.GetByIdAsync(command.Id);

            if (tipoDocumentoToUpdate == null) throw new NotFoundException();

            tipoDocumentoToUpdate.Update(command.Id, command.Descripcion, command.CodigoSSS);

            _tipoDocumentoRepository.Update(tipoDocumentoToUpdate);

            await _tipoDocumentoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            Guid transactionId = Guid.NewGuid();
           // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);


            return true;
        }
    }
}