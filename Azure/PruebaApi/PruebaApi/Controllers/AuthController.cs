using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PruebaApi.Helpers;
using PruebaApi.Models;
using PruebaApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        HelperActionServicesOAuth helper;
        RepositoryCubos repo;

        public AuthController(HelperActionServicesOAuth helper, RepositoryCubos repo)
        {
            this.helper = helper;
            this.repo = repo;
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            UsuariosCuboModel usuario = await this.repo.ValidarUsuario(model.Email, model.Password);

            if (usuario == null)
            {
                return Unauthorized();
            }

            SigningCredentials credentials = new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256);
            string jsonUsuario = JsonConvert.SerializeObject(usuario);

            Claim[] info = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim("IdUsuario", usuario.IdUsuario.ToString()),
                new Claim("Email", usuario.Email)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: info,
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
