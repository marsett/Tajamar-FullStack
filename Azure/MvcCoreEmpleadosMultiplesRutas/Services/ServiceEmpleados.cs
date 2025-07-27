using NugetApiModelsMJM;
using System.Net.Http.Headers;

namespace MvcCoreEmpleadosMultiplesRutas.Services
{
    public class ServiceEmpleados
    {
        private string apiUrl;
        private MediaTypeWithQualityHeaderValue header;
        public ServiceEmpleados(IConfiguration configuration)
        {
            this.apiUrl = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            string request = "api/empleados";
            List<Empleado> data = await this.CallApiAsync<List<Empleado>>(request);
            return data;
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            string request = "api/empleados/oficios";
            List<string> data = await this.CallApiAsync<List<string>>(request);
            return data;
        }

        public async Task<List<Empleado>> GetEmpleadosOficiosAsync(string oficio)
        {
            string request = "api/empleados/empleadosoficio/" + oficio;
            List<Empleado> data = await this.CallApiAsync<List<Empleado>>(request);
            return data;
        }
    }
}
