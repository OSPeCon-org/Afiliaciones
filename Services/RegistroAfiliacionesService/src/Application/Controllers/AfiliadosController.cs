using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Commands;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Autorizacion;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AfiliadosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AfiliadosController> _logger;

        private readonly IAfiliadosQueries _afiliadosQueries;
        private readonly UsuarioAfiliadosRepository _usuarioAfiliadosRepository;




        public AfiliadosController(
            IMediator mediator,
            ILogger<AfiliadosController> logger,
            IAfiliadosQueries afiliados,
            UsuarioAfiliadosRepository usuarioAfiliadosRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _afiliadosQueries = afiliados ?? throw new ArgumentNullException(nameof(afiliados));
            _usuarioAfiliadosRepository = usuarioAfiliadosRepository;

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetAfiliadosAsync(Guid id)
        {
            var afiliado = await _afiliadosQueries.GetAfiliadosAsync(id);

            return Ok(afiliado);
        }


        [Route("getByName/{nombre}")]
        [HttpGet]
        public async Task<ActionResult> GetAfiliadosByNameAsync(string nombre)
        {


            var afiliados = await _afiliadosQueries.GetAfiliadosByNameAsync(nombre);

            return Ok(afiliados);


        }

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            //try
            //{
            //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
            //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
            var afiliados = await _afiliadosQueries.GetAll();

            return Ok(afiliados);
        }


        [Route("actualizar")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> actualizarAfiliadosAsync([FromBody] ActualizarAfiliadosCommand command)
        {
            Guid commandResult = Guid.Empty;
            var nameId = this.User.Identities.First().Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            command.UsuaroId = new Guid(nameId.Value);

            commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }

        [Route("grupoFamiliar")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> grupoFamiliar(Guid titularId)
        {

            var grupoFamiliar = await _afiliadosQueries.GetGrupoFamiliar(titularId);
            return Ok(grupoFamiliar);

        }


        [Route("getByCuil/{cuil}")]
        [HttpGet]
        public async Task<ActionResult> GetAfiliadosByCuilAsync(string cuil)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var afiliado = await _afiliadosQueries.GetAfiliadosByCuilAsync(cuil);

                return Ok(afiliado);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("aprobar/{id}")]
        [HttpGet]
        public async Task<bool> Aprobar(Guid id)
        {
            try
            {
                AprobarAfiliadosCommand command = new AprobarAfiliadosCommand();
                command.Id = id;
                bool commandResult = await _mediator.Send(command);
                return commandResult;
            }
            catch
            {
                return false;
            }
        }

        [Route("rechazar/{id}")]
        [HttpGet]
        public async Task<bool> Rechazar(Guid id)
        {
            try
            {
                RechazarAfiliadosCommand command = new RechazarAfiliadosCommand();
                command.Id = id;
                bool commandResult = await _mediator.Send(command);
                return commandResult;
            }
            catch
            {
                return false;
            }
        }

        [Route("pendientes")]
        [HttpGet]
        public async Task<ActionResult> GetPendientes()
        {
            //try
            //{
            //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
            //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
            var afiliados = await _afiliadosQueries.GetPendientes();
            return Ok(afiliados);
        }
    }
}