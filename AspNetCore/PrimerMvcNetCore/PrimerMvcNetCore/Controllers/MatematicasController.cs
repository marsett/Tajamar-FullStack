using Microsoft.AspNetCore.Mvc;
using PrimerMvcNetCore.Models;

namespace PrimerMvcNetCore.Controllers
{
    public class MatematicasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SumarNumerosGet(int numeroUno, int numeroDos)
        {
            int suma = numeroUno + numeroDos;
            ViewData["DATA"] = "La suma de " + numeroUno + " + " + numeroDos + " = " + suma;
            return View();
        }

        public IActionResult SumarNumerosPost()
        {
            ViewData["NUMEROUNO"] = 6;
            ViewData["NUMERODOS"] = 9;
            return View();
        }

        [HttpPost]
        public IActionResult SumarNumerosPost(int numeroUno, int numeroDos)
        {
            int suma = numeroUno + numeroDos;
            ViewData["RESULTADO"] = "La suma de " + numeroUno + " + " + numeroDos + " = " + suma;
            return View();
        }

        public IActionResult ConjeturaCollatz()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConjeturaCollatz(int numero)
        {
            // Debemos devolver un objeto complejo con
            // una lista de números
            List<int> numeros = new List<int>();
            while(numero != 1)
            {
                if(numero % 2 == 0)
                {
                    numero = numero / 2;
                }
                else
                {
                    numero = numero * 3 + 1;
                }
                numeros.Add(numero);
            }
            // Devolvemos el model a la vista
            return View(numeros);
        }

        public IActionResult TablaMultiplicarSimple()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TablaMultiplicarSimple(int numero)
        {
            ViewData["NUMERO"] = numero;
            List<int> numeros = new List<int>();
            for(int i=0; i<= 10; i++)
            {
                int resultado = numero * i;
                numeros.Add(resultado);
            }
            return View(numeros);
        }

        public IActionResult TablaMultiplicarModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TablaMultiplicarModel(int numero)
        {
            List<FilaTablaMultiplicar> filas = new List<FilaTablaMultiplicar>();
            for (int i = 1; i <= 10; i++)
            {
                ViewData["NUMERO"] = numero;
                FilaTablaMultiplicar fila = new FilaTablaMultiplicar();
                fila.Operacion = numero + " * " + i;
                fila.Resultado = numero * i;
                filas.Add(fila);
            }
            return View(filas);
        }
    }
}
