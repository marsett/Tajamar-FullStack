using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSasAzureStorage.Helpers;
using MvcCoreSasAzureStorage.Models;

namespace MvcCoreSasAzureStorage.Controllers
{
    public class MigracionController : Controller
    {
        private HelperXML helper;
        private string azureKeys;
        public MigracionController(HelperXML helper, IConfiguration configuration)
        {
            this.azureKeys = configuration.GetValue<string>("AzureKeys:StorageAccount");
            this.helper = helper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string accion)
        {
            //string azureKeys =
            //    "DefaultEndpointsProtocol=https;AccountName=storagetajamarmjm;AccountKey=hNWo402l2L1jBL78YL1lPOrE/c2QWWNAj4X4C0yUpRnvCl/Lo4WVCfqwyOVZrMlefLaxVzGFqdsZ+ASts+hOSw==;EndpointSuffix=core.windows.net";
            TableServiceClient serviceClient = new TableServiceClient(this.azureKeys);
            TableClient tableClient = serviceClient.GetTableClient("alumnos");
            await tableClient.CreateIfNotExistsAsync();
            List<Alumno> alumnos = this.helper.GetAlumnos();
            foreach(Alumno alum in alumnos)
            {
                await tableClient.AddEntityAsync<Alumno>(alum);
            }
            ViewData["MENSAJE"] = "Migración completada";
            return View();
        }
    }
}
