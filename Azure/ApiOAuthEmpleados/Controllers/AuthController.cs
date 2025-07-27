using ApiOAuthEmpleados.Helpers;
using ApiOAuthEmpleados.Models;
using ApiOAuthEmpleados.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiOAuthEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryHospital repo;
        // Cuando generemos el token debemos integrar
        // algunos datos como issuer y demás
        private HelperActionServicesOAuth helper;
        public AuthController(RepositoryHospital repo, HelperActionServicesOAuth helper)
        {
            this.repo = repo;
            this.helper = helper;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            Empleado empleado = await this.repo.
                LogInEmpleadoAsync(model.UserName, int.Parse(model.Password));
            if (empleado == null)
            {
                return Unauthorized();
            }
            else
            {
                // Debemos crear unas credenciales para
                // incluirlas dentro del token y que estarán
                // compuestas por el secret key cifrado y el
                // tipo de cifrado que incluiremos en el token
                SigningCredentials credentials =
                    new SigningCredentials
                    (this.helper.GetKeyToken(),
                    SecurityAlgorithms.HmacSha256);
                // Creamos el objeto model para almacenarlo
                // dentro del token
                EmpleadoModel modelEmp = new EmpleadoModel();
                modelEmp.IdEmpleado = empleado.IdEmpleado;
                modelEmp.Apellido = empleado.Apellido;
                modelEmp.Oficio = empleado.Oficio;
                modelEmp.IdDepartamento = empleado.IdDepartamento;

                // Convertimos a json los datos del empleado
                string jsonEmpleado = JsonConvert.SerializeObject(modelEmp);
                string jsonCifrado = HelperCryptography.EncryptString(jsonEmpleado);
                //if (empleado.Oficio == "ADMINISTRADOR")
                //{
                //    // Creamos un array de claims
                //    Claim[] informacion = new[]
                //    {
                //        new Claim("UserData", jsonEmpleado),
                //        new Claim(ClaimTypes.Role, "PRESIDENTE"),
                //        new Claim(ClaimTypes.Role, "ADMINISTRADOR")
                //    };
                //}
                //else
                //{
                    // Creamos un array de claims
                    Claim[] informacion = new[]
                    {
                        new Claim("UserData", jsonCifrado),
                        new Claim(ClaimTypes.Role, empleado.Oficio)
                    };
                //}

                // El token se genera con una clase y debemos
                // indicar los datos que almacenará en su interior
                JwtSecurityToken token = new JwtSecurityToken
                    (issuer: this.helper.Issuer,
                    audience: this.helper.Audience,
                    claims: informacion,
                    signingCredentials: credentials,
                    expires: DateTime.UtcNow.AddMinutes(20),
                    notBefore: DateTime.UtcNow);
                // Por último, devolvemos la respuesta afirmativa
                // con un objeto que contenga el token (anónimo)
                return Ok(new
                {
                    response = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }
    }
}
