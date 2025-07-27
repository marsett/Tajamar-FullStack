using ApiAWSSeriesCorrecto.Models;
using ApiAWSSeriesCorrecto.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAWSSeriesCorrecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;
        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> FindSerie(int id)
        {
            return await this.repo.FindSerieAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Serie serie)
        {
            await this.repo.CreateSerieAsync(serie.Nombre, serie.Imagen, serie.Anyo);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Edit(Serie serie)
        {
            await this.repo.UpdateSerieAsync(serie.IdSerie, serie.Nombre, serie.Imagen, serie.Anyo);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.repo.DeleteSerieAsync(id);
            return Ok();
        }
    }
}
