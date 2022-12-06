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
using Minio;
using Minio.Exceptions;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands
{
    // Regular CommandHandler
    public class AddAfiliadosDocumentacionCommandHandler : IRequestHandler<AddAfiliadosDocumentacionCommand, Guid>
    {
        private readonly IAfiliadosDocumentacionRepository _afiliadosDocumentacionRepository;
        private readonly IEventBus _eventBus;
        private AppSettings _appSettings;
        private MinioClient _minio;

        public AddAfiliadosDocumentacionCommandHandler(IAfiliadosDocumentacionRepository afiliadosDocumentacionRepository, IEventBus eventBus, AppSettings appSettings, MinioClient minio)
        {
            _afiliadosDocumentacionRepository = afiliadosDocumentacionRepository;
            _eventBus = eventBus;
            _appSettings = appSettings;
            _minio = minio;
        }

        public async Task<Guid> Handle(AddAfiliadosDocumentacionCommand command, CancellationToken cancellationToken)
        {
            string nombre = Guid.NewGuid().ToString() + "." + command.Tipo.Split("/")[1];
            string minioUrl = _appSettings.minioUrl;
            string bucketName = _appSettings.minioBucketName;
            string carpeta = command.AfiliadoId.ToString().ToLower();
            string fileUrl = minioUrl + "/" + carpeta + "/" + nombre;

            AfiliadosDocumentacion afiliadosDocumentacion = new AfiliadosDocumentacion(command.AfiliadoId, command.DetalleDocumentacionId, fileUrl, AfiliadosDocumentacion.EstadosDocumento.EnProceso);

            _afiliadosDocumentacionRepository.Add(afiliadosDocumentacion);

            byte[] imagen = Convert.FromBase64String(command.Imagen);
            await _afiliadosDocumentacionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            Run(_minio, bucketName, carpeta, nombre, command.Tipo, imagen).Wait();

            return afiliadosDocumentacion.Id;
        }

        private async static Task Run(MinioClient minio, string bucketName, string carpeta, string nombre, string tipo, byte[] data)
        {
            var beArgs = new BucketExistsArgs()
                .WithBucket(bucketName);
            bool found = await minio.BucketExistsAsync(beArgs).ConfigureAwait(false);
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(bucketName);
                await minio.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }

            var putObjectArgs = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(carpeta + "/" + nombre)
                .WithObjectSize(data.Length)
                .WithStreamData(new MemoryStream(data))
                .WithContentType(tipo);
            await minio.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
        }
    }
}
