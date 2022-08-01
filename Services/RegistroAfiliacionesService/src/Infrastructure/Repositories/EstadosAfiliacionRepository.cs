using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class EstadosAfiliacionRepository
        : IEstadosAfiliacionRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public EstadosAfiliacionRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public EstadosAfiliacion Add(EstadosAfiliacion EstadoAfiliacion)
        {
            return _context.EstadosAfiliacion.Add(EstadoAfiliacion).Entity;
        }
        public EstadosAfiliacion Update(EstadosAfiliacion EstadoAfiliacion)
        {
            return _context.EstadosAfiliacion.Update(EstadoAfiliacion).Entity;
        }

        public async Task<EstadosAfiliacion> GetAsync(Guid id)
        {
            var item = await _context
                                .EstadosAfiliacion
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .EstadosAfiliacion
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<EstadosAfiliacion> GetEstadosAfiliacionByNameAsync(string descripcion)
        {
            var clasif = await _context
                    .EstadosAfiliacion
                    .FirstOrDefaultAsync(o => o.Descripcion == descripcion);

            return clasif;
        }

        public Task<EstadosAfiliacion> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}