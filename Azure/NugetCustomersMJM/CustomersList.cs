using Newtonsoft.Json;
using NugetCustomersMJM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetCustomersMJM
{
    public class CustomersList
    {
        [JsonProperty("data")]
        public List<Customer> Customers { get; set; }
    }
}
