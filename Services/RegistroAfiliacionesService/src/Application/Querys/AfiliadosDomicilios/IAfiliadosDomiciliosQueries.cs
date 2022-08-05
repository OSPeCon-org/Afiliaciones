namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IAfiliadosDomiciliosQueries
    {
        Task<AfiliadosDomiciliosDTO> GetAfiliadosDomiciliosAsync(Guid id);
        Task<IEnumerable<AfiliadosDomiciliosDTO>> GetAfiliadosDomiciliosByAfiliadoIdAsync(Guid idAfiliado);
       
    }
}