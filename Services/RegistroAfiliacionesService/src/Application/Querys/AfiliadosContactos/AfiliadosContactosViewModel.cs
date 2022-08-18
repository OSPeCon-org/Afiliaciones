using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class AfiliadosContactosDTO
    {
        public AfiliadosContactosDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            AfiliadosId=Guid.Parse("00000000-0000-0000-0000-000000000000");
            Nombre = "";
            Apellido = "";
            Celular = "";
            Particular="";
            Laboral="";
            Mail="";
            Mail2 = "";
            
        }
        public Guid Id { get; set; }
        public Guid AfiliadosId { get; set; }
        public string Celular { get; set; }
        public string Particular { get; set; }
        public string Laboral { get; set; }
        public string Mail { get; set; }
        public string Mail2 { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
      


    }
}