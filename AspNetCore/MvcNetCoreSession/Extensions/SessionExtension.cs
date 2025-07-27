using MvcNetCoreSession.Helpers;
using Newtonsoft.Json;

namespace MvcNetCoreSession.Extensions
{
    public static class SessionExtension
    {
        // Creamos un método para recuperar cualquier objeto
        public static T GetObject<T>(this ISession session, string key)
        {
            // Ya estaremos trabajando con HttpContext.Session
            // Debemos recuperar lo que tenemos almacenado
            // dentro de session
            string json = session.GetString(key);
            // Qué sucede si recuperamos algo de session
            // que no existe
            // Si no tenemos nada almacenado, debemos devolver
            // el valor por defecto
            if(json == null)
            {
                return default(T);
            }
            else
            {
                // Recuperamos el objeto que tenemos
                // almacenado dentro de nuestra key
                //T data = HelperJsonSession.DeserializeObject<T>(json);
                T data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            //string data = HelperJsonSession.SerializeObject(value);
            string data = JsonConvert.SerializeObject(value);
            // Almacenamos el json dentro de session
            session.SetString(key, data);
        }

    }
}
