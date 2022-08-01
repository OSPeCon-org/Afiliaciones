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
    public class NacionalidadesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NacionalidadesController> _logger;

        private readonly INacionalidadesQueries _nacionalidadesQueries;

        public NacionalidadesController(
            IMediator mediator,
            ILogger<NacionalidadesController> logger,
            INacionalidadesQueries nacionalidades)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _nacionalidadesQueries = nacionalidades ?? throw new ArgumentNullException(nameof(nacionalidades));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetNacionalidadesAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var nacionalidad = await _nacionalidadesQueries.GetNacionalidadesAsync(id);

                return Ok(nacionalidad);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("getByName/{descripcion}")]
        [HttpGet]
        public async Task<ActionResult> GetNacionalidadesByNameAsync(string descripcion)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var nacionalidad = await _nacionalidadesQueries.GetNacionalidadesByNameAsync(descripcion);

                return Ok(nacionalidad);
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
                var nacionalidades = await _nacionalidadesQueries.GetAll();

                return Ok(nacionalidades);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        

    }
}