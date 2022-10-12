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
        private readonly IEstadosAfiliacionRepository _planesRepository;
        private readonly IEventBus _eventBus;

        public AddEstadosAfiliacionCommandHandler(IEstadosAfiliacionRepository planesRepository, IEventBus eventBus)
        {
            _planesRepository = planesRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddEstadosAfiliacionCommand command, CancellationToken cancellationToken)
        {

            EstadosAfiliacion planes = new EstadosAfiliacion(command.Descripcion);

            _planesRepository.Add(planes);

            await _planesRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return planes.Id;
        }
    }
}