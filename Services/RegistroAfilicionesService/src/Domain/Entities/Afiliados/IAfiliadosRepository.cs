using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IAfiliadosRepository : IRepository<Afiliados>
    {
        Afiliados Add(Afiliados afiliado);
        Afiliados Update(Afiliados afiliados);
        Task<Afiliados> GetAsync(Guid Id);
        Task<Afiliados> GetByDocumentoAsync(int documento);
    }
}