using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class UpdateDocumentacionCommand : IRequest<bool>
    {
        [DataMember]
        public Guid Id { get; set; }
         [DataMember]
         public string Descripcion { get; set; }
         [DataMember]        
        public bool Discapacidad { get; set; }


        public UpdateDocumentacionCommand()
        {

        }

        public UpdateDocumentacionCommand(Guid id,string descripcion, bool discapacidad)
        {
            Id = id;
            Descripcion = descripcion;          
            Discapacidad=discapacidad;

        }
    }
}