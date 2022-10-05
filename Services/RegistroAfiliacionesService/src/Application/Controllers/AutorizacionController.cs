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

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutorizacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LocalidadesController> _logger;
        private readonly IConfiguration _configuration;

        public AutorizacionController(
            IMediator mediator,
            ILogger<LocalidadesController> logger,
            IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration;
        }


        [HttpGet]
        public ActionResult Index(string token)
        {
            try
            {

                //Desencriptar token
                var validationParameters = new TokenValidationParameters();
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("<°|#@bReT353SaM0°|°>"));
                validationParameters.IssuerSigningKey= signingKey;
                validationParameters.ValidateAudience = false;
                validationParameters.ValidateIssuer = false;
                var handler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                ClaimsPrincipal principal ;
                try{
                    principal = handler.ValidateToken(token, validationParameters, out securityToken);
                    
                }

                catch (Exception ex){
                    var mensaje = ex.Message;
                    return Forbid("No autorizado");
                }

                
                

                var tokenHandler = new JwtSecurityTokenHandler();
                var appSettingsSection = _configuration.GetSection("AppSettings");                
                var appSettings = appSettingsSection.Get<AppSettings>();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                
                var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Name, principal.Identity.Name ),
                       new Claim(ClaimTypes.Role, "Admin" )

                }),
                Expires = DateTime.UtcNow.AddMinutes(90),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
                 var newToken = tokenHandler.CreateToken(tokenDescriptor);
            
              return Ok(tokenHandler.WriteToken(newToken));

            }
            catch
            {
                return NotFound();
            }
        }


      
        

    }
}