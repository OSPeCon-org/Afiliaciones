using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IEstadosCivilesRepository : IRepository<EstadosCiviles>
    {
        EstadosCiviles Add(EstadosCiviles estadoCivil);
        EstadosCiviles Update(EstadosCiviles estadoCivil);
        Task<EstadosCiviles> GetByIdAsync(Guid Id);
        Task<EstadosCiviles> GetEstadosCivilesByNameAsync(string descripcion);
    }
}