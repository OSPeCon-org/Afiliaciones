namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface INacionalidadesQueries
    {
        Task<NacionalidadDTO> GetNacionalidadesAsync(Guid id);
        Task<IEnumerable<NacionalidadDTO>> GetNacionalidadesByNameAsync(string descripcion);
        Task<IEnumerable<NacionalidadDTO>> GetAll();

    }
}