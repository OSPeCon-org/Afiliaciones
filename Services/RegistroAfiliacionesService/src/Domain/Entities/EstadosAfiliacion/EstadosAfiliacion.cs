using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class EstadosAfiliacion : Enumeration
    {

        public static EstadosAfiliacion EnProcesoCarga = new EstadosAfiliacion(1, nameof(EnProcesoCarga).ToLowerInvariant());
        public static EstadosAfiliacion Aprobado = new EstadosAfiliacion(3, nameof(Aprobado).ToLowerInvariant());
        public static EstadosAfiliacion Pendiente = new EstadosAfiliacion(2, nameof(Pendiente).ToLowerInvariant());
        public static EstadosAfiliacion Rechazado = new EstadosAfiliacion(4, nameof(Rechazado).ToLowerInvariant());
        public static EstadosAfiliacion Observado = new EstadosAfiliacion(5, nameof(Observado).ToLowerInvariant());

        public EstadosAfiliacion(int id, string nombre) : base(id, nombre)
        {
        }

        public static IEnumerable<EstadosAfiliacion> List() => new[] { EnProcesoCarga, Aprobado, Pendiente, Rechazado, Observado };

        public static EstadosAfiliacion FromName(string nombre)
        {
            var state = List().SingleOrDefault(s => String.Equals(s.Nombre, nombre, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Valores posibles para Estado de Afiliacion: {String.Join(",", List().Select(s => s.Nombre))}");
            }

            return state;
        }

        public static EstadosAfiliacion From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Valores posibles para Estado de Afiliacion: {String.Join(",", List().Select(s => s.Nombre))}");
            }

            return state;
        }
    }
}
