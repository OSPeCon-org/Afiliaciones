using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class DetalleDocumentacionRepository
        : IDetalleDocumentacionRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public DetalleDocumentacionRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DetalleDocumentacion Add(DetalleDocumentacion detalleDocumentacion)
        {
            return _context.DetalleDocumentacion.Add(detalleDocumentacion).Entity;
        }
        public DetalleDocumentacion Update(DetalleDocumentacion detalleDocumentacion)
        {
            return _context.DetalleDocumentacion.Update(detalleDocumentacion).Entity;
        }

        public async Task<DetalleDocumentacion> GetAsync(Guid id)
        {
            var item = await _context
                                .DetalleDocumentacion
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .DetalleDocumentacion
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        

        public Task<DetalleDocumentacion> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}