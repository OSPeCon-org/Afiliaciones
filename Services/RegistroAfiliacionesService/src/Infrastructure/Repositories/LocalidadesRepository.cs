using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class LocalidadesRepository
        : ILocalidadesRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public LocalidadesRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Localidades Add(Localidades localidad)
        {
            return _context.Localidades.Add(localidad).Entity;
        }
        public Localidades Update(Localidades localidad)
        {
            return _context.Localidades.Update(localidad).Entity;
        }

        public async Task<Localidades> GetAsync(Guid id)
        {
            var item = await _context
                                .Localidades
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .Localidades
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<Localidades> GetLocalidadesByNameAsync(string descripcion)
        {
            var clasif = await _context
                    .Localidades
                    .FirstOrDefaultAsync(o => o.Descripcion == descripcion);

            return clasif;
        }

        public Task<Localidades> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Localidades> GetLocalidadesByProvinciaAsync(Guid provinciaId)
        {
            throw new NotImplementedException();
        }

    }
}