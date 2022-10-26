using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IAfiliadosContactosRepository : IRepository<AfiliadosContactos>
    {
        AfiliadosContactos Add(AfiliadosContactos afiliadosContacto);
        AfiliadosContactos Update(AfiliadosContactos afiliadosContacto);
        Task<AfiliadosContactos> GetByIdAsync(Guid Id);
        Task<AfiliadosContactos> GetAfiliadosContactosByAfiliadoIdAsync(Guid afiliadoId);
    }
}