using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class ActualizarAfiliadosContactosCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid AfiliadosId { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Particular { get; set; }
        [DataMember]
        public string Laboral { get; set; }
        [DataMember]
        public Email Mail { get; set; }
        [DataMember]
        public Email Mail2 { get; set; }
        [DataMember]
        public int CemapReferencia { get; set; }


        public ActualizarAfiliadosContactosCommand()
        {

        }

        public ActualizarAfiliadosContactosCommand(Guid id, Guid afiliadosId, string celular, string particular, string laboral, Email mail, Email mail2, int cemapReferencia)

        {
            Id = Id;
            AfiliadosId = afiliadosId;
            Celular = celular;
            Particular = particular;
            Laboral = laboral;
            Mail = mail;
            Mail2 = mail2;
            CemapReferencia = cemapReferencia;


        }
    }
}