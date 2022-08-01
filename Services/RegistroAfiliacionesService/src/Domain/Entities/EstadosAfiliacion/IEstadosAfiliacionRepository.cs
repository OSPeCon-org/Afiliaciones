using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IEstadosAfiliacionRepository : IRepository<EstadosAfiliacion>
    {
        EstadosAfiliacion Add(EstadosAfiliacion estadoAfiliacion);
        EstadosAfiliacion Update(EstadosAfiliacion estadoAfiliacion);
        Task<EstadosAfiliacion> GetByIdAsync(Guid Id);
        Task<EstadosAfiliacion> GetEstadosAfiliacionByNameAsync(string descripcion);
    }
}