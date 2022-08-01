using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class DocumentacionRepository
        : IDocumentacionRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public DocumentacionRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Documentacion Add(Documentacion documentacion)
        {
            return _context.Documentacion.Add(documentacion).Entity;
        }
        public Documentacion Update(Documentacion documentacion)
        {
            return _context.Documentacion.Update(documentacion).Entity;
        }

        public async Task<Documentacion> GetAsync(Guid id)
        {
            var item = await _context
                                .Documentacion
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .Documentacion
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<Documentacion> GetDocumentacionByNameAsync(string descripcion)
        {
            var clasif = await _context
                    .Documentacion
                    .FirstOrDefaultAsync(o => o.Descripcion == descripcion);

            return clasif;
        }

        public Task<Documentacion> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}