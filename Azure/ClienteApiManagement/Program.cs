// See https://aka.ms/new-console-template for more information
using System.Web;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");
string respuesta = await ReadDepartmentsAsync();
Console.WriteLine(respuesta);
Console.WriteLine("Pulse ENTER para finalizar");
Console.ReadLine();

static async Task<string> ReadDepartmentsAsync()
{
    string suscripcion = "6fab09bd89c146aeba95ad2a68551a0c";
    string apiUrl = "https://apimanagementmjm.azure-api.net/departamentos/";
    using (HttpClient client = new HttpClient())
    {
        // Debemos enviar una cadena vacía al final de la llamada
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        string request = "api/departamentos?" + queryString;
        // No se utiliza base address
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
        // Si tiene suscripción, debemos enviar ocp key
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", suscripcion);
        // La petición se realiza en conjunto, sin base address
        HttpResponseMessage response = await client.GetAsync(apiUrl + request);
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            return data;
        }
        else
        {
            return "Esto ha ido mal: " + response.StatusCode;
        }
    }
}