using AWSApiRepaso2.Models;
using AWSApiRepaso2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSApiRepaso2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private RepositoryPeliculas repo;

        public PeliculasController(RepositoryPeliculas repo) {
            this.repo = repo;
        }

        [HttpGet]
        [Route("GetPeliculas")]
        public async Task<ActionResult<List<Pelicula>>> GetPeliculas() {
            var peliculas = await this.repo.GetPeliculasAsync();
            return Ok(peliculas);
        }

        [HttpGet]
        [Route("FindPelicula/{id}")]
        public async Task<ActionResult<Pelicula>> FindPelicula(int id) {
            var pelicula = await this.repo.FindPeliculaAsync(id);
            if (pelicula == null) {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpGet]
        [Route("GetPeliculasActores/{actor}")]
        public async Task<ActionResult<List<Pelicula>>> GetPeliculasActores(string actor) {
            var peliculas = await this.repo.GetPeliculasActoresAsync(actor);
            if (peliculas == null || !peliculas.Any()) {
                return NotFound();
            }
            return Ok(peliculas);
        }

        [HttpPost]
        [Route("CreatePelicula")]
        public async Task<ActionResult> CreatePelicula([FromBody] Pelicula pelicula) {
            await this.repo.CreatePeliculaAsync(pelicula);
            return Ok();
        }

        [HttpPut]
        [Route("UpdatePelicula")]
        public async Task<ActionResult> UpdatePelicula([FromBody] Pelicula pelicula) {
            var existingPelicula = await this.repo.FindPeliculaAsync(pelicula.IdPelicula);
            if (existingPelicula == null) {
                return NotFound();
            }
            await this.repo.UpdatePeliculaAsync(pelicula);
            return Ok();
        }

        [HttpDelete]
        [Route("DeletePelicula/{id}")]
        public async Task<ActionResult> DeletePelicula(int id) {
            var existingPelicula = await this.repo.FindPeliculaAsync(id);
            if (existingPelicula == null) {
                return NotFound();
            }
            await this.repo.DeletePeliculaAsync(id);
            return Ok();
        }
    }
}
