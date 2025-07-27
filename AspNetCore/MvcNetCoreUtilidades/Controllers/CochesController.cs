using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Models;

namespace MvcNetCoreUtilidades.Controllers
{
    public class CochesController : Controller
    {
        public List<Coche> Cars;
        public CochesController()
        {
            this.Cars = new List<Coche>
            {

              new Coche { IdCoche = 1, Marca = "Pontiac"

             , Modelo = "Firebird", Imagen = "https://www.chevrolet.com/content/dam/chevrolet/na/us/english/the-block/articles/2024/october/drifting-bird-this-1978-pontiac-firebird-trans-am-hits-the-track-with-ls-power/article/the-block-ls-fest-1978-trans-am-drift-2-1-lg-4.jpg?imwidth=960"},

              new Coche { IdCoche = 2, Marca = "Volkswagen"

             , Modelo = "Escarabajo", Imagen = "https://www.quadis.es/documents/80345/95274/herbie-el-volkswagen-beetle-mas.jpg"},

              new Coche { IdCoche = 3, Marca = "Ferrari"

             , Modelo = "Testarrosa", Imagen = "https://www.lavanguardia.com/files/article_main_microformat/uploads/2017/01/03/5f15f8b7c1229.png"},

              new Coche { IdCoche = 4, Marca = "Ford"

             , Modelo = "Mustang GT", Imagen = "https://cdn.autobild.es/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2018/03/prueba-wolf-racing-mustang-gt.jpg"}

             };
        }
        // Esta es la vista que vamos a visualizar como principal
        public IActionResult Index()
        {
            return View();
        }

        // Tendremos un IActionResult para integrar dentro de otra
        // vista, en nuestro ejemplo, dentro de Index
        public IActionResult _CochesPartial()
        {
            // Si son vistas parciales con Ajax, debemos devolver
            // PartialView
            return PartialView("_CochesPartial", this.Cars);
        }

        public IActionResult _CochesPost(int idCoche)
        {
            Coche car = this.Cars.FirstOrDefault(x => x.IdCoche == idCoche);
            return PartialView("_DetailsCoche", car);
        }

        public IActionResult Details(int idCoche)
        {
            Coche car = this.Cars.FirstOrDefault(z => z.IdCoche == idCoche);
            return View(car);
        }
    }
}
