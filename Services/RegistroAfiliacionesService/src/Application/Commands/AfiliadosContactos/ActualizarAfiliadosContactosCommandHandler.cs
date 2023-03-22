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
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries;
using System.Collections.Generic;
using System.Linq;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class ActualizarAfiliadosContactosCommandHandler : IRequestHandler<ActualizarAfiliadosContactosCommand, Guid>
    {
        private readonly IAfiliadosContactosRepository _afiliadosContactosRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;
        private readonly IAfiliadosContactosQueries _afiliadosContactosQueries;


        public ActualizarAfiliadosContactosCommandHandler(IAfiliadosContactosRepository afiliadosContactosRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService, IAfiliadosContactosQueries afiliadosContactosQueries)
        {
            _afiliadosContactosRepository = afiliadosContactosRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;
            _afiliadosContactosQueries = afiliadosContactosQueries;
        }

        public async Task<Guid> Handle(ActualizarAfiliadosContactosCommand command, CancellationToken cancellationToken)
        {

            var contacto = new AfiliadosContactos(command.AfiliadosId, command.Celular, command.Particular, command.Laboral, command.Mail, command.Mail2, command.CemapReferencia);

            IEnumerable<AfiliadosContactosDTO> afiliadosContactosToUpdate = await _afiliadosContactosQueries.GetAfiliadosContactosByAfiliadoIdAsync(command.AfiliadosId);

            if (afiliadosContactosToUpdate.Count() == 0)
            {
                _afiliadosContactosRepository.Add(contacto);

            }
            else
            {
                contacto.Id = afiliadosContactosToUpdate.FirstOrDefault().Id;
                _afiliadosContactosRepository.Update(contacto);

            }

            await _afiliadosContactosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            //AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            Guid transactionId = Guid.NewGuid();
            // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);

            return contacto.Id;
        }


    }
}