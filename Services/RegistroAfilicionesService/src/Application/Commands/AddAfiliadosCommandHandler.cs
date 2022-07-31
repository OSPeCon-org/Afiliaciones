using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Abstractions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class AddAfiliadosCommandHandler : IRequestHandler<AddAfiliadosCommand, Guid>
    {
        private readonly IAfiliadosRepository _afiliadosRepository;
        private readonly IEventBus _eventBus;

        public AddAfiliadosCommandHandler(IAfiliadosRepository afiliadosRepository, IEventBus eventBus)
        {
            _afiliadosRepository = afiliadosRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddAfiliadosCommand command, CancellationToken cancellationToken)
        {

            Afiliados afiliados = new Afiliados(command.Apellido, command.Nombre, command.TipoDocumentoId, command.Documento, command.ParentescoId, command.CUIL, command.FechaNacimiento, command.PlanId, command.Sexo, command.EstadoCivilId, command.Discapacitado, command.NacionalidadId);

            _afiliadosRepository.Add(afiliados);

            await _afiliadosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            AfiliadoCreadoIntegrationEvent evento = new AfiliadoCreadoIntegrationEvent(afiliados.Id);
            _eventBus.Publish(evento);
            return afiliados.Id;
        }
    }
}