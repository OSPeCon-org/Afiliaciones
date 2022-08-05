using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public class AfiliadosDocumentacion : Entity, IAggregateRoot
    {
        public Guid AfiliadosId { get; set; }
        public Guid DetalleDocumentacionId { get; set; }
        public string URL { get; set; }
        public bool Aprobado { get; set; }
        public Afiliados Afiliado { get; set; }
        public Documentacion Documentacion { get; set; }
       
        public AfiliadosDocumentacion()
        {
        }
        public AfiliadosDocumentacion(Guid afiliadosId, Guid detalleDocumentacionId, string url, bool aprobado) : this()
        {
            //if (string.IsNullOrEmpty(calle)) throw new System.InvalidOperationException("La calle no puede estar vacía");
            
            AfiliadosId = afiliadosId;
            DetalleDocumentacionId= detalleDocumentacionId;
            URL=url;
            Aprobado=aprobado;
            
        }
        public void Update(Guid id,Guid afiliadosId, Guid detalleDocumentacionId, string url, bool aprobado)
        {
            //if (string.IsNullOrEmpty(calle)) throw new System.InvalidOperationException("La descripcion no puede estar vacío");
            Id = id;
            AfiliadosId = afiliadosId;
            DetalleDocumentacionId= detalleDocumentacionId;
            URL=url;
            Aprobado=aprobado;
        }
    }
}