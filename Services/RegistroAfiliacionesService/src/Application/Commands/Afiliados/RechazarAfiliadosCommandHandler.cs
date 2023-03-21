using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Exceptions;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Events;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Abstractions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents;
using OSPeConTI.Afiliaciones.BuildingBlocks.IntegrationEventLogEF.Services;
using System.Data.Common;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class RechazarAfiliadosCommandHandler : IRequestHandler<RechazarAfiliadosCommand, bool>
    {
        private readonly AfiliacionesContext _AfiliacionesContext;
        private readonly IAfiliadosRepository _afiliadosRepository;


        public RechazarAfiliadosCommandHandler(IAfiliadosRepository afiliadosRepository, AfiliacionesContext afiliacionesContext)
        {
            _afiliadosRepository = afiliadosRepository;
            _AfiliacionesContext = afiliacionesContext;
        }

        public async Task<bool> Handle(RechazarAfiliadosCommand command, CancellationToken cancellationToken)
        {

            var afiliado = await _afiliadosRepository.GetAsync(command.Id);
            //Si es un afiliado nuevo
            if (afiliado == null) throw new NotFoundException();
            afiliado.Rechazar();
            _afiliadosRepository.Update(afiliado);
            _AfiliacionesContext.SaveChanges();
            return true;
        }
    }
}