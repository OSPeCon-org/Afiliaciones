using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IParentescosRepository : IRepository<Parentescos>
    {
        Parentescos Add(Parentescos parentesco);
        Parentescos Update(Parentescos parentesco);
        Task<Parentescos> GetByIdAsync(Guid Id);
        Task<Parentescos> GetParentescosByNameAsync(string descripcion);
    }
}