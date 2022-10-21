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
    public class AddEstadosAfiliacionCommandHandler : IRequestHandler<AddEstadosAfiliacionCommand, Guid>
    {
        private readonly IEstadosAfiliacionRepository _estadosAfiliacionRepository;
        private readonly IEventBus _eventBus;

        public AddEstadosAfiliacionCommandHandler(IEstadosAfiliacionRepository estadosAfiliacionRepository, IEventBus eventBus)
        {
            _estadosAfiliacionRepository = estadosAfiliacionRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddEstadosAfiliacionCommand command, CancellationToken cancellationToken)
        {

            EstadosAfiliacion estadosAfiliacion = new EstadosAfiliacion(command.Descripcion);

            _estadosAfiliacionRepository.Add(estadosAfiliacion);

            await _estadosAfiliacionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return estadosAfiliacion.Id;
        }
    }
}