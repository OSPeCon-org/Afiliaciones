using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class Nacionalidades : Entity, IAggregateRoot
    {
        public string Descripcion { get; set; }
        public string CodigoSSS { get; set; }
        public List<Afiliados> Afiliados { get; set; }

        public Nacionalidades()
        {
        }
        public Nacionalidades(string descripcion, string codigoSSS) : this()
        {
            if (string.IsNullOrEmpty(descripcion)) throw new System.InvalidOperationException("La descripcion no puede estar vacío");
            Descripcion = descripcion;
            CodigoSSS = codigoSSS;
        }
        public void Update(Guid id, string descripcion, string codigoSSS)
        {
            if (string.IsNullOrEmpty(descripcion)) throw new System.InvalidOperationException("La descripcion no puede estar vacío");
            Id = id;
            Descripcion = descripcion;
            CodigoSSS = codigoSSS;
        }
    }
}