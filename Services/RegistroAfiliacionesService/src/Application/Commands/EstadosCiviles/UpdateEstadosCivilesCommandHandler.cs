using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class UpdateEstadosCivilesCommandHandler : IRequestHandler<UpdateEstadosCivilesCommand, bool>
    {
        private readonly IEstadosCivilesRepository _estadosCivilesRepository;

        public UpdateEstadosCivilesCommandHandler(IEstadosCivilesRepository estadosCivilesRepository)
        {
            _estadosCivilesRepository = estadosCivilesRepository;
        }

        public async Task<bool> Handle(UpdateEstadosCivilesCommand command, CancellationToken cancellationToken)
        {

            var estadosCivilesToUpdate = await _estadosCivilesRepository.GetByIdAsync(command.Id);

            if (estadosCivilesToUpdate == null)
            {
                return false;
            }

            estadosCivilesToUpdate.Update(command.Id, command.Descripcion, command.CodigoSSS);

            _estadosCivilesRepository.Update(estadosCivilesToUpdate);

            return await _estadosCivilesRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}