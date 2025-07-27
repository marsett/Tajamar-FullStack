using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetCustomersMJM.Models
{
    public class Customer
    {
        [JsonProperty("customerId")]
        public string IdCustomer { get; set; }
        [JsonProperty("contactName")]
        public string Contacto { get; set; }
        [JsonProperty("companyName")]
        public string Empresa { get; set; }
        [JsonProperty("address")]
        public string Direccion { get; set; }
    }
}
