namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Entities;

    public interface IClasificacionesQueries
    {
        Task<ClasificacionDTO> GetClasificacionesAsync(Guid id);
        Task<IEnumerable<ClasificacionDTO>> GetClasificacionesByNameAsync(string descripcion);
        Task<IEnumerable<ClasificacionDTO>> GetAll();

    }
}