using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class PlanesRepository
        : IPlanesRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public PlanesRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Planes Add(Planes plan)
        {
            return _context.Planes.Add(plan).Entity;
        }
        public Planes Update(Planes plan)
        {
            return _context.Planes.Update(plan).Entity;
        }

        public async Task<Planes> GetAsync(Guid id)
        {
            var item = await _context
                                .Planes
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .Planes
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<Planes> GetPlanesByNameAsync(string descripcion)
        {
            var clasif = await _context
                    .Planes
                    .FirstOrDefaultAsync(o => o.Descripcion == descripcion);

            return clasif;
        }

        public Task<Planes> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}