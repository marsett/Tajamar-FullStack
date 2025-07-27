using ApiPersonas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private List<Persona> personas;
        public PersonasController()
        {
            this.personas = new List<Persona>();
            Persona p;
            p = new Persona
            {
                IdPersona = 1,
                Nombre = "Lucía",
                Email = "lucia@gmail.com",
                Edad = 22
            };
            this.personas.Add(p);
            p = new Persona
            {
                IdPersona = 2,
                Nombre = "Adrián",
                Email = "adrian@gmail.com",
                Edad = 36
            };
            this.personas.Add(p);
            p = new Persona
            {
                IdPersona = 3,
                Nombre = "Diana",
                Email = "lucia@gmail.com",
                Edad = 42
            };
            this.personas.Add(p);
            p = new Persona
            {
                IdPersona = 4,
                Nombre = "Carmen",
                Email = "carmen@gmail.com",
                Edad = 29
            };
            this.personas.Add(p);
        }

        [HttpGet]
        public ActionResult<List<Persona>> Get() 
        {
            return this.personas;
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> Get(int id)
        {
            return this.personas.FirstOrDefault(x => x.IdPersona == id);
        }
    }
}
