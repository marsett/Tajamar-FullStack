using ApiPrueba.Models;
using ApiPrueba.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private RepositoryArtistas repo;

        public MusicaController(RepositoryArtistas repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Artista>>>
            GetArtistas()
        {
            return await this.repo.GetArtistasAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>>
            FindArtista(int id)
        {
            return await this.repo.FindArtistaAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertArtista
            (Artista artista)
        {
            await this.repo.InsertArtistaAsync
                (artista.IdArtista
                , artista.Nombre, artista.CancionFavorita, artista.Edad, artista.Pais);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtista(int id)
        {
            await this.repo.DeleteArtistaAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateArtista
            (Artista artista)
        {
            await this.repo.UpdateArtistaAsync
                (artista.IdArtista
                , artista.Nombre, artista.CancionFavorita, artista.Edad, artista.Pais);
            return Ok();
        }

        [HttpPost]
        [Route("[action]/{id}/{nombre}/{cancion}/{edad}/{pais}")]
        public async Task<ActionResult>
            PostDepartamento(int id, string nombre, string cancion, int edad, string pais)
        {
            await this.repo.InsertArtistaAsync
                (id, nombre, cancion, edad, pais);
            return Ok();
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult>
            PutDepartamento(int id, Artista artista)
        {
            await this.repo.UpdateArtistaAsync(id
                , artista.Nombre, artista.CancionFavorita, artista.Edad, artista.Pais);
            return Ok();
        }
    }
}
