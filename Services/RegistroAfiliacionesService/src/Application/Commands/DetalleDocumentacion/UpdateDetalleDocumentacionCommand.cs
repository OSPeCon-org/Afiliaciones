using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class UpdateDetalleDocumentacionCommand : IRequest<bool>
    {
        [DataMember]
        public Guid Id { get; set; }
         [DataMember]
         public Guid PlanId { get; set; }

        [DataMember]    
         public Guid ParentescoId { get; set; }
         [DataMember]        
        public Guid DocumentacionId { get; set; }
         [DataMember]        
         public bool Obligatorio { get; set; }


        public UpdateDetalleDocumentacionCommand()
        {

        }

        public UpdateDetalleDocumentacionCommand(Guid id,Guid planId, Guid parentescoId, Guid documentacionId, bool obligatorio)
        {
            Id = id;
            PlanId = planId;
            ParentescoId = parentescoId;
            DocumentacionId = documentacionId;
            Obligatorio = obligatorio;
        

        }
    }
}