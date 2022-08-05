using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class EstadoAfiliacionDTO
    {
        public EstadoAfiliacionDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            Descripcion = "";
            
        }
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        

    }
}