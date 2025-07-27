﻿using Microsoft.AspNetCore.Mvc;
using MvcNetCorePersonajesAWS.Models;
using MvcNetCorePersonajesAWS.Services;

namespace MvcNetCorePersonajesAWS.Controllers
{
    public class PersonajesController : Controller
    {
        private ServiceApiPersonajes service;
        public PersonajesController(ServiceApiPersonajes service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            return View(personajes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Personaje personaje)
        {
            await this.service.CreatePersonajeAsync(personaje.Nombre, personaje.Imagen);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Personaje personaje = await this.service.GetPersonajeByIdAsync(id);
            return View(personaje);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Personaje personaje)
        {
            await this.service.UpdatePersonajeAsync(id, personaje.Nombre, personaje.Imagen);
            return RedirectToAction("Index");
        }
    }
}
