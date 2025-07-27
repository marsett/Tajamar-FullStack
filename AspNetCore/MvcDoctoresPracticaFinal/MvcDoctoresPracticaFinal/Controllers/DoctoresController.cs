using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcDoctoresPracticaFinal.Models;
using MvcDoctoresPracticaFinal.Repositories;

namespace MvcDoctoresPracticaFinal.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctores();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult Detalles(int doctorno)
        {
            Doctor doctor = this.repo.FindDoctor(doctorno);
            return View(doctor);
        }

        public IActionResult BuscarDoctor()
        {
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            return View();
        }

        [HttpPost]
        public IActionResult BuscarDoctor(string especialidad)
        {
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            List<Doctor> filtro = this.repo.GetDoctorPorEspecialidad(especialidad);
            return View(filtro);
        }

        public IActionResult Eliminar(int doctorno)
        {
            this.repo.EliminarDoctor(doctorno);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int doctorno)
        {
            Doctor doctor = this.repo.FindDoctor(doctorno);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Doctor doctor)
        {
            this.repo.UpdateDoctor(doctor);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            this.repo.InsertDoctor(doctor);
            return RedirectToAction("Index");
        }

    }
}
