using ApiPersonajesSeriesMario.Models;
using ApiPersonajesSeriesMario.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesSeriesMario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesSeriesController : ControllerBase
    {
        private readonly RepositoryPersonajesSeries repo;
        public PersonajesSeriesController(RepositoryPersonajesSeries repo)
        {
            this.repo = repo;
        }

        [HttpGet("Personajes")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpPut("UpdatePersonajeSerie/{idpersonaje}/{idserie}")]
        public async Task<ActionResult> UpdatePersonajeSerie(int idpersonaje, int idserie)
        {
            var personaje = await this.repo.FindPersonajeAsync(idpersonaje);
            await this.repo.UpdatePersonajeSerieAsync(idpersonaje, idserie);
            return Ok();
        }

        [HttpGet("Series")]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> GetSerie(int id)
        {
            var serie = await this.repo.FindSerieAsync(id);
            return serie;
        }

        [HttpGet("PersonajesSerie/{idserie}")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesSerie(int idserie)
        {
            return await this.repo.GetPersonajesPorSerieAsync(idserie);
        }

        [HttpGet("MultiplesPersonajesSerie")]
        public async Task<ActionResult<List<Personaje>>> GetMultiplesPersonajesSerie([FromQuery] List<int> idsseries)
        {
            return await this.repo.GetPersonajesPorMultiplesSeriesAsync(idsseries);
        }
    }
}
