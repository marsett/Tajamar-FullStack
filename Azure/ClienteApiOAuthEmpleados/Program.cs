using ClienteApiOAuthEmpleados;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

Console.WriteLine("Client Api OAuth");
Console.WriteLine("Introduzca apellido");
string apellido = Console.ReadLine();
Console.WriteLine("Password");
string password = Console.ReadLine();
string respuesta = await GetTokenAsync(apellido, password);
Console.WriteLine(respuesta);
Console.WriteLine("A continuación, introduzca un ID de empleado a buscar:");
int id = int.Parse(Console.ReadLine());
string data = await FindEmpleadoAsync(id, respuesta);
Console.WriteLine(data);
Console.WriteLine("-------------");

// Para crear un método en program, debemos hacerlo static
static async Task<string> GetTokenAsync(string user, string pass)
{
    string urlApi = "https://apioauthempleadosmjm2025.azurewebsites.net/";
    LoginModel model = new LoginModel
    {
        UserName = user,
        Password = pass
    };
    using(HttpClient client = new HttpClient())
    {
        string request = "api/auth/login";
        client.BaseAddress = new Uri(urlApi);
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        string json = JsonConvert.SerializeObject(model);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(request, content);
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            JObject keys = JObject.Parse(data);
            string token = keys.GetValue("response").ToString();
            return token;
        }
        else
        {
            return "Petición incorrecta: " + response.StatusCode;
        }
    }
}

// Creamos otro método para leer un empleado y hacerlo con
// el token que hemos recuperado
static async Task<string> FindEmpleadoAsync(int idEmpleado, string token)
{
    string urlApi = "https://apioauthempleadosmjm2025.azurewebsites.net/";
    using (HttpClient client = new HttpClient())
    {
        string request = "api/empleados/" + idEmpleado;
        client.BaseAddress = new Uri(urlApi);
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // Para la petición, debemos hacer lo mismo que hemos
        // hecho en Insomnia, es decir, incluir en el header
        // Authorization y bearer token
        // Authorization y bearer token
        client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
        HttpResponseMessage response = await client.GetAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            return data;
        }
        else
        {
            return "Error de algo: " + response.StatusCode;
        }
    }
}