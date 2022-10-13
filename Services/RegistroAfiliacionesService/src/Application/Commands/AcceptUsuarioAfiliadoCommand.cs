using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AcceptUsuarioAfiliadoCommand : IRequest<bool>
    {
        [DataMember]
        public Guid AfiliadoId { get; set; }

        public Guid UsuarioId { get; set; }

        public AcceptUsuarioAfiliadoCommand()
        {

        }

        public AcceptUsuarioAfiliadoCommand(Guid id, Guid usuarioId)
        {
            AfiliadoId = id;
            UsuarioId = usuarioId;

        }
    }
}