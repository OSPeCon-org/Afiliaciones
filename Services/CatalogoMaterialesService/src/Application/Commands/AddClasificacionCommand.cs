using MediatR;
using OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Application.Commands
{
    [DataContract]
    public class AddClasificacionCommand : IRequest<Guid>
    {
        [DataMember]
        public string Descripcion { get; set; }

        public AddClasificacionCommand()
        {

        }
        public AddClasificacionCommand(string descripcion)

        {
            Descripcion = descripcion;
        }

    }
}