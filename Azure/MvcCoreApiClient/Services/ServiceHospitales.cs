

using MvcCoreApiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreApiClient.Services
{
    public class ServiceHospitales
    {
        // Necesitamos la url de acceso al servicio, solo la url
        private string apiUrl;
        // Necesitamos indicar a nuestro service que leemos código json
        private MediaTypeWithQualityHeaderValue header;
        public ServiceHospitales(IConfiguration configuration)
        {
            this.apiUrl = configuration.GetValue<string>("ApiUrls:ApiHospitales");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }
        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/hospitales/" + idHospital;
                client.BaseAddress = new Uri(this.apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    // Si las propiedades se llaman igual a la
                    // lectura de json, no es necesario mapear
                    // con la decoración [JsonProperty] y no leeremos
                    // con NewtonSoft
                    Hospital data = await response.Content.ReadAsAsync<Hospital>();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
        // Creamos un método asíncrono para leer los hospitales
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            // Se utiliza la clase HttpClient para las peticiones
            // al servidor
            using(HttpClient client = new HttpClient())
            {
                // Necesitamos una petición
                string request = "api/hospitales";
                // Indicamos la url base para acceder al servicio Api
                client.BaseAddress = new Uri(this.apiUrl);
                // Como es posible que se crucen peticiones entre métodos
                // con distintas informaciones, debemos limpiar los header
                // como norma
                client.DefaultRequestHeaders.Clear();
                // Creamos un nuevo header para indicar que leeremos json
                client.DefaultRequestHeaders.Accept.Add(this.header);
                // Hacemos la petición al servicio (Get) y capturamos la respuesta
                HttpResponseMessage response = await client.GetAsync(request);
                // En la respuesta, se ofrecen distintos status code
                if (response.IsSuccessStatusCode)
                {
                    // Descargamos el json como string
                    string json = await response.Content.ReadAsStringAsync();
                    // Utilizamos Newton para recuperar los datos serializados
                    // de json a List<Hospital>
                    List<Hospital> data = JsonConvert.DeserializeObject<List<Hospital>>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
