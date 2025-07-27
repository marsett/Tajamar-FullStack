﻿using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Helpers;

namespace MvcNetCoreUtilidades.Controllers
{
    public class CifradosController : Controller
    {
        public IActionResult CifradoEficiente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CifradoEficiente(string contenido, string resultado, string accion)
        {
            if (accion.ToLower() == "cifrar")
            {
                string response = HelperCryptography.CifrarContenido(contenido, false);
                ViewData["TEXTOCIFRADO"] = response;
                ViewData["SALT"] = HelperCryptography.Salt;
            }
            else if (accion.ToLower() == "comparar")
            {
                string response = HelperCryptography.CifrarContenido(contenido, true);
                if (response != resultado)
                {
                    ViewData["MENSAJE"] = "Los datos no son correctos";
                }
                else
                {
                    ViewData["MENSAJE"] = "Los datos son CORRECTOS!!!";
                }
            }
            return View();
        }

        public IActionResult CifradoBasico()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CifradoBasico(string contenido, string resultado, string accion)
        {
            // Ciframos el contenido
            string response = HelperCryptography.EncriptarTextoBasico(contenido);
            if (accion.ToLower() == "cifrar")
            {
                ViewData["TEXTOCIFRADO"] = response;
            }else if(accion.ToLower() == "comparar")
            {
                // Si el usuario quiere comparar, nos estará enviando
                // el resultado para comparar
                if(response != resultado)
                {
                    ViewData["MENSAJE"] = "Los datos no coinciden";
                }
                else
                {
                    ViewData["MENSAJE"] = "Contenidos iguales!!!";
                }
            }
            return View();
        }
    }
}
