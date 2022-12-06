using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class AfiliadosDocumentacionDTO
    {
        public AfiliadosDocumentacionDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            AfiliadosId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            DocumentacionId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            DetalleDocumentacionId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            URL = "";
            Aprobado = false;
            Apellido = "";
            Nombre = "";
            Documentacion = "";

        }
        public Guid Id { get; set; }
        public Guid AfiliadosId { get; set; }
        public Guid DetalleDocumentacionId { get; set; }
        public Guid DocumentacionId { get; set; }
        public string URL { get; set; }
        public bool Aprobado { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Documentacion { get; set; }
        public int Estado { get; set; }





    }
}