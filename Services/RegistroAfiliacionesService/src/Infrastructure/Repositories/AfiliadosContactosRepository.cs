using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class AfiliadosContactosRepository
        : IAfiliadosContactosRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public AfiliadosContactosRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public AfiliadosContactos Add(AfiliadosContactos afiliadosContacto)
        {
            return _context.AfiliadosContactos.Add(afiliadosContacto).Entity;
        }
        public AfiliadosContactos Update(AfiliadosContactos afiliadosContacto)
        {
            return _context.AfiliadosContactos.Update(afiliadosContacto).Entity;
        }

    

        public async Task<AfiliadosContactos> GetByIdAsync (Guid id)
        {
            var clasif = await _context
                    .AfiliadosContactos
                    .FirstOrDefaultAsync(o => o.Id == id);

            return clasif;
        }

        public async Task<AfiliadosContactos> GetAfiliadosContactosByAfiliadoIdAsync(Guid afiliadoId)
        {
            var ad = await _context
                    .AfiliadosContactos
                    .FirstOrDefaultAsync(o => o.AfiliadosId == afiliadoId);

            return ad;
        }

      
    }
}