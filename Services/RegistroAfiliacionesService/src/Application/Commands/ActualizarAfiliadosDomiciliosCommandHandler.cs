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
    public class ActualizarAfiliadosDomiciliosCommandHandler : IRequestHandler<ActualizarAfiliadosDomiciliosCommand, Guid>
    {
        private readonly IAfiliadosDomiciliosRepository _afiliadosDomiciliosRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;
        private readonly IAfiliadosDomiciliosQueries _afiliadosDomiciliosQueries;


        public ActualizarAfiliadosDomiciliosCommandHandler(IAfiliadosDomiciliosRepository afiliadosDomiciliosRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService, IAfiliadosDomiciliosQueries afiliadosDomiciliosQueries)
        {
            _afiliadosDomiciliosRepository = afiliadosDomiciliosRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;
            _afiliadosDomiciliosQueries = afiliadosDomiciliosQueries;
        }

        public async Task<Guid> Handle(ActualizarAfiliadosDomiciliosCommand command, CancellationToken cancellationToken)
        {

            var domicilio = new AfiliadosDomicilios(command.AfiliadoId, command.Calle, command.Altura, command.Piso, command.Departamento, command.LocalidadesId, command.CodigoPostal);

            IEnumerable<AfiliadosDomiciliosDTO> afiliadosDomiciliosToUpdate = await _afiliadosDomiciliosQueries.GetAfiliadosDomiciliosByAfiliadoIdAsync(command.AfiliadoId);

            if (afiliadosDomiciliosToUpdate.Count() == 0)
            {
                _afiliadosDomiciliosRepository.Add(domicilio);

            }
            else
            {
                domicilio.Id = afiliadosDomiciliosToUpdate.FirstOrDefault().Id;
                _afiliadosDomiciliosRepository.Update(domicilio);

            }

            await _afiliadosDomiciliosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            Guid transactionId = Guid.NewGuid();
            // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);

            return domicilio.Id;
        }
    }
}