using ApiPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.Data
{
    public class ArtistasContext: DbContext
    {
        public ArtistasContext(DbContextOptions<ArtistasContext> options): base(options) { }
        public DbSet<Artista> Artistas { get; set; }
    }
}
