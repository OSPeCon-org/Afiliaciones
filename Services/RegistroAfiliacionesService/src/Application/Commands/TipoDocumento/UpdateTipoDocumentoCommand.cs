using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class UpdateTipoDocumentoCommand : IRequest<bool>
    {
        [DataMember]
        public Guid Id { get; set; }
         [DataMember]
         public string Descripcion { get; set; }
        
         [DataMember]
         public string CodigoSSS { get; set; }


        public UpdateTipoDocumentoCommand()
        {

        }

        public UpdateTipoDocumentoCommand(Guid id,string descripcion, string codigoSSS)
        {
            Id = id;
            Descripcion = descripcion;          
            CodigoSSS=codigoSSS;

        }
    }
}