using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface ILocalidadesRepository : IRepository<Localidades>
    {
        Localidades Add(Localidades plan);
        Localidades Update(Localidades plan);
        Task<Localidades> GetByIdAsync(Guid Id);
        Task<Localidades> GetLocalidadesByNameAsync(string descripcion);
        
    }
}