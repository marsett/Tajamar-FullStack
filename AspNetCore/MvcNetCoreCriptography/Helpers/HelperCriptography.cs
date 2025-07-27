using System.Security.Cryptography;
using System.Text;

namespace MvcNetCoreCriptography.Helpers
{
    public class HelperCriptography
    {
        // Vamos a crear un par de métodos que no
        // tienen nada que ver con criptografía
        // Si tenemos muchos métodos que simplemente
        // son herramientas, lo suyo es crear una
        // clase HelperToolkit
        public static string GenerateSalt()
        {
            Random random = new Random();
            string salt = "";
            // El número de vueltas debe coincidir con
            // el valor del campo nvarchar
            for(int i = 1; i <= 50; i++)
            {
                int aleat = random.Next(1, 255);
                char letra = Convert.ToChar(aleat);
                salt += letra;
            }
            return salt;
        }

        // Necesitamos saber si el password que hemos almacenado
        // en bbdd es igual al password que nos habrán dado en la app
        // Este es un método para comparar dos arrays de bytes
        public static bool CompararArrays(byte[] a, byte[] b)
        {
            bool iguales = true;
            if(a.Length != b.Length)
            {
                iguales = false;
            }
            else
            {
                // Recorremos el array a
                for (int i = 0; i < a.Length; i++)
                {
                    // Comparamos byte a byte
                    if(a[i].Equals(b[i]) == false)
                    {
                        iguales = false;
                        break;
                    }
                }
            }
            return iguales;
        }

        // Tendremos un método para cifrar el password
        // Vamos a recibir el password a cifrar (string)
        // y también vamos a recibir el salt (string)
        // Devolveremos un array con el resultado
        public static byte[] EncryptPassword(string password, string salt)
        {
            string contenido = password + salt;
            SHA512 managed = SHA512.Create();
            // Convertimos el contenido a byte[]
            byte[] salida = Encoding.UTF8.GetBytes(contenido);
            // Creamos el bucle de cifrado con iteraciones
            for(int i = 1; i <= 15; i++)
            {
                salida = managed.ComputeHash(salida);
            }
            managed.Clear();
            return salida;
        }
    }
}
