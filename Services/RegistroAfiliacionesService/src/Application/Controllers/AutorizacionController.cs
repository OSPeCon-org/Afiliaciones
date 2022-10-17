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
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Helper;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.Repositories;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Autorizacion;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.IntegrationEvents;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutorizacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LocalidadesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UsuarioAfiliadosRepository _usuarioAfiliadosRepository;
        private readonly IAfiliadosRepository _afiliadosRepository;
        private readonly AfiliadoCreadoIntegrationEventHandler _afiliadoCreadoIntegrationEventHandler;
        private readonly AppSettings _appSettings;

        public AutorizacionController(
            IMediator mediator,
            ILogger<LocalidadesController> logger,
            IConfiguration configuration,
            UsuarioAfiliadosRepository usuarioAfiliadosRepository,
            IAfiliadosRepository afiliadosRepository,
            AfiliadoCreadoIntegrationEventHandler afiliadoCreadoIntegrationEventHandler,
            AppSettings appSettings)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration;
            _usuarioAfiliadosRepository = usuarioAfiliadosRepository;
            _afiliadosRepository = afiliadosRepository;
            _afiliadoCreadoIntegrationEventHandler = afiliadoCreadoIntegrationEventHandler;
            _appSettings = appSettings;
        }


        [HttpGet]
        public async Task<ActionResult<AutorizacionDTO>> Index(string token)
        {

            //Desencriptar token
            var validationParameters = new TokenValidationParameters();
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("<°|#@bReT353SaM0°|°>"));
            validationParameters.IssuerSigningKey = signingKey;
            validationParameters.ValidateAudience = false;
            validationParameters.ValidateIssuer = false;
            var handler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal;
            try
            {
                principal = handler.ValidateToken(token, validationParameters, out securityToken);

            }

            catch (Exception ex)
            {
                var mensaje = ex.Message;
                return Forbid("No autorizado");
            }




            var tokenHandler = new JwtSecurityTokenHandler();
            /*             var appSettingsSection = _configuration.GetSection("AppSettings");
                        var appSettings = appSettingsSection.Get<AppSettings>();
             */
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var nameId = principal.Identities.First().Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var autenticationMethod = principal.Identities.First().Claims.FirstOrDefault(c => c.Type == ClaimTypes.AuthenticationMethod);
            var email = principal.Identities.First().Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            string rol;
            if (autenticationMethod.Value != "WebApi")
            {
                rol = "afiliado";
            }
            else
            {
                rol = "admin";
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                     new Claim(ClaimTypes.Name, principal.Identity.Name ),
                       new Claim(ClaimTypes.Role, rol ),
                       new Claim(ClaimTypes.NameIdentifier,nameId.Value),
                       new Claim(ClaimTypes.Email, email.Value)
            }),
                Expires = DateTime.UtcNow.AddMinutes(480),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var newToken = tokenHandler.CreateToken(tokenDescriptor);
            AutorizacionDTO retorno = new AutorizacionDTO();
            retorno.token = tokenHandler.WriteToken(newToken);
            var usuarioId = new Guid(nameId.Value);


            var titularesId = _usuarioAfiliadosRepository.GetByUsuarioIdAsync(usuarioId).ToList();
            foreach (UsuarioAfiliados usuarioTitular in titularesId)
            {
                Afiliados afiliado = await _afiliadosRepository.GetAsync(usuarioTitular.AfiliadoId);
                var titular = new TitularDTO();
                titular.Apellido = afiliado.Apellido;
                titular.Nombre = afiliado.Nombre;
                titular.TitularId = usuarioTitular.AfiliadoId;
                retorno.Titulares.Add(titular);
            }

            return Ok(retorno);


        }

        [HttpPost]
        [Route("Accept")]
        public async Task<ActionResult> Accept([FromBody] AcceptUsuarioAfiliadoCommand command)
        {
            var nameId = this.User.Identities.First().Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (nameId.Value == null) throw new ForbiddenException();

            command.UsuarioId = new Guid(nameId.Value);

            await _mediator.Send(command);

            return Ok();
        }
    }
}