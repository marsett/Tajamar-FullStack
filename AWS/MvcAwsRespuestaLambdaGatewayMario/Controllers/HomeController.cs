using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MvcAwsRespuestaLambdaGatewayMario.Models;
using Newtonsoft.Json;

namespace MvcAwsRespuestaLambdaGatewayMario.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;

        public HomeController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View(new Pregunta());
        }
        [HttpPost]
        public async Task<IActionResult> Index(Pregunta model)
        {
            var payload = new { pregunta = model.Question };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://xck08869h7.execute-api.us-east-1.amazonaws.com/prod/ask", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var lambdaResult = JsonConvert.DeserializeObject<RespuestaLambda>(jsonResponse);

            model.Respuesta = lambdaResult?.Respuesta;

            return View(model);
        }

    }
}
