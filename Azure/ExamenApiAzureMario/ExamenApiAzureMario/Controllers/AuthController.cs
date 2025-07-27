using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ExamenApiAzureMario.Helpers;
using ExamenApiAzureMario.Models;
using ExamenApiAzureMario.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExamenApiAzureMario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly HelperActionServicesOAuth helper;
        public readonly RepositoryCubos repo;

        public AuthController(HelperActionServicesOAuth helper, RepositoryCubos repo)
        {
            this.helper = helper;
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(Login model)
        {
            Usuario usuario = await this.repo.IsUserValid(model.Email, model.Password);

            if (usuario == null)
            {
                return Unauthorized();
            }

            SigningCredentials credentials = new 
                SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256);

            string userjson = JsonConvert.SerializeObject(usuario);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim("IdUsuario", usuario.IdUsuario.ToString()),
                new Claim("Email", usuario.Email)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                issuer: this.helper.Issuer,
                audience: this.helper.Audience,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddMinutes(30),
                notBefore: DateTime.UtcNow
            );

            return Ok(new
            {
                response = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
