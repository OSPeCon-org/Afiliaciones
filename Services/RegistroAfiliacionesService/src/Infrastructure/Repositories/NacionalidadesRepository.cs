using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class NacionalidadesRepository
        : INacionalidadesRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public NacionalidadesRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Nacionalidades Add(Nacionalidades nacionalidad)
        {
            return _context.Nacionalidades.Add(nacionalidad).Entity;
        }
        public Nacionalidades Update(Nacionalidades nacionalidad)
        {
            return _context.Nacionalidades.Update(nacionalidad).Entity;
        }

        public async Task<Nacionalidades> GetAsync(Guid id)
        {
            var item = await _context
                                .Nacionalidades
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .Nacionalidades
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<Nacionalidades> GetNacionalidadesByNameAsync(string descripcion)
        {
            var clasif = await _context
                    .Nacionalidades
                    .FirstOrDefaultAsync(o => o.Descripcion == descripcion);

            return clasif;
        }

        public Task<Nacionalidades> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}