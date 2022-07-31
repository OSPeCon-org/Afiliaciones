namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IEstadosCivilesQueries
    {
        Task<EstadosCivilesDTO> GetEstadosCivilesAsync(Guid id);
        Task<IEnumerable<EstadosCivilesDTO>> GetEstadosCivilesByNameAsync(string descripcion);
        Task<IEnumerable<EstadosCivilesDTO>> GetAll();

    }
}