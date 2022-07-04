using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.SeedWork;
using OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Entities
{
    public class TipoMaterial : Entity, IAggregateRoot
    {
        public string Descripcion { get; set; }
        public List<Material> Materiales { get; }

        public TipoMaterial()
        {
        }
        public TipoMaterial(string descripcion) : this()
        {
            Descripcion = descripcion;
        }
        public void Update(Guid id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}