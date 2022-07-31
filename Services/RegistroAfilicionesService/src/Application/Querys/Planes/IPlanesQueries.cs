namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IPlanesQueries
    {
        Task<PlanesDTO> GetPlanesAsync(Guid id);
        Task<IEnumerable<PlanesDTO>> GetPlanesByNameAsync(string descripcion);
        Task<IEnumerable<PlanesDTO>> GetAll();

    }
}