using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Repositories;
using PruebaApi.Services;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private RepositoryCubos repo;
        private ServiceBlobs serviceBlobs;

        public UsuarioController(RepositoryCubos repo, ServiceBlobs serviceBlobs)
        {
            this.repo = repo;
            this.serviceBlobs = serviceBlobs;
        }

        [HttpPost]
        public async Task<IActionResult> InsertUsuario(string nombre, string email, string pass)
        {
            try
            {
                await this.repo.InsertUsuarioAsync(nombre, email, pass);
                return Ok("Usuario creado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("[Action]")]
        public async Task<IActionResult> GetPerfilUsuario()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "IdUsuario").Value);
            var usuario = await this.repo.GetUsuarioAsync(id);
            if (usuario == null)
            {
                return NotFound("No existe el usuario");
            }
            else
            {
                string urlBlob = this.serviceBlobs.GetBlobUrl("imgsusuarios", usuario.Imagen);
                usuario.Imagen = urlBlob;
                return Ok(usuario);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("[Action]")]
        public async Task<IActionResult> GetPedidosUsuario()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "IdUsuario").Value);
            var pedidos = await this.repo.GetPedidosUsuarioAsync(id);
            return Ok(pedidos);
        }

        [HttpPost]
        [Authorize]
        [Route("[Action]")]
        public async Task<IActionResult> InsertPedido(int idCubo)
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "IdUsuario").Value);
            try
            {
                await this.repo.InsertPedidoUsuario(idCubo, id, DateTime.Now);
                return Ok("Pedido creado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
