using Microsoft.EntityFrameworkCore;
using MvcAWSSeriesELB.Models;

namespace MvcAWSSeriesELB.Data
{
    public class SeriesContext: DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options): base(options) { }
        public DbSet<Serie> Series { get; set; }
    }
}
