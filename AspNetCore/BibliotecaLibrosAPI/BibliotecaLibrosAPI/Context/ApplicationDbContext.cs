using BibliotecaLibrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaLibrosAPI.Context
{
    public class ApplicationDbContext: DbContext
    {
        // DbSet que representa la colección de libros en la base de datos
        public DbSet<Libro> Libro {  get; set; }

        // Constructor que recibe las opciones de configuración del contexto de la base de datos
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    }
}
