using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class ParentescosRepository
        : IParentescosRepository
    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ParentescosRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Parentescos Add(Parentescos parentesco)
        {
            return _context.Parentescos.Add(parentesco).Entity;
        }
        public Parentescos Update(Parentescos parentesco)
        {
            return _context.Parentescos.Update(parentesco).Entity;
        }

        public async Task<Parentescos> GetAsync(Guid id)
        {
            var item = await _context
                                .Parentescos
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .Parentescos
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public async Task<Parentescos> GetParentescosByNameAsync(string descripcion)
        {
            var clasif = await _context
                    .Parentescos
                    .FirstOrDefaultAsync(o => o.Descripcion == descripcion);

            return clasif;
        }

        public Task<Parentescos> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}