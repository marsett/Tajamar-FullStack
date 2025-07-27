using Microsoft.AspNetCore.Mvc;
using MvcNetCoreAWSPostgreEC2.Models;
using MvcNetCoreAWSPostgreEC2.Repositories;

namespace MvcNetCoreAWSPostgreEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryHospitales repo;
        public DepartamentosController(RepositoryHospitales repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }
        public async Task<IActionResult> Details(int id)
        {
            Departamento departamento = await this.repo.FindDepartamentoAsync(id);
            return View(departamento);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await this.repo.InsertDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }
    }
}
