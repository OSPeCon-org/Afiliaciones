using MediatR;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using OSPeConTI.Afiliaciones.BuildingBlocks.EventBus.Abstractions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents;
using System.IO;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Helper;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class AddAfiliadosDocumentacionCommandHandler : IRequestHandler<AddAfiliadosDocumentacionCommand, Guid>
    {
        private readonly IAfiliadosDocumentacionRepository _afiliadosDocumentacionRepository;
        private readonly IEventBus _eventBus;

        private AppSettings _appSettings;

        public AddAfiliadosDocumentacionCommandHandler(IAfiliadosDocumentacionRepository afiliadosDocumentacionRepository, IEventBus eventBus, AppSettings appSettings)
        {
            _afiliadosDocumentacionRepository = afiliadosDocumentacionRepository;
            _eventBus = eventBus;
            _appSettings = appSettings;
        }

        public async Task<Guid> Handle(AddAfiliadosDocumentacionCommand command, CancellationToken cancellationToken)
        {


            Guid Subfijo = Guid.NewGuid();
            String Nombre = Subfijo.ToString() + "." + command.Tipo;
            string Path = _appSettings.CarpetaDocumenacion;
            String Url = _appSettings.UrlDocumentacion;


            AfiliadosDocumentacion afiliadosDocumentacion = new AfiliadosDocumentacion(command.AfiliadoId, command.DetalleDocumentacionId, Url + Nombre, command.Aprobado);

            _afiliadosDocumentacionRepository.Add(afiliadosDocumentacion);

            byte[] Imagen = Convert.FromBase64String(command.Imagen);
            await _afiliadosDocumentacionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            File.WriteAllBytes(Path + Nombre, Imagen);

            return afiliadosDocumentacion.Id;
        }
    }
}