
using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class RechazarAfiliadosCommand : IRequest<bool>
    {
        [DataMember]
        public Guid Id { get; set; }


        public RechazarAfiliadosCommand()
        {

        }


    }
}