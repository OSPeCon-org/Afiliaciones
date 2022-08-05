using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AddDocumentacionCommand : IRequest<Guid>
    {
         [DataMember]
         public string Descripcion { get; set; }
         [DataMember]        
        public bool Discapacidad { get; set; }

        public AddDocumentacionCommand()
        {

        }
        public AddDocumentacionCommand(string descripcion, bool discapacidad)

        {
            Descripcion = descripcion;          
            Discapacidad=discapacidad;
        }
    }
}