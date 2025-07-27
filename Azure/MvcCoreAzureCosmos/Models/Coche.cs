using Newtonsoft.Json;

namespace MvcCoreAzureCosmos.Models
{
    public class Coche
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Imagen { get; set; }
        // Nuestras clases dinámicas
        public Motor Motor { get; set; }
    }
}
