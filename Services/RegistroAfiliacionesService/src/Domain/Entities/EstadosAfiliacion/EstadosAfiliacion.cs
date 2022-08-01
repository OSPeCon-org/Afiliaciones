using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class EstadosAfiliacion : Entity, IAggregateRoot
    {
        public string Descripcion { get; set; }
        
        public List<Afiliados> Afiliados { get; set; }


        public EstadosAfiliacion()
        {
        }
        public EstadosAfiliacion(string descripcion) : this()
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