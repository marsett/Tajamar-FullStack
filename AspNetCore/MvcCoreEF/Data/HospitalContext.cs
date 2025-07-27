using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Models;

namespace MvcCoreEF.Data
{
    public class HospitalContext: DbContext
    {
        // Tendremos un constructor que recibirá las opciones
        // de inicio para el context, como la cadena de conexión
        // por ejemplo
        public HospitalContext(DbContextOptions<HospitalContext> options)
            :base(options)
        {
            
        }
        // En esta clase estarán las colecciones de los modelos
        // que serán las que utilizaremos mediante Linq
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
