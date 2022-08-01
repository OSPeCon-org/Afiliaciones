using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IDocumentacionRepository : IRepository<Documentacion>
    {
        Documentacion Add(Documentacion documentacion);
        Documentacion Update(Documentacion documentacion);
        Task<Documentacion> GetByIdAsync(Guid Id);
        Task<Documentacion> GetDocumentacionByNameAsync(string descripcion);
    }
}