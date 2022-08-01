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
    public class ParentescosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ParentescosController> _logger;

        private readonly IParentescosQueries _parentescosQueries;

        public ParentescosController(
            IMediator mediator,
            ILogger<ParentescosController> logger,
            IParentescosQueries parentescos)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _parentescosQueries = parentescos ?? throw new ArgumentNullException(nameof(parentescos));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetParentescosAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var parentesco = await _parentescosQueries.GetParentescosAsync(id);

                return Ok(parentesco);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("getByName/{descripcion}")]
        [HttpGet]
        public async Task<ActionResult> GetParentescosByNameAsync(string descripcion)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var parentesco = await _parentescosQueries.GetParentescosByNameAsync(descripcion);

                return Ok(parentesco);
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
                var parentescos = await _parentescosQueries.GetAll();

                return Ok(parentescos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        

    }
}