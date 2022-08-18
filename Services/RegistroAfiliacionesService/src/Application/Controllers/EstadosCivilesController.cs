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
    public class EstadosCivilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EstadosCivilesController> _logger;

        private readonly IEstadosCivilesQueries _estadosCivilesQueries;

        public EstadosCivilesController(
            IMediator mediator,
            ILogger<EstadosCivilesController> logger,
            IEstadosCivilesQueries estadosCiviles)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _estadosCivilesQueries = estadosCiviles ?? throw new ArgumentNullException(nameof(estadosCiviles));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetEstadosCivilesAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var estadoCivil = await _estadosCivilesQueries.GetEstadosCivilesAsync(id);

                return Ok(estadoCivil);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("getByName/{descripcion}")]
        [HttpGet]
        public async Task<ActionResult> GetEstadosCivilesByNameAsync(string descripcion)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var estadoCivil = await _estadosCivilesQueries.GetEstadosCivilesByNameAsync(descripcion);

                return Ok(estadoCivil);
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
                var estadosCiviles = await _estadosCivilesQueries.GetAll();

                return Ok(estadosCiviles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

         [Route("add")]
        [HttpPost]
        public async Task<IActionResult> addEstadosCivilesAsync([FromBody] AddEstadosCivilesCommand command)
        {

            Guid UID = await _mediator.Send(command);

            return Ok(UID);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> updateEstadosCivilesAsync([FromBody] UpdateEstadosCivilesCommand command)
        {
            bool commandResult = false;

            commandResult = await _mediator.Send(command);

            return Ok();
        }

    }
}