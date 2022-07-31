using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class Parentescos : Entity, IAggregateRoot
    {
        public string Descripcion { get; set; }
        public string CodigoSSS { get; set; }
        public List<Afiliados> Afiliados { get; set; }


        public Parentescos()
        {
        }
        public Parentescos(string descripcion, string codigoSSS) : this()
        {
            Descripcion = descripcion;
            CodigoSSS = codigoSSS;
        }
        public void Update(Guid id, string descripcion, string codigoSSS)
        {
            Id = id;
            Descripcion = descripcion;
            CodigoSSS = codigoSSS;
        }
    }
}