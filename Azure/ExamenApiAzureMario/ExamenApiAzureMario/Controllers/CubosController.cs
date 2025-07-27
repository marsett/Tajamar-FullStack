using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenApiAzureMario.Models;
using ExamenApiAzureMario.Repositories;
using ExamenApiAzureMario.Services;

namespace ExamenApiAzureMario.Controllers
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
            List<Cubo> cubos = await this.repo.GetCubosAsync();

            foreach (Cubo cubo in cubos)
            {
                string url = this.serviceBlobs.GetBlobUrl("cubos", cubo.Imagen);
                cubo.Imagen = url;
            }
            return Ok(cubos);
        }

    }
}
