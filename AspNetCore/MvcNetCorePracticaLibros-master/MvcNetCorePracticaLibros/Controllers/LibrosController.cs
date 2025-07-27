using Microsoft.AspNetCore.Mvc;
using MvcNetCorePracticaLibros.Extensions;
using MvcNetCorePracticaLibros.Filters;
using MvcNetCorePracticaLibros.Models;
using MvcNetCorePracticaLibros.Repositories;
using System.Security.Claims;

namespace MvcNetCorePracticaLibros.Controllers
{
    public class LibrosController : Controller
    {
        private RepositoryLibros repo;

        public LibrosController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        [AuthorizeUsuarios]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Libros(int? idgenero)
        {
            List<Libro> libros;
            if (idgenero != null)
                libros = await this.repo.GetLibrosByGeneroAsync(idgenero.Value);
            else
                libros = await this.repo.GetLibrosAsync();
            return View(libros);
        }

        public async Task<IActionResult> Details(int idlibro)
        {
            Libro libro = await this.repo.FindLibroAsync(idlibro);
            return View(libro);
        }

        public IActionResult ComprarLibro(int? idlibro)
        {
            if (idlibro != null)
            {
                List<int> carrito;
                if (HttpContext.Session.GetObject<List<int>>("CARRITO") == null)
                    carrito = new List<int>();
                else
                    carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                carrito.Add(idlibro.Value);
                HttpContext.Session.SetObject("CARRITO", carrito);
            }
            return RedirectToAction("Carrito");
        }

        public async Task<IActionResult> QuitarLibro(int? idlibro)
        {
            if (idlibro != null)
            {
                List<int> carrito = HttpContext.Session.GetObject<List<int>>("CARRITO");
                carrito.Remove(idlibro.Value);
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
                List<Libro> libros = await this.repo.GetLibrosCarritoAsync(carrito);
                return View(libros);
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
            return RedirectToAction("PedidosUsuario");
        }

        public async Task<IActionResult> PedidosUsuario()
        {
            int idusuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<VistaPedido> vistaPedidos =
                await this.repo.GetPedidosUsuarioAsync(idusuario);
            return View(vistaPedidos);
        }


        public IActionResult _Perfil()
        {
            return PartialView("_Perfil");
        }
    }
}
