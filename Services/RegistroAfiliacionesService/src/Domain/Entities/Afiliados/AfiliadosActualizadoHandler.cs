using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{

    public class AfiliadosActualizadoHandler : INotificationHandler<AfiliadosActualizadoRequested>
    {
        private readonly IAfiliadosRepository _AfiliadoRepository;
        public AfiliadosActualizadoHandler(IAfiliadosRepository AfiliadoRepository)
        {
            _AfiliadoRepository = AfiliadoRepository;
        }
        public Task Handle(AfiliadosActualizadoRequested notificacion, CancellationToken cancellationToken)
        {

            /*    string nombre = notificacion.Afiliado.Nombre.Trim().ToUpper();
               string apellido = notificacion.Afiliado.Apellido.Trim().ToUpper();
               int documento = notificacion.Afiliado.Documento;
               Guid tipoDocumentoId = notificacion.Afiliado.TipoDocumentoId;
               Guid parentescoId = notificacion.Afiliado.ParentescoId;
               string cuil = notificacion.Afiliado.CUIL;
               DateTime fechaNacimiento = notificacion.Afiliado.FechaNacimiento;
               int planId = notificacion.Afiliado.PlanId;
               Guid nacionalidadId = notificacion.Afiliado.NacionalidadId; */


            Afiliados Afiliado;

            Afiliado = _AfiliadoRepository.GetByDocumentoAsync(notificacion.Afiliado.Documento).GetAwaiter().GetResult();

            if (Afiliado != null)
            {
                if (notificacion.Afiliado.Id == null) throw new System.InvalidOperationException("Ya existe una Afiliado con ese '" + notificacion.Afiliado.Documento + "'");
                if (notificacion.Afiliado.Id != Afiliado.Id) throw new System.InvalidOperationException("Ya existe una Afiliado con ese '" + notificacion.Afiliado.Documento + "'");
            }


            return Task.CompletedTask;
        }
    }

}
