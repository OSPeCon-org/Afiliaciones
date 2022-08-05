namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IAfiliadosDocumentacionQueries
    {
        Task<AfiliadosDocumentacionDTO> GetAfiliadosDocumentacionAsync(Guid id);
        Task<IEnumerable<AfiliadosDocumentacionDTO>> GetAfiliadosDocumentacionByAfiliadoIdAsync(Guid idAfiliado);
        Task<IEnumerable<AfiliadosDocumentacionDTO>> GetDocumentacion(Guid idAfiliado);
       
    }
}