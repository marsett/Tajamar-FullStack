using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleLogicAppsAzure.Services
{
    public class ServiceLogicApps
    {
        private MediaTypeWithQualityHeaderValue header;
        public ServiceLogicApps()
        {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task SendEmailAsync(string email, string subject, string mensaje)
        {
            string urlLogicApps = "https://prod-113.westeurope.logic.azure.com:443/workflows/c34cfdce727f4f6c85fc7394cc2ba4f3/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=1.0&sig=yaGUC0_aWaMSe1au0zCU2MQxygA23azBVZQKiEHwxTY";
            var model = new
            {
                email = email,
                subject = subject,
                mensaje = mensaje
            };
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlLogicApps, content);
            }
        }
    }
}
