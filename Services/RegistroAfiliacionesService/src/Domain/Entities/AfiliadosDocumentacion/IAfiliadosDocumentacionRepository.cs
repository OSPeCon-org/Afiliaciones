using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IAfiliadosDocumentacionRepository : IRepository<AfiliadosDocumentacion>
    {
        AfiliadosDocumentacion Add(AfiliadosDocumentacion afiliadoDocumentacion);
        AfiliadosDocumentacion Update(AfiliadosDocumentacion afiliadoDocumentacion);
        Task<AfiliadosDocumentacion> GetByIdAsync(Guid Id);
        Task<AfiliadosDocumentacion> GetAfiliadosDocumentacionByAfiliadoIdAsync(Guid afiliadoId);
    }
}