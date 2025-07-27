using Newtonsoft.Json;
using NugetAeropuertosMJM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetAeropuertosMJM
{
    public class AeropuertosList
    {
        [JsonProperty("value")]
        public List<Aeropuerto> Aeropuertos { get; set; }
    }
}
