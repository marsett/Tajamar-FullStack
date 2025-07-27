using System.Diagnostics;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using MvcCoreKeyVault.Models;

namespace MvcCoreKeyVault.Controllers
{
    public class HomeController : Controller
    {
        // Necesitamos inyectar SecretClient
        private SecretClient secretClient;
        public HomeController(SecretClient secretClient)
        {
            this.secretClient = secretClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string secretname)
        {
            KeyVaultSecret secret = await this.secretClient.GetSecretAsync(secretname);
            ViewData["SECRETO"] = secret.Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
