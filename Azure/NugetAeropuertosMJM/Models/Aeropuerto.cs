using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetAeropuertosMJM.Models
{
    public class Aeropuerto
    {
        [JsonProperty("IcaoCode")]
        public string IdAeropuerto { get; set; }
        [JsonProperty("Name")]
        public string Nombre { get; set; }
    }
}
