using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetCore.Helpers
{
    public class HelperConfiguration
    {
        public static string GetConnectionString()
        {
            // Necesitamos un constructor de configuraciones
            ConfigurationBuilder builder = new ConfigurationBuilder();
            // En este entorno no es nativo, por lo que debemos
            // indicar de forma explícita el nombre del fichero y
            // su ubicación
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            // El objeto para recuperar las keys
            IConfigurationRoot configuration = builder.Build();
            // Existen claves que ya vienen por defecto: ConnectionStrings
            string connectionString = configuration.GetConnectionString("SqlTajamar");
            return connectionString;
        }
    }
}
