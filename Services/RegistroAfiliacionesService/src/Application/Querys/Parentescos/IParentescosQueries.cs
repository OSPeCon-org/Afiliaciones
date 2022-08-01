namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    

    public interface IParentescosQueries
    {
        Task<ParentescosDTO> GetParentescosAsync(Guid id);
        Task<IEnumerable<ParentescosDTO>> GetParentescosByNameAsync(string descripcion);
        Task<IEnumerable<ParentescosDTO>> GetAll();

    }
}