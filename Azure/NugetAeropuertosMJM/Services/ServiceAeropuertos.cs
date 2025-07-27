using Newtonsoft.Json;
using NugetAeropuertosMJM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NugetCustomersMJM.Services
{
    public class ServiceAeropuertos
    {
        public async Task<AeropuertosList> GetAeropuertosListAsync()
        {
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            string url = "https://services.odata.org/V4/(S(2esholowikwyef30ogqjzbvf))/TripPinServiceRW/Airports";
            string dataJson = await client.DownloadStringTaskAsync(url);
            AeropuertosList aeropuertos = JsonConvert.DeserializeObject<AeropuertosList>(dataJson);
            return aeropuertos;
        }
    }
}
