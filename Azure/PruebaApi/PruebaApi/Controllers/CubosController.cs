using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Models;
using PruebaApi.Repositories;
using PruebaApi.Services;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;
        private ServiceBlobs serviceBlobs;

        public CubosController(RepositoryCubos repo, ServiceBlobs serviceBlobs)
        {
            this.repo = repo;
            this.serviceBlobs = serviceBlobs;
        }

        [HttpGet]
        public async Task<IActionResult> GetCubos()
        {
            List<CubosModel> cubos = await this.repo.GetCubosAsync();
            if (cubos.Count == 0)
            {
                return NotFound("No hay cubos");
            }
            else
            {
                foreach (CubosModel cubo in cubos)
                {
                    string urlBlob = this.serviceBlobs.GetBlobUrl("imgscubos", cubo.Imagen);
                    cubo.Imagen = urlBlob;
                }
                return Ok(cubos);
            }
        }

        [HttpGet]
        [Route("[Action]/{marca}")]
        public async Task<IActionResult> GetCubosMarca(string marca)
        {
            List<CubosModel> cubos = await this.repo.GetCubosMarcaAsync(marca);
            if (cubos.Count == 0)
            {
                return NotFound("No hay cubos de esa marca");
            }
            else
            {
                return Ok(cubos);
            }
        }
    }
}
