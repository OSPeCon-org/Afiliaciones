using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IPlanesRepository : IRepository<Planes>
    {
        Planes Add(Planes plan);
        Planes Update(Planes plan);
        Task<Planes> GetByIdAsync(Guid Id);
        Task<Planes> GetPlanesByNameAsync(string descripcion);
    }
}