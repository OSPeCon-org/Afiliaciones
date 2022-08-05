using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class AfiliadosDomicilios : Entity, IAggregateRoot
    {
        public Guid AfiliadosId { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public Guid LocalidadesId { get; set; }
        public string CodigoPostal { get; set; }
        public Afiliados Afiliado { get; set; }
        public Localidades Localidad { get; set; }
       
        public AfiliadosDomicilios()
        {
        }
        public AfiliadosDomicilios(Guid afiliadosId, string calle, string altura, string piso, string departamento, Guid localidadesId, string codigoPostal) : this()
        {
            if (string.IsNullOrEmpty(calle)) throw new System.InvalidOperationException("La calle no puede estar vacía");
            
            AfiliadosId = afiliadosId;
            Calle = calle;
            Altura=altura;
            Piso= piso;
            Departamento=departamento;
            LocalidadesId=localidadesId;
            CodigoPostal=codigoPostal;
        }
        public void Update(Guid id, Guid afiliadosId, string calle, string altura, string piso, string departamento, Guid localidadesId, string codigoPostal)
        {
            if (string.IsNullOrEmpty(calle)) throw new System.InvalidOperationException("La descripcion no puede estar vacío");
            Id = id;
            AfiliadosId = afiliadosId;
            Calle = calle;
            Altura=altura;
            Piso= piso;
            Departamento=departamento;
            LocalidadesId=localidadesId;
            CodigoPostal=codigoPostal;
        }
    }
}