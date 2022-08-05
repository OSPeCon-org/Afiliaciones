namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IDetalleDocumentacionQueries
    {
        Task<DetalleDocumentacionDTO> GetDetalleDocumentacionAsync(Guid id);
        Task<IEnumerable<DetalleDocumentacionDTO>> GetDetalleDocumentacionByPlanParentescoAsync(Guid planId, Guid parentescoId, bool discapacidad);
        Task<IEnumerable<DetalleDocumentacionDTO>> GetAll();

    }
}