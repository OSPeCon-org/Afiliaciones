namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IAfiliadosDocumentacionQueries
    {
        Task<AfiliadosDocumentacionDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<AfiliadosDocumentacionDTO>> GetByAfiliadoIdAsync(Guid idAfiliado);

    }
}