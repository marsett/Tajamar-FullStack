using Microsoft.AspNetCore.Mvc;
using NetCoreLinqToSqlInjection.Models;
using NetCoreLinqToSqlInjection.Repositories;

namespace NetCoreLinqToSqlInjection.Controllers
{
    public class DoctoresController : Controller
    {
        IRepositoryDoctores repo;

        public DoctoresController(IRepositoryDoctores repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doc)
        {
            this.repo.InsertDoctor(doc.IdDoctor, doc.Apellido,
                doc.Especialidad, doc.Salario, doc.IdHospital);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int iddoctor)
        {
            this.repo.DeleteDoctor(iddoctor);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int idDoctor)
        {
            Doctor doctor = this.repo.FindDoctor(idDoctor);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            this.repo.UpdateDoctor(doctor.IdDoctor,
                doctor.Apellido, doctor.Especialidad, doctor.Salario,
                doctor.IdHospital);
            return RedirectToAction("Index");
        }

        public IActionResult BuscarDoctor()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult BuscarDoctor(string especialidad)
        {
            List<Doctor> filtro = this.repo.GetDoctorPorEspecialidad(especialidad);
            return View(filtro);
        }
    }
}
