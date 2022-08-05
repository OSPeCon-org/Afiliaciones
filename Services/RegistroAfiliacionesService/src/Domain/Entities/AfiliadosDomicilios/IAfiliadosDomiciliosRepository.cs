using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{
    public interface IAfiliadosDomiciliosRepository : IRepository<AfiliadosDomicilios>
    {
        AfiliadosDomicilios Add(AfiliadosDomicilios afiliadosDomicilio);
        AfiliadosDomicilios Update(AfiliadosDomicilios afiliadosDomicilio);
        Task<AfiliadosDomicilios> GetByIdAsync(Guid Id);
        Task<AfiliadosDomicilios> GetAfiliadosDomiciliosByAfiliadoIdAsync(Guid afiliadoId);
    }
}