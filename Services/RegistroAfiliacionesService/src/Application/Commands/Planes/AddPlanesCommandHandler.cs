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
    public class AddPlanesCommandHandler : IRequestHandler<AddPlanesCommand, Guid>
    {
        private readonly IPlanesRepository _planesRepository;
        private readonly IEventBus _eventBus;

        public AddPlanesCommandHandler(IPlanesRepository planesRepository, IEventBus eventBus)
        {
            _planesRepository = planesRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddPlanesCommand command, CancellationToken cancellationToken)
        {

            Planes planes = new Planes(command.Descripcion, command.CodigoSSS);

            _planesRepository.Add(planes);

            await _planesRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return planes.Id;
        }
    }
}