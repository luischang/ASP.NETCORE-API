using M5_NETCORE.CORE.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace M5_NETCORE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Autenticacion(UserAuth userAuth)
        {
            if (EsUsuarioValido(userAuth))
            {
                var token = GenerarToken();
                return Ok(new { token });
            }
            return NotFound();
        }

        private string GenerarToken()
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            var claims = new[] {
                new Claim(ClaimTypes.Name,"Luis Chang"),
                new Claim(ClaimTypes.Email,"luis.chang@qboinstitute.com"),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var payload = new JwtPayload(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(5)
                );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);        
        }




        private bool EsUsuarioValido(UserAuth userAuth)
        {
            //Validar si el usuario y pwd existe en nuestra BD (Service , Repository)
            return true;        
        }







    }
}
