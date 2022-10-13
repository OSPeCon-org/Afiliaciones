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

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class AcceptUsuarioAfiliadoCommandHandler : IRequestHandler<AcceptUsuarioAfiliadoCommand, bool>
    {

        private readonly AfiliadoCreadoIntegrationEventHandler _afiliadoCreadoIntegrationEventHandler;

        public AcceptUsuarioAfiliadoCommandHandler(AfiliadoCreadoIntegrationEventHandler afiliadoCreadoIntegrationEventHandler)
        {

            _afiliadoCreadoIntegrationEventHandler = afiliadoCreadoIntegrationEventHandler;
        }

        public async Task<bool> Handle(AcceptUsuarioAfiliadoCommand command, CancellationToken cancellationToken)
        {
            AfiliadoCreadoIntegrationEvent evento = new AfiliadoCreadoIntegrationEvent(command.AfiliadoId, command.UsuarioId, true);

            await _afiliadoCreadoIntegrationEventHandler.Handle(evento);

            return true;

        }
    }
}