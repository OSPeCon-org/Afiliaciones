using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface INacionalidadesRepository : IRepository<Nacionalidades>
    {
        Nacionalidades Add(Nacionalidades nacionalidad);
        Nacionalidades Update(Nacionalidades nacionalidad);
        Task<Nacionalidades> GetByIdAsync(Guid Id);
        Task<Nacionalidades> GetNacionalidadesByNameAsync(string descripcion);
    }
}