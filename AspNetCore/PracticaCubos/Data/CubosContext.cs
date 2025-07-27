using Microsoft.EntityFrameworkCore;
using PracticaCubos.Models;

namespace PracticaCubos.Data
{
    public class CubosContext: DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options): base(options)
        {
            
        }

        public DbSet<Compra> Compra { get; set; }
        public DbSet<Cubo> Cubo { get; set; }
        public DbSet<VistaCompra> VistaCompra { get; set; }
    }
}
