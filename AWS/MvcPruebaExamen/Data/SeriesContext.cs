using Microsoft.EntityFrameworkCore;
using MvcPruebaExamen.Models;

namespace MvcPruebaExamen.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
    }
}
