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
        public EstadosDocumento Estado { get; set; }
        public Afiliados Afiliado { get; set; }
        public Documentacion Documentacion { get; set; }

        public enum EstadosDocumento
        {
            Pendiente = 0,
            Aprobado = 1,
            Rechazado = 2,
            EnProceso = 3
        }

        public AfiliadosDocumentacion()
        {
        }
        public AfiliadosDocumentacion(Guid afiliadosId, Guid detalleDocumentacionId, string url, EstadosDocumento estado) : this()
        {

            if (afiliadosId == Guid.Empty) throw new System.InvalidOperationException("El Afiliado no puede estar vacío");
            if (detalleDocumentacionId == Guid.Empty) throw new System.InvalidOperationException("La documentación no puede estar vacía");

            AfiliadosId = afiliadosId;
            DetalleDocumentacionId = detalleDocumentacionId;
            URL = url;
            Estado = estado;

        }
        public void Update(Guid id, Guid afiliadosId, Guid detalleDocumentacionId, string url, EstadosDocumento estado)
        {
            if (afiliadosId == Guid.Empty) throw new System.InvalidOperationException("El Afiliado no puede estar vacío");
            if (detalleDocumentacionId == Guid.Empty) throw new System.InvalidOperationException("La documentación no puede estar vacía");
            Id = id;
            AfiliadosId = afiliadosId;
            DetalleDocumentacionId = detalleDocumentacionId;
            URL = url;
            Estado = estado;
        }
    }
}
