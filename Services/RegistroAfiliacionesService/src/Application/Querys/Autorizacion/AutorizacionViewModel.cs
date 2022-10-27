using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    public class AutorizacionDTO
    {

        public string token { get; set; }
        public List<TitularDTO> Titulares = new List<TitularDTO>();

    }

    public class TitularDTO
    {
        public NombrePropio Apellido { get; set; }
        public string Nombre { get; set; }
        public Guid TitularId { get; set; }
    }
}