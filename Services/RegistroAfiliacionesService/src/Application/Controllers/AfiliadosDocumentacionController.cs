using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AfiliadosDocumentacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AfiliadosDocumentacionController> _logger;

        private readonly IAfiliadosDocumentacionQueries _afiliadosDocumentacionQueries;

        public AfiliadosDocumentacionController(
            IMediator mediator,
            ILogger<AfiliadosDocumentacionController> logger,
            IAfiliadosDocumentacionQueries afiliados)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _afiliadosDocumentacionQueries = afiliados ?? throw new ArgumentNullException(nameof(afiliados));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetAfiliadosDocumentacionAsync(Guid id)
        {

            var documento = await _afiliadosDocumentacionQueries.GetByIdAsync(id);

            return Ok(documento);

        }


        [Route("getByAfiliadoId/{afiliadoId}")]
        [HttpGet]
        public async Task<ActionResult> GetAfiliadosDocumentacionByAfiliadosId(Guid afiliadoId)
        {


            var documentos = await _afiliadosDocumentacionQueries.GetByAfiliadoIdAsync(afiliadoId);

            return Ok(documentos);

        }


        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> addAfiliadosDocumentacionsAsync([FromBody] AddAfiliadosDocumentacionCommand command)
        {

            Guid UID = await _mediator.Send(command);

            return Ok(UID);
        }



    }
}