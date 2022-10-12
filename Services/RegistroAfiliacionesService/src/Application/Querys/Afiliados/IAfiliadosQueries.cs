namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IAfiliadosQueries
    {
        Task<AfiliadosDTO> GetAfiliadosAsync(Guid id);
        Task<IEnumerable<AfiliadosDTO>> GetAfiliadosByNameAsync(string descripcion);
        Task<IEnumerable<AfiliadosDTO>> GetAll();
        Task<IEnumerable<AfiliadosDTO>> GetGrupoFamiliar(Guid titularId);

        Task<AfiliadosDTO> GetAfiliadosByCuilAsync(string cuil);


    }
}