using Microsoft.EntityFrameworkCore;
using MvcExamenComicsAWS.Models;

namespace MvcExamenComicsAWS.Data
{
    public class ComicsContext: DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options) { }
        public DbSet<Comic> Comics { get; set; }
    }
}
