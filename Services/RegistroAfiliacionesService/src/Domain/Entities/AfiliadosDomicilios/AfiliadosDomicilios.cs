using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class AfiliadosDomicilios : Entity, IAggregateRoot
    {
        public Guid AfiliadosId { get; set; }
        public Direccion Direccion { get; private set; }
        public Afiliados Afiliado { get; set; }


        public AfiliadosDomicilios()
        {
        }
        public AfiliadosDomicilios(Guid afiliadosId, Direccion direccion) : this()
        {


            AfiliadosId = afiliadosId;
            Direccion = direccion;

        }
        public void Update(Guid id, Guid afiliadosId, Direccion direccion)
        {


            Id = id;
            AfiliadosId = afiliadosId;
            Direccion = direccion;

        }
    }
}