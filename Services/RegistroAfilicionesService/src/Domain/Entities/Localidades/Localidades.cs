using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class Localidades : Entity, IAggregateRoot
    {
        public string Descripcion { get; set; }
        public Guid ProvinciasId { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoSSS { get; set; }        
        public Provincias Provincia { get; set; }


        public Localidades()
        {
        }
        public Localidades(string descripcion, Guid provinciasId, string codigoPostal, string codigoSSS) : this()
        {
            Descripcion = descripcion;
            ProvinciasId = provinciasId;
            CodigoPostal=codigoPostal;
            CodigoSSS = codigoSSS;
        }
        public void Update(Guid id, string descripcion, Guid provinciasId, string codigoPostal, string codigoSSS)
        {
            Id = id;
            Descripcion = descripcion;
            ProvinciasId=provinciasId;
            CodigoPostal=codigoPostal;
            CodigoSSS = codigoSSS;
        }
    }
}