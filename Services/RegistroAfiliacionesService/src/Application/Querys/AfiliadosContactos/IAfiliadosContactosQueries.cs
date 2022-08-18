namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IAfiliadosContactosQueries
    {
        Task<AfiliadosContactosDTO> GetAfiliadosContactosAsync(Guid id);
        Task<IEnumerable<AfiliadosContactosDTO>> GetAfiliadosContactosByAfiliadoIdAsync(Guid idAfiliado);
       
    }
}