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
    public class UpdateAfiliadosCommandHandler : IRequestHandler<UpdateAfiliadosCommand, bool>
    {
        private readonly IAfiliadosRepository _afiliadosRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;

        public UpdateAfiliadosCommandHandler(IAfiliadosRepository afiliadosRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService)
        {
            _afiliadosRepository = afiliadosRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;

        }

        public async Task<bool> Handle(UpdateAfiliadosCommand command, CancellationToken cancellationToken)
        {

            var afiliadosToUpdate = await _afiliadosRepository.GetAsync(command.Id);

            if (afiliadosToUpdate == null) throw new NotFoundException();

            afiliadosToUpdate.Update(command.Id, command.Apellido, command.Nombre, command.TipoDocumentoId, command.Documento, command.ParentescoId, command.CUIL, command.FechaNacimiento, command.PlanId, command.Sexo, command.EstadoCivilId, command.Discapacitado, command.NacionalidadId, command.EstadosAfiliacionId);

            _afiliadosRepository.Update(afiliadosToUpdate);

            await _afiliadosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            Guid transactionId = Guid.NewGuid();
           // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);


            return true;
        }
    }
}