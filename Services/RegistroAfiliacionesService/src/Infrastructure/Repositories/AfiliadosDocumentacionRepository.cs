using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class AfiliadosDocumentacionRepository
        : IAfiliadosDocumentacionRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public AfiliadosDocumentacionRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public AfiliadosDocumentacion Add(AfiliadosDocumentacion afiliadoDocumentacion)
        {
            return _context.AfiliadosDocumentacion.Add(afiliadoDocumentacion).Entity;
        }
        public AfiliadosDocumentacion Update(AfiliadosDocumentacion afiliadoDocumentacion)
        {
            return _context.AfiliadosDocumentacion.Update(afiliadoDocumentacion).Entity;
        }

    

        public async Task<AfiliadosDocumentacion> GetByIdAsync (Guid id)
        {
            var clasif = await _context
                    .AfiliadosDocumentacion
                    .FirstOrDefaultAsync(o => o.Id == id);

            return clasif;
        }

        public async Task<AfiliadosDocumentacion> GetAfiliadosDocumentacionByAfiliadoIdAsync(Guid afiliadoId)
        {
            var ad = await _context
                    .AfiliadosDocumentacion
                    .FirstOrDefaultAsync(o => o.AfiliadosId == afiliadoId);

            return ad;
        }

      
    }
}