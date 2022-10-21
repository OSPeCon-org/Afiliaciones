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
    public class AddNacionalidadesCommandHandler : IRequestHandler<AddNacionalidadesCommand, Guid>
    {
        private readonly INacionalidadesRepository _nacionalidadesRepository;
        private readonly IEventBus _eventBus;

        public AddNacionalidadesCommandHandler(INacionalidadesRepository nacionalidadesRepository, IEventBus eventBus)
        {
            _nacionalidadesRepository = nacionalidadesRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddNacionalidadesCommand command, CancellationToken cancellationToken)
        {

            Nacionalidades nacionalidades = new Nacionalidades(command.Descripcion, command.CodigoSSS);

            _nacionalidadesRepository.Add(nacionalidades);

            await _nacionalidadesRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return nacionalidades.Id;
        }
    }
}