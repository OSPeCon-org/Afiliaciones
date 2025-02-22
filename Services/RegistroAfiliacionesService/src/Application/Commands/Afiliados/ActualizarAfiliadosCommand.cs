using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class ActualizarAfiliadosCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public NombrePropio Apellido { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public Guid TipoDocumentoId { get; set; }
        [DataMember]
        public int Documento { get; set; }
        [DataMember]
        public Guid ParentescoId { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Guid PlanId { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public Guid EstadoCivilId { get; set; }
        [DataMember]
        public bool Discapacitado { get; set; }
        [DataMember]
        public Guid NacionalidadId { get; set; }
        [DataMember]
        public Guid EstadosAfiliacionId { get; set; }
        [DataMember]
        public Guid TitularId { get; set; }
        public Guid UsuaroId { get; set; }
        [DataMember]
        public Cuit CUIL { get; set; }


        public ActualizarAfiliadosCommand()
        {

        }

        /*   public ActualizarAfiliadosCommand(Guid id, string apellido, string nombre, Guid tipoDocumentoId, int documento, Guid parentescoId, Cuit cuil, DateTime fechaNacimiento, Guid planId, string sexo, Guid estadoCivilId, bool discapacitado, Guid nacionalidadId, Guid estadosAfiliacionId, Guid titularId)
          {
              Id = id;
              Apellido = apellido;
              Nombre = nombre;
              TipoDocumentoId = tipoDocumentoId;
              Documento = documento;
              ParentescoId = parentescoId;
              CUIL = cuil;
              FechaNacimiento = fechaNacimiento;
              PlanId = planId;
              Sexo = sexo;
              EstadoCivilId = estadoCivilId;
              Discapacitado = discapacitado;
              NacionalidadId = nacionalidadId;
              Fecha = new DateTime();
              EstadosAfiliacionId = estadosAfiliacionId;
              TitularId = titularId;
          } */
    }
}