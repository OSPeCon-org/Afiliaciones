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
    public class AfiliadosDomiciliosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AfiliadosDomiciliosController> _logger;

        private readonly IAfiliadosDomiciliosQueries _afiliadosQueries;

        public AfiliadosDomiciliosController(
            IMediator mediator,
            ILogger<AfiliadosDomiciliosController> logger,
            IAfiliadosDomiciliosQueries afiliados)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _afiliadosQueries = afiliados ?? throw new ArgumentNullException(nameof(afiliados));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetAfiliadosDomiciliosAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var sector = await _afiliadosQueries.GetAfiliadosDomiciliosAsync(id);

                return Ok(sector);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("getByAfiliadoId/{afiliadoId}")]
        [HttpGet]
        public async Task<ActionResult> GetAfiliadosDomiciliosByAfiliadosIdAsync(Guid afiliadoId)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var afiliado = await _afiliadosQueries.GetAfiliadosDomiciliosByAfiliadoIdAsync(afiliadoId);

                return Ok(afiliado);
            }
            catch
            {
                return NotFound();
            }
        }

        

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> addAfiliadosDomiciliossAsync([FromBody] AddAfiliadosDomiciliosCommand command)
        {

            Guid UID = await _mediator.Send(command);

            return Ok(UID);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> updateAfiliadosDomiciliosAsync([FromBody] UpdateAfiliadosDomiciliosCommand command)
        {
            bool commandResult = false;

            commandResult = await _mediator.Send(command);

            return Ok();
        }

    }
}