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
    public class AddDocumentacionCommandHandler : IRequestHandler<AddDocumentacionCommand, Guid>
    {
        private readonly IDocumentacionRepository _documentacionRepository;
        private readonly IEventBus _eventBus;

        public AddDocumentacionCommandHandler(IDocumentacionRepository documentacionRepository, IEventBus eventBus)
        {
            _documentacionRepository = documentacionRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddDocumentacionCommand command, CancellationToken cancellationToken)
        {

            Documentacion documentacion = new Documentacion(command.Descripcion, command.Discapacidad);

            _documentacionRepository.Add(documentacion);

            await _documentacionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return documentacion.Id;
        }
    }
}