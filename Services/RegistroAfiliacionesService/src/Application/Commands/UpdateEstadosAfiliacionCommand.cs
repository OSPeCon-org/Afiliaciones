using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class UpdateEstadosAfiliacionCommand : IRequest<bool>
    {
        [DataMember]
        public Guid Id { get; set; }
         [DataMember]
         public string Descripcion { get; set; }
        
     


        public UpdateEstadosAfiliacionCommand()
        {

        }

        public UpdateEstadosAfiliacionCommand(Guid id,string descripcion)
        {
            Id = id;
            Descripcion = descripcion;          
          

        }
    }
}