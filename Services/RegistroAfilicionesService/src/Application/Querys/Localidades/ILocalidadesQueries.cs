namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface ILocalidadesQueries
    {
        Task<LocalidadesDTO> GetLocalidadesAsync(Guid id);
        Task<IEnumerable<LocalidadesDTO>> GetLocalidadesByNameAsync(string descripcion);
        Task<IEnumerable<LocalidadesDTO>> GetAll();
        Task<List<LocalidadesDTO>> GetLocalidadesByProvincia(Guid provinciaId);


    }
}