using System;
using System.Collections.Generic;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Autorizacion
{
    public class UsuarioAfiliados
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid AfiliadoId { get; set; }
        public bool Activo { get; set; }

        public List<Afiliados> Afiliados { get; set; }


        public UsuarioAfiliados()
        {
        }

    }
}