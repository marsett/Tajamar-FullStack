using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MvcNetCoreSessionEmpleados.Extensions;
using MvcNetCoreSessionEmpleados.Models;
using MvcNetCoreSessionEmpleados.Repositories;

namespace MvcNetCoreSessionEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;
        private IMemoryCache memoryCache;
        public EmpleadosController(RepositoryEmpleados repo, IMemoryCache memoryCache)
        {
            this.repo = repo;
            this.memoryCache = memoryCache;
        }

        //public IActionResult EmpleadosFavoritos()
        //{
        //    // Preguntamos si existen favoritos
        //    if(this.memoryCache.Get("FAVORITOS") == null)
        //    {
        //        ViewData["MENSAJE"] = "No existen favoritos almacenados";
        //        return View();
        //    }
        //    else
        //    {
        //        List<Empleado> favoritos = this.memoryCache.Get<List<Empleado>>("FAVORITOS");
        //        return View(favoritos);
        //    }
        //}

        public IActionResult EmpleadosFavoritos(int? ideliminar)
        {
            if(ideliminar != null)
            {
                List<Empleado> favoritos = this.memoryCache.Get<List<Empleado>>("FAVORITOS");
                // Buscamos al empleado a eliminar dentro de la colección de favoritos
                Empleado empDelete = favoritos.Find(z => z.IdEmpleado == ideliminar.Value);
                favoritos.Remove(empDelete);
                if(favoritos.Count == 0)
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

        public async Task<IActionResult> EmpleadosAlmacenadosV5(int? ideliminar)
        {
            // Debemos recuperar los ids de empleados que tengamos
            List<int> idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");
            if (idsEmpleados == null)
            {
                ViewData["MENSAJE"] = "No existen empleados almacenados en Session.";
                return View();
            }
            else
            {
                // Preguntamos si hemos recibido algún valor para eliminar
                if (ideliminar != null)
                {
                    idsEmpleados.Remove(ideliminar.Value);
                    // Es posible que ya no tengamos empleados en session
                    if (idsEmpleados.Count == 0)
                    {
                        HttpContext.Session.Remove("IDSEMPLEADOS");
                    }
                    else
                    {
                        // Actualizamos session con el empleado ya eliminado
                        HttpContext.Session.SetObject("IDSEMPLEADOS", idsEmpleados);
                    }
                }
                List<Empleado> empleados = await this.repo.GetEmpleadosSessionAsync(idsEmpleados);
                return View(empleados);
            }
        }
        public async Task<IActionResult> SessionEmpleadosV5(int? idEmpleado, int? idFavorito)
        {
            if (idFavorito != null)
            {
                // Como estoy almacenando en caché de cliente, vamos a
                // utilizar los objetos en lugar de los ids
                List<Empleado> empleadosFavoritos;
                if (this.memoryCache.Get("FAVORITOS") == null)
                {
                    // No existen, creamos la colección de favoritos
                    empleadosFavoritos = new List<Empleado>();
                }
                else
                {
                    // Recuperamos los empleados que tenemos en la
                    // colección de favoritos de caché
                    empleadosFavoritos = this.memoryCache.Get<List<Empleado>>("FAVORITOS");
                }
                // Buscamos el objeto empleado a almacenar
                Empleado emp = await this.repo.FindEmpleadoAsync(idFavorito.Value);
                empleadosFavoritos.Add(emp);
                this.memoryCache.Set("FAVORITOS", empleadosFavoritos);
            }


            if (idEmpleado != null)
            {
                // Almacenamos lo mínimo que podamos (int)
                List<int> idsEmpleados;
                if (HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS") == null)
                {
                    // No existe y creamos la colección
                    idsEmpleados = new List<int>();
                }
                else
                {
                    // Existe y recuperamos la colección
                    idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");
                }
                idsEmpleados.Add(idEmpleado.Value);
                // Refrescamos los datos de session
                HttpContext.Session.SetObject("IDSEMPLEADOS", idsEmpleados);
                ViewData["MENSAJE"] = "Empleados almacenados: " + idsEmpleados.Count;
            }
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
            return View(empleados);
        }







        public async Task<IActionResult> EmpleadosAlmacenadosOK()
        {
            // Debemos recuperar los ids de empleados que tengamos
            List<int> idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");
            if(idsEmpleados == null)
            {
                ViewData["MENSAJE"] = "No existen empleados almacenados en Session.";
                return View();
            }
            else
            {
                List<Empleado> empleados = await this.repo.GetEmpleadosSessionAsync(idsEmpleados);
                return View(empleados);
            }
        }

        public async Task<IActionResult> EmpleadosAlmacenadosV4()
        {
            // Debemos recuperar los ids de empleados que tengamos
            List<int> idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");
            if (idsEmpleados == null)
            {
                ViewData["MENSAJE"] = "No existen empleados almacenados en Session.";
                return View();
            }
            else
            {
                List<Empleado> empleados = await this.repo.GetEmpleadosSessionAsync(idsEmpleados);
                return View(empleados);
            }
        }
        


        public async Task<IActionResult> SessionEmpleadosOK(int? idEmpleado)
        {
            if(idEmpleado != null)
            {
                // Almacenamos lo mínimo que podamos (int)
                List<int> idsEmpleados;
                if (HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS") == null)
                {
                    // No existe y creamos la colección
                    idsEmpleados = new List<int>();
                }
                else
                {
                    // Existe y recuperamos la colección
                    idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");
                }
                idsEmpleados.Add(idEmpleado.Value);
                // Refrescamos los datos de session
                HttpContext.Session.SetObject("IDSEMPLEADOS", idsEmpleados);
                ViewData["MENSAJE"] = "Empleados almacenados: " + idsEmpleados.Count;
            }
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
            return View(empleados);
        }

        public async Task<IActionResult> SessionEmpleadosV4(int? idEmpleado)
        {
            if (idEmpleado != null)
            {
                // Almacenamos lo mínimo que podamos (int)
                List<int> idsEmpleados;
                if (HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS") == null)
                {
                    // No existe y creamos la colección
                    idsEmpleados = new List<int>();
                }
                else
                {
                    // Existe y recuperamos la colección
                    idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");
                }
                idsEmpleados.Add(idEmpleado.Value);
                // Refrescamos los datos de session
                HttpContext.Session.SetObject("IDSEMPLEADOS", idsEmpleados);
                ViewData["MENSAJE"] = "Empleados almacenados: " + idsEmpleados.Count;
            }

            List<int> idsEnSesion = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");

            if(idsEnSesion == null)
            {
                List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
                return View(empleados);
            }
            else
            {
                List<Empleado> empleados = await this.repo.GetEmpleadosNotSessionAsync(idsEnSesion);
                return View(empleados);
            }
        }
        

        public async Task<IActionResult> SessionEmpleados(int? idEmpleado)
        {
            if(idEmpleado != null)
            {
                // Buscamos al empleado
                Empleado empleado = await this.repo.FindEmpleadoAsync(idEmpleado.Value);
                // En session tendremos un conjunto de empleados
                List<Empleado> empleadosList;
                // Debemos preguntar si tenemos el conjunto de empleados
                // almacenados en session
                if (HttpContext.Session.GetObject<List<Empleado>>("EMPLEADOS") != null)
                {
                    // Recuperamos los empleados que tengamos en session
                    empleadosList = HttpContext.Session.GetObject<List<Empleado>>("EMPLEADOS");
                }
                else
                {
                    // Si no existe, instanciamos la colección
                    empleadosList = new List<Empleado>();
                }
                // Almacenamos el empleado dentro de nuestra colección
                empleadosList.Add(empleado);
                // Guardamos en session la colección con el nuevo empleado
                HttpContext.Session.SetObject("EMPLEADOS", empleadosList);
                ViewData["MENSAJE"] = "Empleado " + empleado.Apellido + " almacenado correctamente.";
            }
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
            return View(empleados);
        }

        public IActionResult EmpleadosAlmacenados()
        {
            return View();
        }

        public async Task<IActionResult> SessionSalarios(int? salario)
        {
            if(salario != null)
            {
                // Necesitamos almacenar el salario del empleado
                // y la suma total de salarios que tengamos
                int sumaSalarial = 0;
                // Preguntamos si ya tenemos la suma almacenada en session
                if(HttpContext.Session.GetString("SUMASALARIAL") != null)
                {
                    // Si ya existe la suma salarial, recuperamos su valor
                    sumaSalarial = HttpContext.Session.GetObject<int>("SUMASALARIAL");
                }
                // Realizamos la suma
                sumaSalarial += salario.Value;
                // Almacenamos el nuevo valor de la suma salarial
                // dentro de session
                HttpContext.Session.SetObject("SUMASALARIAL", sumaSalarial);
                ViewData["MENSAJE"] = "Salario almacenado: " + salario.Value;
            }
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
            return View(empleados);
        }

        public IActionResult SumaSalarial()
        {
            return View();
        }

        public IActionResult DeleteEmpleadoSession(int idEmpleado)
        {
            List<int> idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");

            if (idsEmpleados != null)
            {
                idsEmpleados.Remove(idEmpleado);

                if (idsEmpleados.Count == 0)
                {
                    HttpContext.Session.Remove("IDSEMPLEADOS");
                }
                else
                {
                    HttpContext.Session.SetObject("IDSEMPLEADOS", idsEmpleados);
                }
            }

            return RedirectToAction("EmpleadosAlmacenadosV5");
        }

    }
}
