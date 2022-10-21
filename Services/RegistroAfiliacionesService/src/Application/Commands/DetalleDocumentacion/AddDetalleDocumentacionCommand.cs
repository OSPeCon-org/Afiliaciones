using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AddDetalleDocumentacionCommand : IRequest<Guid>
    {
        [DataMember]
         public Guid PlanId { get; set; }

        [DataMember]    
         public Guid ParentescoId { get; set; }
         [DataMember]        
        public Guid DocumentacionId { get; set; }
         [DataMember]        
         public bool Obligatorio { get; set; }

        public AddDetalleDocumentacionCommand()
        {

        }
        public AddDetalleDocumentacionCommand(Guid planId, Guid parentescoId, Guid documentacionId, bool obligatorio)

        {
            PlanId = planId;
            ParentescoId = parentescoId;
            DocumentacionId = documentacionId;
            Obligatorio = obligatorio;

        }
    }
}