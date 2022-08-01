using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class EstadosCivilesRepository
        : IEstadosCivilesRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public EstadosCivilesRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public EstadosCiviles Add(EstadosCiviles estadosCivil)
        {
            return _context.EstadosCiviles.Add(estadosCivil).Entity;
        }
        public EstadosCiviles Update(EstadosCiviles estadosCivil)
        {
            return _context.EstadosCiviles.Update(estadosCivil).Entity;
        }

        public async Task<EstadosCiviles> GetAsync(Guid id)
        {
            var item = await _context
                                .EstadosCiviles
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .EstadosCiviles
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<EstadosCiviles> GetEstadosCivilesByNameAsync(string descripcion)
        {
            var clasif = await _context
                    .EstadosCiviles
                    .FirstOrDefaultAsync(o => o.Descripcion == descripcion);

            return clasif;
        }

        public Task<EstadosCiviles> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}