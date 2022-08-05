using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class AfiliadosDomiciliosRepository
        : IAfiliadosDomiciliosRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public AfiliadosDomiciliosRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public AfiliadosDomicilios Add(AfiliadosDomicilios afiliadosDomicilio)
        {
            return _context.AfiliadosDomicilios.Add(afiliadosDomicilio).Entity;
        }
        public AfiliadosDomicilios Update(AfiliadosDomicilios afiliadosDomicilio)
        {
            return _context.AfiliadosDomicilios.Update(afiliadosDomicilio).Entity;
        }

    

        public async Task<AfiliadosDomicilios> GetByIdAsync (Guid id)
        {
            var clasif = await _context
                    .AfiliadosDomicilios
                    .FirstOrDefaultAsync(o => o.Id == id);

            return clasif;
        }

        public async Task<AfiliadosDomicilios> GetAfiliadosDomiciliosByAfiliadoIdAsync(Guid afiliadoId)
        {
            var ad = await _context
                    .AfiliadosDomicilios
                    .FirstOrDefaultAsync(o => o.AfiliadosId == afiliadoId);

            return ad;
        }

      
    }
}