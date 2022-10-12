using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Abstractions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Autorizacion;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents
{
    public class AfiliadoCreadoIntegrationEventHandler : IIntegrationEventHandler<AfiliadoCreadoIntegrationEvent>
    {
        private readonly ILogger<AfiliadoCreadoIntegrationEventHandler> _logger;
        private readonly UsuarioAfiliadosRepository _repository;

        public AfiliadoCreadoIntegrationEventHandler(
            ILogger<AfiliadoCreadoIntegrationEventHandler> logger,
            UsuarioAfiliadosRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Handle(AfiliadoCreadoIntegrationEvent @event)
        {
            if (@event.EsNuevoTitular)
            {
                var usuarioAfiliado = new UsuarioAfiliados();
                usuarioAfiliado.AfiliadoId = @event.AfiliadoId;
                usuarioAfiliado.UsuarioId = @event.UsuarioId;
                usuarioAfiliado.Activo = true;
                _repository.Add(usuarioAfiliado);
                await _repository.UnitOfWork.SaveEntitiesAsync();
            }
        }
    }


}