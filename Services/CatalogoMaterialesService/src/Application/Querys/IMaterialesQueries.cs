namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Entities;

    public interface IMaterialesQueries
    {
        Task<MaterialesDTO> GetMaterialesAsync(int codigo);
        Task<IEnumerable<MaterialesDTO>> GetMaterialesByNameAsync(string nombre);
        Task<IEnumerable<MaterialesDTO>> GetAll();
        Task<IEnumerable<MaterialesDTO>> GetMaterialeByDescripcionesCombinadasAsync(string descripcion);


    }
}