using Microsoft.EntityFrameworkCore;
using PruebaApi.Models;

namespace PruebaApi.Data
{
    public class CubosContext: DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options): base(options) { }
        public DbSet<CubosModel> Cubos { get; set; }
        public DbSet<CompraCubosModel> CompraCubos { get; set; }
        public DbSet<UsuariosCuboModel> UsuariosCubo { get; set; }
    }
}
