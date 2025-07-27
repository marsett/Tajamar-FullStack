using Microsoft.AspNetCore.Mvc;
using MvcCoreEmpty.Models;

namespace MvcCoreEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EjemploSection()
        {
            return View();
        }

        public IActionResult VistaPersona()
        {
            Persona persona = new Persona();
            persona.Nombre = "Alumno Core";
            persona.Email = "alumnocore@gmail.com";
            persona.Edad = 25;
            return View(persona);
        }
    }
}
