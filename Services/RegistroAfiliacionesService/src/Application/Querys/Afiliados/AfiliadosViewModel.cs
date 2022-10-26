using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class AfiliadosDTO
    {
        public AfiliadosDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            Nombre = "";
            Apellido = "";
            TipoDocumentoId = Guid.Empty;
            TipoDocumentoNombre = "";
            Documento = 0;
            ParentescoId = Guid.Empty;
            CUIL = "";
            FechaNacimiento = null;
            Fecha = null;
            PlanId = Guid.Empty;
            PlanNombre = "";
            Sexo = "";
            EstadoCivilId = Guid.Empty;
            EstadoCivilNombre = "";
            Discapacitado = false;
            NacionalidadId = Guid.Empty;
            NacionalidadNombre = "";
            EstadosAfiliacionId = Guid.Empty;
            EstadosAfiliacionNombre = "";
            TitularId = Guid.Empty;
        }
        public Guid Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public Guid TipoDocumentoId { get; set; }
        public string TipoDocumentoNombre { get; set; }
        public int Documento { get; set; }
        public Guid ParentescoId { get; set; }
        public string ParentescoNombre { get; set; }
        public string CUIL { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? Fecha { get; set; }
        public Guid PlanId { get; set; }
        public string PlanNombre { get; set; }
        public string Sexo { get; set; }
        public Guid EstadoCivilId { get; set; }
        public string EstadoCivilNombre { get; set; }
        public bool Discapacitado { get; set; }
        public Guid NacionalidadId { get; set; }
        public string NacionalidadNombre { get; set; }
        public Guid EstadosAfiliacionId { get; set; }
        public string EstadosAfiliacionNombre { get; set; }
        public Guid TitularId { get; set; }


    }
}