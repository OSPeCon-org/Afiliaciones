using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class UpdateAfiliadosDocumentacionCommand : IRequest<bool>
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid AfiliadoId { get; set; }
        [DataMember]
        public Guid DetalleDocumentacionId { get; set; }
        [DataMember]
        public string File { get; set; }
        [DataMember]
        public bool Aprobado { get; set; }


        public UpdateAfiliadosDocumentacionCommand()
        {

        }

        public UpdateAfiliadosDocumentacionCommand(Guid id, Guid afiliadoId, Guid detalleDocumentacionId, string file, bool aprobado)

        {
            Id = id;
            AfiliadoId = afiliadoId;
            DetalleDocumentacionId = detalleDocumentacionId;
            File = file;
            Aprobado = aprobado;
        }
    }
}