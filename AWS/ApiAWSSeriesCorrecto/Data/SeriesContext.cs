using ApiAWSSeriesCorrecto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAWSSeriesCorrecto.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
    }
}
