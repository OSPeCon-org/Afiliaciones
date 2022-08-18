using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class UpdateAfiliadosContactosCommand : IRequest<bool>
    {
        [DataMember]
        public Guid Id { get; set; }
       
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


        public UpdateAfiliadosContactosCommand()
        {

        }

        public UpdateAfiliadosContactosCommand(Guid id, Guid afiliadosId, string celular, string particular, string laboral, string mail, string mail2)

        {
            Id=Id;
            AfiliadosId = afiliadosId;
            Celular = celular;
            Particular=particular;
            Laboral=laboral;
            Mail=mail;
            Mail2=mail2;

        
        }
    }
}