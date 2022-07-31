using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class AddEstadosCivilesCommandHandler : IRequestHandler<AddEstadosCivilesCommand, Guid>
    {
        private readonly IEstadosCivilesRepository _estadosCivilesRepository;

        public AddEstadosCivilesCommandHandler(IEstadosCivilesRepository estadosCivilesRepository)
        {
            _estadosCivilesRepository = estadosCivilesRepository;
        }

        public async Task<Guid> Handle(AddEstadosCivilesCommand command, CancellationToken cancellationToken)
        {

            EstadosCiviles estadosCiviles = new EstadosCiviles(command.Descripcion, command.CodigoSSS);

            _estadosCivilesRepository.Add(estadosCiviles);

            await _estadosCivilesRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return estadosCiviles.Id;
        }
    }
}