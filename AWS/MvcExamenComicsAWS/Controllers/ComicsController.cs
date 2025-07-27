using Microsoft.AspNetCore.Mvc;
using MvcExamenComicsAWS.Models;
using MvcExamenComicsAWS.Repositories;
using MvcExamenComicsAWS.Services;

namespace MvcExamenComicsAWS.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repo;
        private ServiceStorageS3 service;
        public ComicsController(RepositoryComics repo, ServiceStorageS3 service)
        {
            this.repo = repo;
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Comic> comics = await this.repo.GetComicsAsync();
            return View(comics);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Comic comic, IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(file.FileName, stream);
            }
            await this.repo.CreateComicAsync(comic.Nombre, file.FileName);
            return RedirectToAction("Index");
        }
    }
}
