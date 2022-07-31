namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IProvinciasQueries
    {
        Task<ProvinciasDTO> GetProvinciasAsync(Guid id);
        Task<IEnumerable<ProvinciasDTO>> GetProvinciasByNameAsync(string descripcion);
        Task<IEnumerable<ProvinciasDTO>> GetAll();

    }
}