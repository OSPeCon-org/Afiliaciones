using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IDetalleDocumentacionRepository : IRepository<DetalleDocumentacion>
    {
        DetalleDocumentacion Add(DetalleDocumentacion detalleDocumentacion);
        DetalleDocumentacion Update(DetalleDocumentacion detalleDocumentacion);
        Task<DetalleDocumentacion> GetByIdAsync(Guid Id);
        
    }
}