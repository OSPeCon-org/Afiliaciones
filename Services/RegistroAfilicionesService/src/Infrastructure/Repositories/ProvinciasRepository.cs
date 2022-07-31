using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class ProvinciasRepository
        : IProvinciasRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ProvinciasRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Provincias Add(Provincias provincia)
        {
            return _context.Provincias.Add(provincia).Entity;
        }
        public Provincias Update(Provincias provincia)
        {
            return _context.Provincias.Update(provincia).Entity;
        }

        public async Task<Provincias> GetAsync(Guid id)
        {
            var item = await _context
                                .Provincias
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .Provincias
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<Provincias> GetProvinciasByNameAsync(string descripcion)
        {
            var clasif = await _context
                    .Provincias
                    .FirstOrDefaultAsync(o => o.Descripcion == descripcion);

            return clasif;
        }

        public Task<Provincias> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}