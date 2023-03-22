using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class AfiliadosContactos : Entity, IAggregateRoot
    {
        public Guid AfiliadosId { get; private set; }
        public string Celular { get; private set; }
        public string Particular { get; private set; }
        public string Laboral { get; private set; }
        public int CemapReferencia { get; set; }
        private Email _mail;
        public Email Mail { get => _mail; private set => _mail = value ?? throw new IncompleteDomainException(nameof(Mail) + ", no puede ser nulo"); }


        public Email Mail2 { get; private set; }

        public Afiliados Afiliado { get; private set; }


        public AfiliadosContactos()
        {
        }
        public AfiliadosContactos(Guid afiliadosId, string celular, string particular, string laboral, Email mail, Email mail2, int cemapReferencia) : this()
        {
            if (string.IsNullOrEmpty(celular)) throw new System.InvalidOperationException("El celular no puede estar vacío");


            AfiliadosId = afiliadosId;
            Celular = celular;
            Particular = particular;
            Laboral = laboral;
            Mail = mail;
            Mail2 = mail2;
            CemapReferencia = cemapReferencia;
        }
        public void Update(Guid id, Guid afiliadosId, string celular, string particular, string laboral, Email mail, Email mail2, int cemapReferencia)
        {
            if (string.IsNullOrEmpty(celular)) throw new System.InvalidOperationException("El celular no puede estar vacío");
            Id = id;
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