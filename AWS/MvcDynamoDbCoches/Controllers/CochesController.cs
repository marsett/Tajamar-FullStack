using Microsoft.AspNetCore.Mvc;
using MvcDynamoDbCoches.Models;
using MvcDynamoDbCoches.Services;

namespace MvcDynamoDbCoches.Controllers
{
    public class CochesController : Controller
    {
        private ServiceDynamoDb service;
        public CochesController(ServiceDynamoDb service)
        {
            this.service = service;
        }

        public IActionResult Buscador()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Buscador(string marca)
        {
            List<Coche> cars = await this.service.SearchCochesMarcaAsync(marca);
            return View(cars);
        }

        public async Task<IActionResult> Index()
        {
            List<Coche> cars = await this.service.GetCochesAsync();
            return View(cars);
        }
        public async Task<IActionResult> Details(int idcoche)
        {
            Coche car = await this.service.FindCocheAsync(idcoche);
            return View(car);
        }

        public async Task<IActionResult> Delete(int idcoche)
        {
            await this.service.DeleteCocheAsync(idcoche);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Coche car, string motor, string tipo, int potencia, int caballos)
        {
            if(motor != null)
            {
                car.Motor = new Motor();
                car.Motor.Tipo = tipo;
                car.Motor.Caballos = caballos;
                car.Motor.Potencia = potencia;
            }
            await this.service.CreateCocheAsync(car);
            return RedirectToAction("Index");
        }
    }
}
