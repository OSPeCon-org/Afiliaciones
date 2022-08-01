using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AddEstadosCivilesCommand : IRequest<Guid>
    {
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string CodigoSSS { get; set; }

        public AddEstadosCivilesCommand()
        {

        }
        public AddEstadosCivilesCommand(string descripcion, string codigoSSS)

        {
            Descripcion = descripcion;
            CodigoSSS = codigoSSS;
        }

    }
}