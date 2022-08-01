using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class DocumentacionDTO
    {
        public DocumentacionDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            Descripcion = "";
            Obligatorio = false;
            Discapacitado=false;
        }
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public bool Obligatorio { get; set; }
        public bool Discapacitado { get; set; }

    }
}