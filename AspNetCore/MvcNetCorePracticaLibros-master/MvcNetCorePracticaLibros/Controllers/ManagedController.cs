using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcNetCorePracticaLibros.Models;
using MvcNetCorePracticaLibros.Repositories;
using System.Security.Claims;

namespace MvcNetCorePracticaLibros.Controllers
{
    public class ManagedController : Controller
    {
        private RepositoryLibros repo;

        public ManagedController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login
            (string email, string password)
        {
            Usuario usuario = await this.repo.LoginUsuarioAsync
                (email, password);
            if (usuario != null)
            {
                ClaimsIdentity identity =
                    new ClaimsIdentity
                 (CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimTypes.Name, ClaimTypes.Role
                        );
                Claim claimEmail = new Claim(ClaimTypes.Name
                    , usuario.Email);
                Claim claimFoto = new Claim("FOTO", usuario.Foto);
                Claim claimNombre = new Claim("NOMBRE", usuario.Nombre);
                Claim claimApellidos = new Claim("APELLIDOS", usuario.Apellidos);
                Claim claimID = new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString());
                identity.AddClaim(claimEmail);
                identity.AddClaim(claimFoto);
                identity.AddClaim(claimNombre);
                identity.AddClaim(claimApellidos);
                identity.AddClaim(claimID);
                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal);
                string controller = TempData["controller"].ToString();
                string action = TempData["action"].ToString();
                return RedirectToAction(action, controller);
            }
            else
            {
                ViewData["MENSAJE"] = "Email/password incorrectos";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Managed");
        }
    }
}
