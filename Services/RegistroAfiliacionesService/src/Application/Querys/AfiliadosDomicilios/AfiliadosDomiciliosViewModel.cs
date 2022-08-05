using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class AfiliadosDomiciliosDTO
    {
        public AfiliadosDomiciliosDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            AfiliadosId=Guid.Parse("00000000-0000-0000-0000-000000000000");
            Nombre = "";
            Apellido = "";
            Calle = "";
            Altura="";
            Piso="";
            Departamento="";
            LocalidadesId = Guid.Empty;
            CodigoPostal="";
            Localidad="";
            Provincia="";
            
        }
        public Guid Id { get; set; }
        public Guid AfiliadosId { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public Guid LocalidadesId { get; set; }
        public string CodigoPostal { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public string Provincia {get;set;}
        


    }
}