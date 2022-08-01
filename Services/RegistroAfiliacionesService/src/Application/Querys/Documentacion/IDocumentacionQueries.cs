namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IDocumentacionQueries
    {
        Task<DocumentacionDTO> GetDocumentacionAsync(Guid id);
        Task<IEnumerable<DocumentacionDTO>> GetDocumentacionByNameAsync(string descripcion);
        Task<IEnumerable<DocumentacionDTO>> GetAll();

    }
}