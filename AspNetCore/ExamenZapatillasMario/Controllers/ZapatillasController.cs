using ExamenZapatillasMario.Models;
using ExamenZapatillasMario.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenZapatillasMario.Controllers
{
    public class ZapatillasController : Controller
    {
        private RepositoryZapatillas repo;
        public ZapatillasController(RepositoryZapatillas repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<ZapasPractica> zapatillas = await this.repo.GetZapatillasAsync();
            return View(zapatillas);
        }

        public async Task<IActionResult> Details(int idproducto)
        {
            ZapasPractica zapatilla = await this.repo.FindZapatillaAsync(idproducto);

            List<ImagenesZapasPractica> imagenes = await this.repo.GetImagenesPaginacionAsync(idproducto, 1, 1);
            int numImagenes = await this.repo.GetNumeroImagenesAsync(idproducto);

            DetalleZapatilla model = new DetalleZapatilla
            {
                Zapatilla = zapatilla,
                Imagenes = imagenes,
                NumeroTotalImagenes = numImagenes,
                RegistrosPorPagina = 1
            };

            ViewData["POSICION"] = 1;
            ViewData["IDPRODUCTO"] = idproducto;

            return View(model);
        }

        public async Task<IActionResult> _PaginacionImagenes(int idproducto, int posicion)
        {
            int registrosPorPagina = 1;
            List<ImagenesZapasPractica> imagenes = await this.repo.GetImagenesPaginacionAsync(idproducto, posicion, registrosPorPagina);
            int numImagenes = await this.repo.GetNumeroImagenesAsync(idproducto);

            if (posicion < 1) posicion = 1;
            if (posicion > numImagenes) posicion = numImagenes;

            DetalleZapatilla model = new DetalleZapatilla
            {
                Zapatilla = await this.repo.FindZapatillaAsync(idproducto),
                Imagenes = imagenes,
                NumeroTotalImagenes = numImagenes,
                RegistrosPorPagina = registrosPorPagina
            };

            ViewData["POSICION"] = posicion;
            ViewData["IDPRODUCTO"] = idproducto;

            return PartialView("_PaginacionImagenes", model);
        }
    }
}
