using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AddAfiliadosContactosCommand : IRequest<Guid>
    {
         [DataMember]
         public  Guid AfiliadosId { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Particular { get; set; }
        [DataMember]
        public string Laboral { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string Mail2 { get; set; }



        public AddAfiliadosContactosCommand()
        {

        }
        public AddAfiliadosContactosCommand(Guid afiliadoId, Guid afiliadosId, string celular, string particular, string laboral, string mail, string mail2)

        {
            AfiliadosId = afiliadosId;
            Celular = celular;
            Particular=particular;
            Laboral=laboral;
            Mail=mail;
            Mail2=mail2;

        }
    }
}