using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcCoreDepartamentosEF.Models;
using MvcCoreDepartamentosEF.Repositories;

namespace MvcCoreDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamento repo;
        public DepartamentosController(RepositoryDepartamento repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int idDepartamento)
        {
            Departamento departamento = await this.repo.FindDepartamentoAsync(idDepartamento);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await this.repo.InsertDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre,
                departamento.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int idDepartamento)
        {
            await this.repo.DeleteDepartamentoAsync(idDepartamento);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int idDepartamento)
        {
            Departamento departamento = await this.repo.FindDepartamentoAsync(idDepartamento);
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre,
                departamento.Localidad);
            return RedirectToAction("Index");
        }
    }
}
