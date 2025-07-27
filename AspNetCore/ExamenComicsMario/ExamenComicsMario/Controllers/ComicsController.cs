using System.Diagnostics;
using System.Numerics;
using ExamenComicsMario.Models;
using ExamenComicsMario.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenComicsMario.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repo;

        public ComicsController()
        {
            this.repo = new RepositoryComics();
        }
        public IActionResult Index()
        {
            List<Comic> comics = this.repo.GetComics();
            return View(comics);
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Comic comic)
        {
            this.repo.InsertComic(comic);
            return RedirectToAction("Index");
        }

        public IActionResult Buscar()
        {
            ViewData["COMICS"] = this.repo.GetNombresComics();
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(string comic)
        {
            ViewData["COMICS"] = this.repo.GetNombresComics();
            Comic comic1 = this.repo.GetDetalleComic(comic);
            return View(comic1);
        }
    }
}
