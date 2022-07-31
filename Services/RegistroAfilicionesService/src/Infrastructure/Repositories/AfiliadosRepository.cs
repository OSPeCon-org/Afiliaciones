using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class AfiliadosRepository
        : IAfiliadosRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public AfiliadosRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Afiliados Add(Afiliados afiliados)
        {
            return _context.Afiliados.Add(afiliados).Entity;
        }
        public Afiliados Update(Afiliados afiliados)
        {
            return _context.Afiliados.Update(afiliados).Entity;
        }

        public async Task<Afiliados> GetAsync(Guid id)
        {
            var item = await _context
                                .Afiliados
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .Afiliados
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<Afiliados> GetByDocumentoAsync(int documento)
        {
            var clasif = await _context
                    .Afiliados
                    .FirstOrDefaultAsync(o => o.Documento == documento);

            return clasif;
        }

    }
}