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
    public class DetalleDocumentacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DetalleDocumentacionController> _logger;

        private readonly IDetalleDocumentacionQueries _detalleDocumentacionQueries;

        public DetalleDocumentacionController(
            IMediator mediator,
            ILogger<DetalleDocumentacionController> logger,
            IDetalleDocumentacionQueries detalleDocumentacion)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _detalleDocumentacionQueries = detalleDocumentacion ?? throw new ArgumentNullException(nameof(detalleDocumentacion));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetDetalleDocumentacionAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var detalleDocumentacion = await _detalleDocumentacionQueries.GetDetalleDocumentacionAsync(id);

                return Ok(detalleDocumentacion);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("GetDetalleDocumentacionByPlanParentesco")]
        [HttpGet]
        public async Task<ActionResult> GetDetalleDocumentacionByPlanParentescoAsync(Guid planId, Guid parentescoId, bool discapacidad)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var detalleDocumentacion = await _detalleDocumentacionQueries.GetDetalleDocumentacionByPlanParentescoAsync( planId, parentescoId, discapacidad);
                return Ok(detalleDocumentacion);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var detalleDocumentacion = await _detalleDocumentacionQueries.GetAll();

                return Ok(detalleDocumentacion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> addDetalleDocumentacionsAsync([FromBody] AddDetalleDocumentacionCommand command)
        {

            Guid UID = await _mediator.Send(command);

            return Ok(UID);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> updateDetalleDocumentacionAsync([FromBody] UpdateDetalleDocumentacionCommand command)
        {
            bool commandResult = false;

            commandResult = await _mediator.Send(command);

            return Ok();
        }

    }
}