using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface ITipoDocumentoRepository : IRepository<TipoDocumento>
    {
        TipoDocumento Add(TipoDocumento tipoDocumento);
        TipoDocumento Update(TipoDocumento tipoDocumento);
        Task<TipoDocumento> GetByIdAsync(Guid Id);
        Task<TipoDocumento> GetTipoDocumentoByNameAsync(string descripcion);
    }
}