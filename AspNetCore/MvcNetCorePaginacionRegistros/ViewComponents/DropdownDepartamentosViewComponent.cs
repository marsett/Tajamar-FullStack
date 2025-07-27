using Microsoft.AspNetCore.Mvc;
using MvcNetCorePaginacionRegistros.Models;
using MvcNetCorePaginacionRegistros.Repositories;

namespace MvcNetCorePaginacionRegistros.ViewComponents
{
    public class DropdownDepartamentosViewComponent: ViewComponent
    {
        private RepositoryHospital repo;
        public DropdownDepartamentosViewComponent(RepositoryHospital repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosDropdownAsync();
            return View(departamentos);
        }

    }
}
