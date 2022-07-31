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
    public class ProvinciasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProvinciasController> _logger;

        private readonly IProvinciasQueries _provinciasQueries;

        public ProvinciasController(
            IMediator mediator,
            ILogger<ProvinciasController> logger,
            IProvinciasQueries provincias)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _provinciasQueries = provincias ?? throw new ArgumentNullException(nameof(provincias));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetProvinciasAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var provincia = await _provinciasQueries.GetProvinciasAsync(id);

                return Ok(provincia);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("getByName/{descripcion}")]
        [HttpGet]
        public async Task<ActionResult> GetProvinciasByNameAsync(string descripcion)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var provincia = await _provinciasQueries.GetProvinciasByNameAsync(descripcion);

                return Ok(provincia);
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
                var provincias = await _provinciasQueries.GetAll();

                return Ok(provincias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        

    }
}