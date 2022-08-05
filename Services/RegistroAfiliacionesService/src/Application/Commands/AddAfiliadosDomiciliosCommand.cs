using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    [DataContract]
    public class AddAfiliadosDomiciliosCommand : IRequest<Guid>
    {
         [DataMember]
         public  Guid AfiliadoId { get; set; }
        [DataMember]
        public string Calle { get; set; }
        [DataMember]
        public string Altura { get; set; }
        [DataMember]
        public string Piso { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public Guid LocalidadesId { get; set; }

        [DataMember]
        public string CodigoPostal { get; set; }
        



        public AddAfiliadosDomiciliosCommand()
        {

        }
        public AddAfiliadosDomiciliosCommand(Guid afiliadoId, string calle, string altura, string piso, string departamento, Guid localidadesId, string codigoPostal)

        {
            AfiliadoId=afiliadoId;
            Calle = calle;
            Altura = altura;
            Piso = piso;
            Departamento = departamento;
            LocalidadesId = localidadesId;
            CodigoPostal = codigoPostal;
        }
    }
}