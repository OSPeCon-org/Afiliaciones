using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class DetalleDocumentacion : Entity, IAggregateRoot
    {
        public Guid PlanId { get; set; }
        public Guid ParentescoId { get; set; }
        public Guid DocumentacionId { get; set; }
        public bool Obligatorio { get; set; }
        public Planes Plan { get; set; }
        public Documentacion Documentacion { get; set; }


        public DetalleDocumentacion()
        {
        }
        public DetalleDocumentacion(Guid planId, Guid parentescoId, Guid documentacionId, bool obligatorio) : this()
        {
                      
            if (planId == Guid.Empty) throw new System.InvalidOperationException("El Plan no puede estar vacío");
            if (parentescoId == Guid.Empty) throw new System.InvalidOperationException("El Parentesco no puede estar vacío");
 
            PlanId=planId;
            ParentescoId=parentescoId;
            DocumentacionId=documentacionId;
            Obligatorio=obligatorio;
        }
        public void Update(Guid id, Guid planId, Guid parentescoId, Guid documentacionId, bool obligatorio)
        {
            Id = id;
            PlanId=planId;
            ParentescoId=parentescoId;
            DocumentacionId=documentacionId;
            Obligatorio = obligatorio;
        }
    }
}