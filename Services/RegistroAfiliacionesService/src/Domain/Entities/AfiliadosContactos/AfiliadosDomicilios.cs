using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class AfiliadosContactos : Entity, IAggregateRoot
    {
        public Guid AfiliadosId { get; set; }
        public string Celular { get; set; }
        public string Particular { get; set; }
        public string Laboral { get; set; }
        public string Mail { get; set; }
        public string Mail2 { get; set; }
        public Afiliados Afiliado { get; set; }


        public AfiliadosContactos()
        {
        }
        public AfiliadosContactos(Guid afiliadosId, string celular, string particular, string laboral, string mail, string mail2) : this()
        {
            if (string.IsNullOrEmpty(celular)) throw new System.InvalidOperationException("El celular no puede estar vacío");
            if (string.IsNullOrEmpty(mail)) throw new System.InvalidOperationException("El mail principal no puede estar vacío");

            AfiliadosId = afiliadosId;
            Celular = celular;
            Particular=particular;
            Laboral=laboral;
            Mail=mail;
            Mail2=mail2;
        }
        public void Update(Guid id, Guid afiliadosId, string celular, string particular, string laboral, string mail, string mail2)
        {
            if (string.IsNullOrEmpty(celular)) throw new System.InvalidOperationException("El celular no puede estar vacío");
            if (string.IsNullOrEmpty(mail)) throw new System.InvalidOperationException("El mail principal no puede estar vacío");
            Id = id;
            AfiliadosId = afiliadosId;
            Celular = celular;
            Particular=particular;
            Laboral=laboral;
            Mail=mail;
            Mail2=mail2;
        }
    }
}