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
    public class UpdateAfiliadosContactosCommandHandler : IRequestHandler<UpdateAfiliadosContactosCommand, bool>
    {
        private readonly IAfiliadosContactosRepository _afiliadosContactosRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;

        public UpdateAfiliadosContactosCommandHandler(IAfiliadosContactosRepository afiliadosContactosRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService)
        {
            _afiliadosContactosRepository = afiliadosContactosRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;

        }

        public async Task<bool> Handle(UpdateAfiliadosContactosCommand command, CancellationToken cancellationToken)
        {

            var afiliadosContactosToUpdate = await _afiliadosContactosRepository.GetByIdAsync(command.Id);

            if (afiliadosContactosToUpdate == null) throw new NotFoundException();

            afiliadosContactosToUpdate.Update(command.Id, command.AfiliadosId, command.Celular, command.Particular, command.Laboral, command.Mail, command.Mail2, command.CemapReferencia);

            _afiliadosContactosRepository.Update(afiliadosContactosToUpdate);

            await _afiliadosContactosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            Guid transactionId = Guid.NewGuid();
            // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);


            return true;
        }
    }
}