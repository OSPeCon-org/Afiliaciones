using System;
using System.Text.Json.Serialization;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Events;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents
{
    public record AfiliadoCreadoIntegrationEvent : IntegrationEvent
    {
        [JsonInclude]
        public Guid AfiliadoId { get; set; }
        public Guid UsuarioId { get; set; }
        public bool EsNuevoTitular { get; set; }

        [JsonConstructor]
        public AfiliadoCreadoIntegrationEvent(Guid afiliadoId, Guid usuarioId, bool esNuevoTitular)
        {
            AfiliadoId = afiliadoId;
            UsuarioId = usuarioId;
            EsNuevoTitular = esNuevoTitular;

        }
    }
}