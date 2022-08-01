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
        public bool Obligatorio { get; set; }
        public bool Discapacidad { get; set; }
        


        public Documentacion()
        {
        }
        public Documentacion(string descripcion, bool obligatorio, bool discapacidad) : this()
        {
            Descripcion = descripcion;
            Obligatorio=obligatorio;
            Discapacidad=discapacidad;
        }
        public void Update(Guid id, string descripcion, bool obligatorio, bool discapacidad)
        {
            Id = id;
            Descripcion = descripcion;
            Obligatorio=obligatorio;
            Discapacidad=discapacidad;
        }
    }
}