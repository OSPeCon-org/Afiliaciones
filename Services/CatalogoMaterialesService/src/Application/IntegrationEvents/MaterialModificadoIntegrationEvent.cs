using System;
using System.Text.Json.Serialization;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Events;

namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Application.IntegrationEvents
{
    public record MaterialModificadoIntegrationEvent : IntegrationEvent
    {
        [JsonInclude]
        public Guid MaterialId { get; set; }
        [JsonConstructor]
        public MaterialModificadoIntegrationEvent(Guid materialId)
        {
            MaterialId = materialId;

        }
    }
}