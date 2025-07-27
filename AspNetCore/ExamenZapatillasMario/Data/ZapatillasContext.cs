using ExamenZapatillasMario.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenZapatillasMario.Data
{
    public class ZapatillasContext: DbContext
    {
        public ZapatillasContext(DbContextOptions<ZapatillasContext> options)
        :base(options) { }

        public DbSet<ZapasPractica> ZapasPractica { get; set; }
        public DbSet<ImagenesZapasPractica> ImagenesZapasPractica { get; set; }
    }
}
