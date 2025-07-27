using Microsoft.EntityFrameworkCore;
using MvcNetCoreCriptography.Models;

namespace MvcNetCoreCriptography.Data
{
    public class UsuariosContext: DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
