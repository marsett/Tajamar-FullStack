using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Models;
using MvcNetCoreUtilidades.Repositories;

namespace MvcNetCoreUtilidades.ViewComponents
{
    public class MenuCochesViewComponent: ViewComponent
    {
        private RepositoryCoches repo;
        public MenuCochesViewComponent(RepositoryCoches repo)
        {
            this.repo = repo;
        }

        // Podríamos tener todos los métodos que deseemos.
        // Es obligatorio tener el método InvokeAsync con Task
        // y será el método que devolverá el model a la vista
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Coche> coches = this.repo.GetCoches();
            return View(coches);
        }
    }
}
