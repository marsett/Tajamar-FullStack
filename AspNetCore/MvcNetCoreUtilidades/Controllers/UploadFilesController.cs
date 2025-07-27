using Microsoft.AspNetCore.Mvc;
using MvcNetCoreUtilidades.Helpers;

namespace MvcNetCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {
        private HelperPathProvider helperPath;

        public UploadFilesController(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;
        }
        public IActionResult SubirFichero()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFichero(IFormFile fichero)
        {
            // Comenzamos almacenando el fichero en los
            // elementos temporales
            string fileName = fichero.FileName;

            // Las rutas de ficheros no debo sobrescribirlas, tengo que generar
            // dichas rutas con el sistema donde estoy trabajando
            string path = this.helperPath.MapPath(fileName, Folders.Images);
            string pathServer = this.helperPath.MapUrlPathServer(fileName, Folders.Images);
            // Para subir el fichero se utiliza Stream con IFormFile
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }
            ViewData["MENSAJE"] = "Fichero subido a " + path;
            string pathAccessor = this.helperPath.MapUrlPath(fileName, Folders.Images);
            ViewData["PATH"] = pathServer;
            return View();
        }
    }
}
