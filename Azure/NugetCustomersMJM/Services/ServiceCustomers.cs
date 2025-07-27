using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NugetCustomersMJM.Services
{
    public class ServiceCustomers
    {
        public async Task<CustomersList> GetCustomersListAsync()
        {
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            // Copiamos la url completa para los customers
            string url = "https://northwind-api.miloudi.dev/v1/customers";
            string dataJson = await client.DownloadStringTaskAsync(url);
            CustomersList clients = JsonConvert.DeserializeObject<CustomersList>(dataJson);
            return clients;
        }
    }
}
