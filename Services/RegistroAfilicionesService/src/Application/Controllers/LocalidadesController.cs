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
    public class LocalidadesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LocalidadesController> _logger;

        private readonly ILocalidadesQueries _localidadesQueries;

        public LocalidadesController(
            IMediator mediator,
            ILogger<LocalidadesController> logger,
            ILocalidadesQueries localidades)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _localidadesQueries = localidades ?? throw new ArgumentNullException(nameof(localidades));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetLocalidadesAsync(Guid id)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var localidad = await _localidadesQueries.GetLocalidadesAsync(id);

                return Ok(localidad);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("getByName/{descripcion}")]
        [HttpGet]
        public async Task<ActionResult> GetLocalidadesByNameAsync(string descripcion)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var localidad = await _localidadesQueries.GetLocalidadesByNameAsync(descripcion);

                return Ok(localidad);
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
                var localidades = await _localidadesQueries.GetAll();

                return Ok(localidades);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

         [Route("getByProvincia/{provinciaId}")]
        [HttpGet]
        public async Task<ActionResult> GetLocalidadesByProvinciaAsync(Guid provinciaId)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var localidades = await _localidadesQueries.GetLocalidadesByProvincia(provinciaId);

                return Ok(localidades);
            }
            catch
            {
                return NotFound();
            }
        }

        

    }
}