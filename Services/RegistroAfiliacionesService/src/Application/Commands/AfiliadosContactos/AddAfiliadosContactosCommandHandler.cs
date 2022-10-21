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
    public class AddAfiliadosContactosCommandHandler : IRequestHandler<AddAfiliadosContactosCommand, Guid>
    {
        private readonly IAfiliadosContactosRepository _afiliadosContactosRepository;
        private readonly IEventBus _eventBus;

        public AddAfiliadosContactosCommandHandler(IAfiliadosContactosRepository afiliadosContactosRepository, IEventBus eventBus)
        {
            _afiliadosContactosRepository = afiliadosContactosRepository;
            _eventBus = eventBus;
        }

        public async Task<Guid> Handle(AddAfiliadosContactosCommand command, CancellationToken cancellationToken)
        {

            AfiliadosContactos afiliadosContactos = new AfiliadosContactos(command.AfiliadosId, command.Celular, command.Particular, command.Laboral, command.Mail, command.Mail2);

            _afiliadosContactosRepository.Add(afiliadosContactos);
            await _afiliadosContactosRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return afiliadosContactos.Id;
        }
    }
}