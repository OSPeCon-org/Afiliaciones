using OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.SeedWork;
using OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Entities
{
    public interface ITipoMaterialRepository : IRepository<TipoMaterial>
    {
        TipoMaterial Add(TipoMaterial tipoMaterial);
        TipoMaterial Update(TipoMaterial tipoMaterial);

        Task<TipoMaterial> GetByIdAsync(Guid Id);
        Task<TipoMaterial> GetTipoMaterialesByNameAsync(string descripcion);
    }
}