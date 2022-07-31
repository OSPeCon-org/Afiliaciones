using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Abstractions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;


namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents
{
    public class AfiliadoModificadoIntegrationEventHandler : IIntegrationEventHandler<AfiliadoModificadoIntegrationEvent>
    {
        private readonly ILogger<AfiliadoModificadoIntegrationEventHandler> _logger;
        private readonly IAfiliadosRepository _repository;

        public AfiliadoModificadoIntegrationEventHandler(
            ILogger<AfiliadoModificadoIntegrationEventHandler> logger,
            IAfiliadosRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Handle(AfiliadoModificadoIntegrationEvent @event)
        {
            _logger.LogInformation("Se Modifico el material Id = " + @event.AfiliadoId.ToString());
        }
    }


}