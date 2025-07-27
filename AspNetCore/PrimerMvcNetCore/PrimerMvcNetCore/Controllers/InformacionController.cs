using Microsoft.AspNetCore.Mvc;
using PrimerMvcNetCore.Models;

namespace PrimerMvcNetCore.Controllers
{
    public class InformacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index(string variable1, string variable2)
        {
            return View();
        }

        public IActionResult VistaControllerPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VistaControllerPost(Persona persona, string aficiones)
        {
            ViewData["DATA"] = "Nombre: " + persona.Nombre + ", Email: " + persona.Email +
                ", Edad: " + persona.Edad + ", Aficiones: " + aficiones;
            return View();
        }

        // Vamos a recibir dos parámetros
        public IActionResult VistaControllerGet(string saludo, int? year)
        {
            // Para comprobar que los hemos recibido, guardamos los
            // parámetros en ViewData para ver la información
            // Preguntamos si año ha venido en la información
            if(year != null)
            {
                ViewData["DATA"] = "Hola " + saludo + " en el año " + year;
            }
            else
            {
                ViewData["DATA"] = "Aquí nadie saluda ya...";
            }
            return View();
        }

        public IActionResult ControladorVista()
        {
            // Vamos a enviar información simple a nuestra vista
            ViewData["NOMBRE"] = "Alumno";
            ViewData["EDAD"] = 24;
            ViewBag.DiaSemana = "Lunes";
            return View();
        }

        public IActionResult ControladorVistaModel()
        {
            Persona persona = new Persona();
            persona.Nombre = "Alumno";
            persona.Email = "alumno@email.com";
            persona.Edad = 27;
            return View(persona);
        }
    }
}
