using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class Afiliados : Entity, IAggregateRoot
    {
        public NombrePropio Apellido { get; set; }
        public string Nombre { get; set; }
        public Guid TipoDocumentoId { get; set; }
        public int Documento { get; set; }
        public Guid ParentescoId { get; set; }
        private Cuit _cuil;
        public Cuit CUIL { get => _cuil; private set => _cuil = value ?? throw new IncompleteDomainException(nameof(Cuit) + ", no puede ser nulo"); }

        public Guid TitularId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime Fecha { get; set; }
        public Guid PlanId { get; set; }
        public string Sexo { get; set; }
        public Guid EstadoCivilId { get; set; }
        public bool Discapacitado { get; set; }
        public Guid NacionalidadId { get; set; }
        public int EstadosAfiliacionId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public Parentescos Parentesco { get; set; }
        public Planes Plan { get; set; }
        public EstadosCiviles EstadoCivil { get; set; }
        public Nacionalidades Nacionalidad { get; set; }
        public Afiliados Titular { get; set; }






        public Afiliados()
        {

        }

        public Afiliados(Guid id, NombrePropio apellido, string nombre, Guid tipoDocumentoId, int documento, Guid parentescoId, Cuit cuil, DateTime fechaNacimiento, Guid planId, string sexo, Guid estadoCivilId, bool discapacitado, Guid nacionalidadId, Guid titularId)
        {

            if (string.IsNullOrEmpty(nombre)) throw new System.InvalidOperationException("El nombre no puede estar vacío");
            //if (string.IsNullOrEmpty(apellido)) throw new System.InvalidOperationException("El apellido no puede estar vacío");
            if (documento == 0) throw new System.InvalidOperationException("El documento no puede estar vacío");
            if (tipoDocumentoId == Guid.Empty) throw new System.InvalidOperationException("El tipo documento no puede estar vacío");
            if (parentescoId == Guid.Empty) throw new System.InvalidOperationException("El Parentesco no puede estar vacío");
            //if (string.IsNullOrEmpty(cuil)) throw new System.InvalidOperationException("El CUIL no puede estar vacío");
            if (planId == Guid.Empty) throw new System.InvalidOperationException("El Plan no puede estar vacío");
            if (nacionalidadId == Guid.Empty) throw new System.InvalidOperationException("La Nacionalidad no puede estar vacío");
            //if (estadosAfiliacionId == Guid.Empty) throw new System.InvalidOperationException("El Estado de Afiliacion no puede estar vacío");

            Id = id;
            Apellido = apellido;
            Nombre = nombre;
            TipoDocumentoId = tipoDocumentoId;
            Documento = documento;
            ParentescoId = parentescoId;
            CUIL = cuil;
            FechaNacimiento = fechaNacimiento;
            Fecha = DateTime.UtcNow.AddHours(-3);
            PlanId = planId;
            Sexo = sexo;
            EstadoCivilId = estadoCivilId;
            Discapacitado = discapacitado;
            NacionalidadId = nacionalidadId;
            EstadosAfiliacionId = EstadosAfiliacion.EnProcesoCarga.Id;
            TitularId = titularId;
            this.AddDomainEvent(new AfiliadosActualizadoRequested(this));
        }


        public void Aprobar()
        {
            EstadosAfiliacionId = EstadosAfiliacion.Aprobado.Id;
        }

        public void Rechazar()
        {
            EstadosAfiliacionId = EstadosAfiliacion.Rechazado.Id;
        }

        public void pasarAPendiente()
        {
            EstadosAfiliacionId = EstadosAfiliacion.Pendiente.Id;
        }
        public void Observar()
        {
            EstadosAfiliacionId = EstadosAfiliacion.Observado.Id;
        }
        public void pasarAEnProceso()
        {
            EstadosAfiliacionId = EstadosAfiliacion.EnProcesoCarga.Id;
        }

    }
}