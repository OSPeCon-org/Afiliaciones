namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IEstadosAfiliacionQueries
    {
        Task<EstadoAfiliacionDTO> GetEstadosAfiliacionAsync(Guid id);
        Task<IEnumerable<EstadoAfiliacionDTO>> GetEstadosAfiliacionByNameAsync(string descripcion);
        Task<IEnumerable<EstadoAfiliacionDTO>> GetAll();

    }
}