using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class LocalidadesDTO
    {
        public LocalidadesDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            Descripcion = "";
            ProvinciasId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            ProvinciaNombre = "";
            CodigoPostal="";
            CodigoSSS = "";
        }
        public Guid Id { get; set; }
         public string Descripcion { get; set; }
        public Guid ProvinciasId { get; set; }
        public string ProvinciaNombre { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoSSS { get; set; }

    }
}