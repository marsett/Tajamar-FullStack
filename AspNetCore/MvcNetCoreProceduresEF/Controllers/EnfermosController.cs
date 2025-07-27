using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcNetCoreProceduresEF.Models;
using MvcNetCoreProceduresEF.Repositories;

namespace MvcNetCoreProceduresEF.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repo;

        public EnfermosController(RepositoryEnfermos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Enfermo> enfermos = await this.repo.GetEnfermosAsync();
            return View(enfermos);
        }

        public async Task<IActionResult> Details(string inscripcion)
        {
            Enfermo enfermo = await this.repo.FindEnfermoAsync(inscripcion);
            return View(enfermo);
        }

        public IActionResult Delete(string inscripcion)
        {
            this.repo.DeleteEnfermoRawAsync(inscripcion);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Enfermo enfermo)
        {
            await this.repo.InsertEnfermoAsync(enfermo.Apellido, enfermo.Direccion,
                enfermo.FechaNacimiento, enfermo.Genero);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DoctoresEspecialidad()
        {
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            List<Doctor> doctores = await this.repo.GetDoctoresAsync();
            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> DoctoresEspecialidad(string especialidad, int salario)
        {
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            await this.repo.UpdateSalarioDoctorAsync(especialidad, salario);
            List<Doctor> doctores = await this.repo.GetDoctoresAsync();
            doctores = doctores.Where(d => d.Especialidad == especialidad).ToList();
            return View(doctores);
        }
    }
}
