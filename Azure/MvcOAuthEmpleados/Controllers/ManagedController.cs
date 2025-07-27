using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcOAuthEmpleados.Models;
using MvcOAuthEmpleados.Services;
using System.Security.Claims;

namespace MvcOAuthEmpleados.Controllers
{
    public class ManagedController : Controller
    {
        private ServiceEmpleados service;
        public ManagedController(ServiceEmpleados service)
        {
            this.service = service;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            string token = await this.service
                .GetTokenAsync(model.UserName, model.Password);
            if(token == null)
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
                return View();
            }
            else
            {
                ViewData["MENSAJE"] = "Ya tienes tu token!!!";
                HttpContext.Session.SetString("TOKEN", token);
                ClaimsIdentity identity = new ClaimsIdentity
                    (CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                // Almacenamos el nombre del usuario (bonito)
                identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
                // En este ejemplo, almacenamos el id (password)
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.Password));
                // Almacenamos el token en el usuario
                identity.AddClaim(new Claim("TOKEN", token));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                // El usuario estará dado de alta 30 minutos
                // lo mismo que session
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                });
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
