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
    public class ActualizarAfiliadosCommandHandler : IRequestHandler<ActualizarAfiliadosCommand, Guid>
    {
        private readonly IAfiliadosRepository _afiliadosRepository;

        private readonly AfiliacionesContext _AfiliacionesContext;

        private readonly IAfiliacionIntegrationEventService _afiliacionIntegrationEventService;

        public ActualizarAfiliadosCommandHandler(IAfiliadosRepository afiliadosRepository, AfiliacionesContext AfiliacionesContext, IAfiliacionIntegrationEventService afiliacionIntegrationEventService)
        {
            _afiliadosRepository = afiliadosRepository;

            _AfiliacionesContext = AfiliacionesContext;

            _afiliacionIntegrationEventService = afiliacionIntegrationEventService;

        }

        public async Task<Guid> Handle(ActualizarAfiliadosCommand command, CancellationToken cancellationToken)
        {

            var afiliado = new Afiliados(command.Id, command.Apellido, command.Nombre, command.TipoDocumentoId, command.Documento, command.ParentescoId, command.CUIL, command.FechaNacimiento, command.PlanId, command.Sexo, command.EstadoCivilId, command.Discapacitado, command.NacionalidadId, command.EstadosAfiliacionId, command.TitularId);

            if (afiliado.Id == Guid.Empty){
                afiliado.Id = Guid.NewGuid();
                if (afiliado.TitularId==Guid.Empty) afiliado.TitularId=afiliado.Id;
                _afiliadosRepository.Add(afiliado);
            }else{
                /* var afiliadosToActualizar = await _afiliadosRepository.GetAsync(command.Id);
                if (afiliadosToActualizar == null) throw new NotFoundException(); */
                
                _afiliadosRepository.Update(afiliado);
            }

            await _afiliadosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            AfiliadoModificadoIntegrationEvent evento = new AfiliadoModificadoIntegrationEvent(command.Id);


            //Guid transactionId = Guid.NewGuid();
           // await _afiliacionIntegrationEventService.AddAndSaveEventAsync(evento, transactionId);
            //await _afiliacionIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);


            return afiliado.Id;
        }
    }
}