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
    public class EstadosAfiliacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EstadosAfiliacionController> _logger;

        private readonly IEstadosAfiliacionQueries _estadosAfiliacionQueries;

        public EstadosAfiliacionController(
            IMediator mediator,
            ILogger<EstadosAfiliacionController> logger,
            IEstadosAfiliacionQueries estadosAfiliacion)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _estadosAfiliacionQueries = estadosAfiliacion ?? throw new ArgumentNullException(nameof(estadosAfiliacion));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetEstadosAfiliacionAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var estadoAfiliacion = await _estadosAfiliacionQueries.GetEstadosAfiliacionAsync(id);

                return Ok(estadoAfiliacion);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("getByName/{descripcion}")]
        [HttpGet]
        public async Task<ActionResult> GetEstadosAfiliacionByNameAsync(string descripcion)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var estadoAfiliacion = await _estadosAfiliacionQueries.GetEstadosAfiliacionByNameAsync(descripcion);

                return Ok(estadoAfiliacion);
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
                var estadosAfiliacion = await _estadosAfiliacionQueries.GetAll();

                return Ok(estadosAfiliacion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        

    }
}