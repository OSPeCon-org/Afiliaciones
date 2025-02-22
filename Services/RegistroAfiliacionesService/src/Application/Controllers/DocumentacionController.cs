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
    [Authorize]
    public class DocumentacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DocumentacionController> _logger;

        private readonly IDocumentacionQueries _documentacionQueries;

        public DocumentacionController(
            IMediator mediator,
            ILogger<DocumentacionController> logger,
            IDocumentacionQueries documentacion)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _documentacionQueries = documentacion ?? throw new ArgumentNullException(nameof(documentacion));
        }

        [Route("{id}")]
        [HttpGet]

        public async Task<ActionResult> GetDocumentacionAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var documentaci = await _documentacionQueries.GetDocumentacionAsync(id);

                return Ok(documentaci);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("getByName/{descripcion}")]
        [HttpGet]
        public async Task<ActionResult> GetDocumentacionByNameAsync(string descripcion)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var documentaci = await _documentacionQueries.GetDocumentacionByNameAsync(descripcion);

                return Ok(documentaci);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("all")]
        [HttpGet]
        [AllowAnonymousAttribute]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var documentacion = await _documentacionQueries.GetAll();

                return Ok(documentacion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> addDocumentacionsAsync([FromBody] AddDocumentacionCommand command)
        {

            Guid UID = await _mediator.Send(command);

            return Ok(UID);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> updateDocumentacionAsync([FromBody] UpdateDocumentacionCommand command)
        {
            bool commandResult = false;

            commandResult = await _mediator.Send(command);

            return Ok();
        }


    }
}