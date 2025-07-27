using AWSApiRepaso2.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSApiRepaso2.Data
{
    public class PeliculasContext: DbContext
    {
        public PeliculasContext(DbContextOptions<PeliculasContext> options) 
            : base(options) 
            {}

        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
