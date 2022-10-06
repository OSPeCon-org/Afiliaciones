using Microsoft.EntityFrameworkCore;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Autorizacion;
using System.Collections.Generic;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories
{
    public class UsuarioAfiliadosRepository

    {
        private readonly AfiliacionesContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public UsuarioAfiliadosRepository(AfiliacionesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public UsuarioAfiliados Add(UsuarioAfiliados usuarioAfiliado)
        {
            return _context.UsuarioAfiliados.Add(usuarioAfiliado).Entity;
        }


        public async Task<UsuarioAfiliados> GetByIdAsync(Guid id)
        {
            var item = await _context
                                .UsuarioAfiliados
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (item == null)
            {
                item = _context
                            .UsuarioAfiliados
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return item;
        }

        public IEnumerable<UsuarioAfiliados> GetByUsuarioIdAsync(Guid usuarioId)
        {
            var usuarioAfiliados = _context
                    .UsuarioAfiliados
                    .Where(o => o.UsuarioId == usuarioId);

            return usuarioAfiliados;
        }



    }
}