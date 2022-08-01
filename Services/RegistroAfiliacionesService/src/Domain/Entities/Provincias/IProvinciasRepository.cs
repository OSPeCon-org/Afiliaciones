using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IProvinciasRepository : IRepository<Provincias>
    {
        Provincias Add(Provincias provincia);
        Provincias Update(Provincias provincia);
        Task<Provincias> GetByIdAsync(Guid Id);
        Task<Provincias> GetProvinciasByNameAsync(string descripcion);
    }
}