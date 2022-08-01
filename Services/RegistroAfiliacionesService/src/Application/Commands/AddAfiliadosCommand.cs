using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AddAfiliadosCommand : IRequest<Guid>
    {
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public Guid TipoDocumentoId { get; set; }
        [DataMember]
        public int Documento { get; set; }
        [DataMember]
        public Guid ParentescoId { get; set; }
        [DataMember]
        public string CUIL { get; set; }
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




        public AddAfiliadosCommand()
        {

        }
        public AddAfiliadosCommand(string apellido, string nombre, Guid tipoDocumentoId, int documento, Guid parentescoId, string cuil, DateTime fechaNacimiento, Guid planId, string sexo, Guid estadoCivilId, bool discapacitado, Guid nacionalidadId, Guid estadosAfiliacionId)

        {
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
        }
    }
}