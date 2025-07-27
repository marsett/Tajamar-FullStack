using ApiCoreCrudDepartamentos.Models;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentosAsync()
        {
            return await this.repo.GetDepartamentosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            return await this.repo.FindDepartamentoAsync(id);
        }

        // Los métodos por defecto de post o put reciben un objeto
        // si queremos enviar parámetros, debemos mapearlos con routing
        [HttpPost]
        public async Task<ActionResult> InsertDepartamento(Departamento departamento)
        {
            await this.repo.InsertDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre,
                departamento.Localidad);
            return Ok();
        }

        // El método por defecto de delete recibe un id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartamento(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre,
                departamento.Localidad);
            return Ok();
        }

        // Podemos personalizar métodos POST, PUT o DELETE a conveniencia
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> PostDepartamento(int id, string nombre, string localidad)
        {
            await this.repo.InsertDepartamentoAsync(id, nombre,
                localidad);
            return Ok();
        }

        // Si lo necesitamos, podemos combinar objetos con parámetros
        // El objeto es el último elemento que se incluye en la
        // petición del método
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> PutDepartamento(int id, Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(id, departamento.Nombre, departamento.Localidad);
            return Ok();
        }
    }
}
