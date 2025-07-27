using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PracticaCubos.Extensions;
using PracticaCubos.Helpers;
using PracticaCubos.Models;
using PracticaCubos.Repositories;

namespace PracticaCubos.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubos repo;
        private HelperPathProvider helperPath;
        private IMemoryCache memoryCache;

        public CubosController(RepositoryCubos repo, HelperPathProvider helperPath, IMemoryCache memoryCache)
        {
            this.repo = repo;
            this.helperPath = helperPath;
            this.memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index(int? idcubo, int? idFavorito)
        {
            if (idFavorito != null)
            {
                List<Cubo> cubosFavoritos;
                if (this.memoryCache.Get("FAVORITOS") == null)
                {
                    // No existen, creamos la colección de favoritos
                    cubosFavoritos = new List<Cubo>();
                }
                else
                {
                    // Recuperamos los empleados que tenemos en la
                    // colección de favoritos de caché
                    cubosFavoritos = this.memoryCache.Get<List<Cubo>>("FAVORITOS");
                }
                // Buscamos el objeto empleado a almacenar
                Cubo cubo = await this.repo.FindCuboAsync(idFavorito.Value);
                cubosFavoritos.Add(cubo);
                this.memoryCache.Set("FAVORITOS", cubosFavoritos);
            }

            if (idcubo != null)
            {
                // Almacenamos lo mínimo que podamos (int)
                List<int> idsCubos;
                if (HttpContext.Session.GetObject<List<int>>("IDSCUBOS") == null)
                {
                    // No existe y creamos la colección
                    idsCubos = new List<int>();
                }
                else
                {
                    // Existe y recuperamos la colección
                    idsCubos = HttpContext.Session.GetObject<List<int>>("IDSCUBOS");
                }
                idsCubos.Add(idcubo.Value);
                // Refrescamos los datos de session
                HttpContext.Session.SetObject("IDSCUBOS", idsCubos);
            }

            List<Cubo> cubos = await this.repo.GetCubosAsync();
            return View(cubos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cubo cubo, IFormFile imagen)
        {
            string fileName = imagen.FileName;

            string path = this.helperPath.MapPath(fileName, Folders.Cubos);
            string pathServer = this.helperPath.MapUrlPathServer(fileName, Folders.Cubos);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }
            ViewData["MENSAJE"] = "Fichero subido a " + path;
            string pathAccessor = this.helperPath.MapUrlPath(fileName, Folders.Cubos);
            ViewData["PATH"] = pathServer;

            await this.repo.UpdateCuboAsync(cubo.IdCubo, cubo.Nombre,
                cubo.Modelo, cubo.Marca, fileName, cubo.Precio);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cubo cubo, IFormFile imagen)
        {
            string fileName = imagen.FileName;

            string path = this.helperPath.MapPath(fileName, Folders.Cubos);
            string pathServer = this.helperPath.MapUrlPathServer(fileName, Folders.Cubos);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }
            ViewData["MENSAJE"] = "Fichero subido a " + path;
            string pathAccessor = this.helperPath.MapUrlPath(fileName, Folders.Cubos);
            ViewData["PATH"] = pathServer;

            await this.repo.InsertCuboAsync(cubo.Nombre,
                cubo.Modelo, cubo.Marca, fileName, cubo.Precio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CubosAlmacenadosSession(int? ideliminar, int? cantidad)
        {
            List<int> idsCubos = HttpContext.Session.GetObject<List<int>>("IDSCUBOS");


            if (idsCubos == null)
            {
                ViewData["MENSAJE"] = "No existen cubos almacenados en el carrito.";
                return View();
            }
            else
            {
                if (ideliminar != null)
                {
                    idsCubos.Remove(ideliminar.Value);

                    if (idsCubos.Count == 0)
                    {
                        HttpContext.Session.Remove("IDSCUBOS");
                    }
                    else
                    {
                        HttpContext.Session.SetObject("IDSCUBOS", idsCubos);
                    }
                }

                List<Cubo> cubos = await this.repo.GetCubosSessionAsync(idsCubos);
                return View(cubos);
            }
        }

        public IActionResult CubosFavoritos(int? ideliminar)
        {
            if (ideliminar != null)
            {
                List<Cubo> favoritos = this.memoryCache.Get<List<Cubo>>("FAVORITOS");
                // Buscamos al empleado a eliminar dentro de la colección de favoritos
                Cubo cuboDelete = favoritos.Find(z => z.IdCubo == ideliminar.Value);
                favoritos.Remove(cuboDelete);
                if (favoritos.Count == 0)
                {
                    this.memoryCache.Remove("FAVORITOS");
                }
                else
                {
                    this.memoryCache.Set("FAVORITOS", favoritos);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FinalizarCompra()
        {
            List<int> idsCubos = HttpContext.Session.GetObject<List<int>>("IDSCUBOS");
            Dictionary<int, int> cantidades = HttpContext.Session.GetObject<Dictionary<int, int>>("CANTIDADES") ?? new Dictionary<int, int>();

            if (idsCubos == null || idsCubos.Count == 0)
            {
                return RedirectToAction("Index", "Cubos");
            }

            List<Cubo> cubos = await this.repo.GetCubosSessionAsync(idsCubos);

            if (cubos == null || cubos.Count == 0)
            {
                return RedirectToAction("Index", "Cubos");
            }

            List<int> idsCompras = new List<int>();
            foreach (var cubo in cubos)
            {
                int cantidadCubo = cantidades.ContainsKey(cubo.IdCubo) ? cantidades[cubo.IdCubo] : 1; // Tomamos la cantidad de la sesión

                int idCompraMaximo = await this.repo.GetMaxIdCompraAsync();
                int idCompra = idCompraMaximo + 1;

                var compra = new Compra
                {
                    IdCompra = idCompra,
                    IdCubo = cubo.IdCubo,
                    Cantidad = cantidadCubo,  
                    Precio = cubo.Precio,
                    FechaPedido = DateTime.Now
                };

                idsCompras.Add(idCompra);
                await this.repo.InsertCompra(compra);
            }

            // Limpiar la sesión después de la compra
            HttpContext.Session.Remove("CANTIDADES");
            HttpContext.Session.SetObject("IDSCOMPRAS", idsCompras);

            return RedirectToAction("ComprasRealizadas");
        }

        public async Task<IActionResult> ComprasRealizadas()
        {
            List<int> idsCompras = HttpContext.Session.GetObject<List<int>>("IDSCOMPRAS");

            if (idsCompras == null)
            {
                idsCompras = new List<int>();
            }

            var compras = await this.repo.GetComprasRealizadasAsync();

            var comprasFiltradas = compras.Where(c => idsCompras.Contains(c.IdCompra)).ToList();
            HttpContext.Session.Remove("IDSCUBOS");
            HttpContext.Session.Remove("IDSCOMPRAS");
            return View(comprasFiltradas);
        }

        [HttpPost]
        public IActionResult ActualizarCantidad(int idCubo, int cantidad)
        {
            // Recuperar el diccionario de cantidades desde la sesión
            Dictionary<int, int> cantidades = HttpContext.Session.GetObject<Dictionary<int, int>>("CANTIDADES") ?? new Dictionary<int, int>();

            // Actualizar la cantidad del cubo en el diccionario
            if (cantidades.ContainsKey(idCubo))
            {
                cantidades[idCubo] = cantidad;
            }
            else
            {
                cantidades.Add(idCubo, cantidad);
            }

            // Guardar el diccionario actualizado en la sesión
            HttpContext.Session.SetObject("CANTIDADES", cantidades);

            return Ok();
        }





    }
}
