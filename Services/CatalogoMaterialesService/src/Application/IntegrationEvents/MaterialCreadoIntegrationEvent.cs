using System;
using System.Text.Json.Serialization;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Events;

namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Application.IntegrationEvents
{
    public record MaterialCreadoIntegrationEvent : IntegrationEvent
    {
        [JsonInclude]
        public Guid MaterialId { get; set; }

        [JsonConstructor]
        public MaterialCreadoIntegrationEvent(Guid materialId)
        {
            MaterialId = materialId;

        }
    }
}