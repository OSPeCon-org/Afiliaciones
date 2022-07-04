using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Entities;

namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Application.Queries
{
    public class ClasificacionDTO
    {
        public ClasificacionDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            Descripcion = "SIN CLASIFICACION";
        }
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
    }
}