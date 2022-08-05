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
    public class AddDetalleDocumentacionCommandHandler : IRequestHandler<AddDetalleDocumentacionCommand, Guid>
    {
        private readonly IDetalleDocumentacionRepository _detalleDocumentacionRepository;
        private readonly IEventBus _eventBus;

        public AddDetalleDocumentacionCommandHandler(IDetalleDocumentacionRepository detalleDocumentacionRepository, IEventBus eventBus)
        {
            _detalleDocumentacionRepository = detalleDocumentacionRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddDetalleDocumentacionCommand command, CancellationToken cancellationToken)
        {

            DetalleDocumentacion detalleDocumentacion = new DetalleDocumentacion(command.PlanId, command.ParentescoId, command.DocumentacionId, command.Obligatorio );

            _detalleDocumentacionRepository.Add(detalleDocumentacion);

            await _detalleDocumentacionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            AfiliadoCreadoIntegrationEvent evento = new AfiliadoCreadoIntegrationEvent(detalleDocumentacion.Id);
            _eventBus.Publish(evento);
            return detalleDocumentacion.Id;
        }
    }
}