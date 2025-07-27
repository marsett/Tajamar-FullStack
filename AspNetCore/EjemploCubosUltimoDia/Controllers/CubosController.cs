using EjemploCubosUltimoDia.Filters;
using EjemploCubosUltimoDia.Extensions;
using EjemploCubosUltimoDia.Models;
using EjemploCubosUltimoDia.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EjemploCubosUltimoDia.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubos repo;
        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        [AuthorizeUsuarios]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cubos(string? marca)
        {
            List<Cubo> cubos;
            if (marca != null)
                cubos = await this.repo.GetCubosByMarcaAsync(marca);
            else
                cubos = await this.repo.GetCubosAsync();
            return View(cubos);
        }

        public async Task<IActionResult> Details(int idcubo)
        {
            Cubo cubo = await this.repo.FindCuboAsync(idcubo);
            return View(cubo);
        }

        public IActionResult ComprarCubo(int? idcubo)
        {
            if (idcubo != null)
            {
                List<int> carrito;
                if (HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                    carrito = new List<int>();
                else
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                carrito.Add(idcubo.Value);
                HttpContext.Session.SetObject("CARRITO", carrito);
            }
            return RedirectToAction("Carrito");
        }

        public async Task<IActionResult> QuitarCubo(int? idcubo)
        {
            if (idcubo != null)
            {
                List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                carrito.Remove(idcubo.Value);
                if (carrito.Count() == 0)
                    HttpContext.Session.Remove("CARRITO");
                else
                    HttpContext.Session.SetObject("CARRITO", carrito);
            }
            return RedirectToAction("Carrito");
        }

        public async Task<IActionResult> Carrito()
        {
            List<int> carrito = HttpContext.Session.GetObject
                <List<int>>("CARRITO");
            if (carrito != null)
            {
                List<Cubo> cubos = await this.repo.GetCubosCarritoAsync(carrito);
                return View(cubos);
            }
            return View();
        }

        [AuthorizeUsuarios]
        public async Task<IActionResult> FinalizarCompra()
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            int idusuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await this.repo.FinalizarCompraAsync(carrito, idusuario);
            HttpContext.Session.Remove("CARRITO");
            return RedirectToAction("ComprasUsuario");
        }

        public async Task<IActionResult> ComprasUsuario()
        {
            int idusuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<VistaCompra> vistaCompras =
                await this.repo.GetComprasUsuarioAsync(idusuario);
            return View(vistaCompras);
        }

        public IActionResult _Perfil()
        {
            return PartialView("_Perfil");
        }
    }
}
