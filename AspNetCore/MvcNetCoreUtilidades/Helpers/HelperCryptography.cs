using System.Security.Cryptography;
using System.Text;

namespace MvcNetCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
        // Tendremos una propiedad nueva para almacenar el
        // salt que hemos creado dinámicamente
        public static string Salt {  get; set; }

        // Cada vez que realicemos un cifrado, generamos un
        // salt distinto
        private static string GenerateSalt()
        {
            Random random = new Random();
            string salt = "";
            for(int i = 1; i <= 30; i++)
            {
                // Generamos un número aleatorio con códigos ascii
                int aleat = random.Next(1, 255);
                char letra = Convert.ToChar(aleat);
                salt += letra;
            }
            return salt;
        }

        // Creamos un método para cifrar de forma eficiente
        public static string CifrarContenido(string contenido, bool comparar)
        {
            if(comparar == false)
            {
                // Creamos un nuevo salt para el cifrado
                // y lo almacenamos en la propiedad
                Salt = GenerateSalt();
            }
            // En el salt lo podemos utilizar en múltiples lugares
            // al inicio, final, con insert
            string contenidoSalt = contenido + Salt;
            // Creamos un objeto grande para cifrar
            SHA256 managed = SHA256.Create();
            byte[] salida;
            UnicodeEncoding encoding = new UnicodeEncoding();
            salida = encoding.GetBytes(contenidoSalt);
            // Ciframos el contenido con n iteraciones
            for(int i = 1; i <= 22; i++)
            {
                // Realizamos el cifrado sobre el cifrado
                salida = managed.ComputeHash(salida);
            }
            // Debemos liberar la memoria
            managed.Clear();
            string resultado = encoding.GetString(salida);
            return resultado;
        }

        // Comenzamos creando un método static para cifrar un
        // contenido. Simplemente devolvemos el texto cifrado
        public static string EncriptarTextoBasico(string contenido)
        {
            // Necesitamos un array de bytes para convertir
            // el contenido de entrada a byte[]
            byte[] entrada;
            // Al cifrar el contenido, nos devuelve bytes[] de salida
            byte[] salida;
            // Necesitamos una clase que nos permite convertir de
            // string a byte[] y viceversa
            UnicodeEncoding encoding = new UnicodeEncoding();
            // Necesitamos un objeto para cifrar el contenido
            SHA1 managed = SHA1.Create();
            // Convertimos el contenido de entrada a byte[]
            entrada = encoding.GetBytes(contenido);
            // Los objetos para cifrar contienen un método llamado
            // ComputedHash que reciben un array de bytes e
            // internamente hacen cosas y devuelve otro array de bytes
            salida = managed.ComputeHash(entrada);
            // Convertimos salida a string
            string resultado = encoding.GetString(salida);
            return resultado;
        }
    }
}
