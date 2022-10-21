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
    public class AddParentescosCommandHandler : IRequestHandler<AddParentescosCommand, Guid>
    {
        private readonly IParentescosRepository _parentescosRepository;
        private readonly IEventBus _eventBus;

        public AddParentescosCommandHandler(IParentescosRepository parentescosRepository, IEventBus eventBus)
        {
            _parentescosRepository = parentescosRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddParentescosCommand command, CancellationToken cancellationToken)
        {

            Parentescos parentescos = new Parentescos(command.Descripcion, command.CodigoSSS);

            _parentescosRepository.Add(parentescos);

            await _parentescosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return parentescos.Id;
        }
    }
}