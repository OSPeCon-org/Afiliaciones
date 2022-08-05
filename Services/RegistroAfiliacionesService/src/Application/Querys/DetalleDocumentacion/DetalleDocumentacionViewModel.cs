using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class DetalleDocumentacionDTO
    {
        public DetalleDocumentacionDTO()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000");
            PlanId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            PlanNombre = "";
            DocumentacionId=Guid.Parse("00000000-0000-0000-0000-000000000000");
            DocumentacionNombre="";
        }
        public Guid Id { get; set; }
        public Guid PlanId { get; set; }
        public string PlanNombre { get; set; }
        public Guid DocumentacionId { get; set; }
        public string DocumentacionNombre { get; set; }
        public bool Obligatorio { get; set; }
        public bool Discapacidad { get; set; }

    }
}