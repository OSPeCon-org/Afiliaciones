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
        public Guid AfiliadoId { get; set; }
        [DataMember]
        public Guid DetalleDocumentacionId { get; set; }

        [DataMember]
        public bool Aprobado { get; set; }
        [DataMember]
        public string Imagen { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        public AddAfiliadosDocumentacionCommand()
        {

        }
        public AddAfiliadosDocumentacionCommand(Guid afiliadoId, Guid detalleDocumentacionId, bool aprobado, string imagen, string tipo)

        {
            AfiliadoId = afiliadoId;
            DetalleDocumentacionId = detalleDocumentacionId;

            Aprobado = aprobado;
            Imagen = imagen;
            Tipo = tipo;
        }
    }
}