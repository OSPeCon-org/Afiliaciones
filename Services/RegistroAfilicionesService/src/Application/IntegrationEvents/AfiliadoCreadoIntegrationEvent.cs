using System;
using System.Text.Json.Serialization;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Events;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents
{
    public record AfiliadoCreadoIntegrationEvent : IntegrationEvent
    {
        [JsonInclude]
        public Guid AfiliadoId { get; set; }

        [JsonConstructor]
        public AfiliadoCreadoIntegrationEvent(Guid afiliadoId)
        {
            AfiliadoId = afiliadoId;

        }
    }
}