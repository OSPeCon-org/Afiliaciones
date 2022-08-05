using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class Documentacion : Entity, IAggregateRoot
    {
        public string Descripcion { get; set; }
        
        public bool Discapacidad { get; set; }
        public List<DetalleDocumentacion> DetallesDocumentacion { get; set; }
        


        public Documentacion()
        {
        }
        public Documentacion(string descripcion, bool discapacidad) : this()
        {
            if (string.IsNullOrEmpty(descripcion)) throw new System.InvalidOperationException("La descripcion no puede estar vacío");
            Descripcion = descripcion;          
            Discapacidad=discapacidad;
        }
        public void Update(Guid id, string descripcion, bool discapacidad)
        {
            if (string.IsNullOrEmpty(descripcion)) throw new System.InvalidOperationException("La descripcion no puede estar vacío");
            Id = id;
            Descripcion = descripcion;            
            Discapacidad=discapacidad;
        }
    }
}