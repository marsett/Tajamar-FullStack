using Microsoft.AspNetCore.Mvc;
using EjemploCubosUltimoDia.Models;
using EjemploCubosUltimoDia.Repositories;

namespace EjemploCubosUltimoDia.ViewComponents
{
    public class MenuMarcasViewComponent: ViewComponent
    {
        private RepositoryCubos repo;
        public MenuMarcasViewComponent(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<string> marcas = await this.repo.GetMarcasAsync();
            return View(marcas);
        }
    }
}
