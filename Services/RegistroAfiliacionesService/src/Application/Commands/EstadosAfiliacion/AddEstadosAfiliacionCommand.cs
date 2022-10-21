using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AddEstadosAfiliacionCommand : IRequest<Guid>
    {
         [DataMember]
         public string Descripcion { get; set; }
        
        public AddEstadosAfiliacionCommand()
        {

        }
        public AddEstadosAfiliacionCommand(string descripcion)

        {
            Descripcion = descripcion;          
           
        }
    }
}