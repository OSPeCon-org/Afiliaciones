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
    public class AddAfiliadosDomiciliosCommandHandler : IRequestHandler<AddAfiliadosDomiciliosCommand, Guid>
    {
        private readonly IAfiliadosDomiciliosRepository _afiliadosDomiciliosDomiciliosRepository;
        private readonly IEventBus _eventBus;

        public AddAfiliadosDomiciliosCommandHandler(IAfiliadosDomiciliosRepository afiliadosDomiciliosDomiciliosRepository, IEventBus eventBus)
        {
            _afiliadosDomiciliosDomiciliosRepository = afiliadosDomiciliosDomiciliosRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddAfiliadosDomiciliosCommand command, CancellationToken cancellationToken)
        {

            AfiliadosDomicilios afiliadosDomiciliosDomicilios = new AfiliadosDomicilios(command.AfiliadoId, command.Calle, command.Altura, command.Piso, command.Departamento, command.LocalidadesId, command.CodigoPostal);

            _afiliadosDomiciliosDomiciliosRepository.Add(afiliadosDomiciliosDomicilios);

            await _afiliadosDomiciliosDomiciliosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return afiliadosDomiciliosDomicilios.Id;
        }
    }
}