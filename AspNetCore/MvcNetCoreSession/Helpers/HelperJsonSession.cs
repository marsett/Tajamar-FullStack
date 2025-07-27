using Newtonsoft.Json;

namespace MvcNetCoreSession.Helpers
{
    public class HelperJsonSession
    {
        // Vamos a utilizar el método GetString() como herramienta
        // Almacenaremos objetos con serialize de json { nombre: "aa", raza: "aaa"}
        public static string SerializeObject<T>(T data)
        {
            // Convertimos el objeto a string mediante Newton
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        // Recibiremos un string y lo convertimos a cualquier objeto T
        public static T DeserializeObject<T>(string data)
        {
            // Deserializamos el string a cualquier objeto
            T objeto = JsonConvert.DeserializeObject<T>(data);
            return objeto;
        }
    }
}
