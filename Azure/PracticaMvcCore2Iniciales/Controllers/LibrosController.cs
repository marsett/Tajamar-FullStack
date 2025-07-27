using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PracticaMvcCore2Iniciales.Extensions;
using PracticaMvcCore2Iniciales.Filters;
using PracticaMvcCore2Iniciales.Models;
using PracticaMvcCore2Iniciales.Repositories;

namespace PracticaMvcCore2Iniciales.Controllers
{
    public class LibrosController : Controller
    {
        private RepositoryLibros repo;
        public LibrosController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        [AuthorizeUsuarios]
        public IActionResult Inicio()
        {
            return View();
        }

        public async Task<IActionResult> Libros(int? idgenero)
        {
            List<Libro> libros;
            if (idgenero != null)
            {
                libros = await this.repo.GetLibrosPorGeneroAsync(idgenero.Value);
            }
            else
            {
                libros = await this.repo.GetLibrosAsync();
            }
            return View(libros);
        }

        public async Task<IActionResult> Detalles(int idlibro)
        {
            Libro libro = await this.repo.BuscarLibroAsync(idlibro);
            return View(libro);
        }

        public IActionResult _PartialPerfil()
        {
            return PartialView("_PartialPerfil");
        }

        public IActionResult Comprar(int? idlibro)
        {
            if (idlibro != null)
            {
                List<int> carrito;
                if(HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                {
                    carrito = new List<int>();
                }
                else
                {
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                }
                carrito.Add(idlibro.Value);
                HttpContext.Session.SetObject("CARRITO", carrito);
            }
            return RedirectToAction("Carrito");
        }

        public async Task<IActionResult> Eliminar(int? idlibro)
        {
            if (idlibro != null)
            {
                List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                carrito.Remove(idlibro.Value);
                if(carrito.Count() == 0)
                {
                    HttpContext.Session.Remove("CARRITO");
                }
                else
                {
                    HttpContext.Session.SetObject("CARRITO", carrito);
                }
            }
            return RedirectToAction("Carrito");
        }

        public async Task<IActionResult> Carrito()
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            if(carrito != null)
            {
                List<Libro> libros = await this.repo.GetLibrosDelCarroAsync(carrito);
                return View(libros);
            }
            return View();
        }

        [AuthorizeUsuarios]
        public async Task<IActionResult> FinalCompra()
        {
            List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
            int idusuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await this.repo.FinalCompraAsync(carrito, idusuario);
            HttpContext.Session.Remove("CARRITO");
            return RedirectToAction("Pedidos");
        }

        public async Task<IActionResult> Pedidos()
        {
            int idusuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<VistaPedido> vistaPedidos = await this.repo.GetPedidosAsync(idusuario);
            return View(vistaPedidos);
        }
    }
}
