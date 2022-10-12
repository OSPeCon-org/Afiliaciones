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
    public class AddAfiliadosDocumentacionCommandHandler : IRequestHandler<AddAfiliadosDocumentacionCommand, Guid>
    {
        private readonly IAfiliadosDocumentacionRepository _afiliadosDomiciliosDomiciliosRepository;
        private readonly IEventBus _eventBus;

        public AddAfiliadosDocumentacionCommandHandler(IAfiliadosDocumentacionRepository afiliadosDomiciliosDomiciliosRepository, IEventBus eventBus)
        {
            _afiliadosDomiciliosDomiciliosRepository = afiliadosDomiciliosDomiciliosRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddAfiliadosDocumentacionCommand command, CancellationToken cancellationToken)
        {

            AfiliadosDocumentacion afiliadosDomiciliosDomicilios = new AfiliadosDocumentacion(command.AfiliadoId, command.DetalleDocumentacionId, command.URL, command.Aprobado);

            _afiliadosDomiciliosDomiciliosRepository.Add(afiliadosDomiciliosDomicilios);

            await _afiliadosDomiciliosDomiciliosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return afiliadosDomiciliosDomicilios.Id;
        }
    }
}