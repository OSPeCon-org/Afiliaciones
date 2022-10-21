using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AddAfiliadosDocumentacionCommand : IRequest<Guid>
    {
         [DataMember]
         public  Guid AfiliadoId { get; set; }
        [DataMember]
        public Guid DetalleDocumentacionId { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public bool Aprobado { get; set; }
        public AddAfiliadosDocumentacionCommand()
        {

        }
        public AddAfiliadosDocumentacionCommand(Guid afiliadoId, Guid detalleDocumentacionId, string url, bool aprobado)

        {
            AfiliadoId=afiliadoId;
            DetalleDocumentacionId = detalleDocumentacionId;
            URL = url;
            Aprobado = aprobado;
        }
    }
}