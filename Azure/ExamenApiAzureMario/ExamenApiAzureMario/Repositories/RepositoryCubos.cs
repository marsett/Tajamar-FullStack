using Microsoft.EntityFrameworkCore;
using ExamenApiAzureMario.Data;
using ExamenApiAzureMario.Models;

namespace ExamenApiAzureMario.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> IsUserValid(string email, string password)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Pass == password);
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos
                .ToListAsync();
        }

        public async Task InsertUsuarioAsync(string nombre, string email, string pass)
        {
            int newId = await this.context.Usuarios
                .MaxAsync(u => u.IdUsuario) + 1;

            Usuario usuario = new Usuario
            {
                IdUsuario = newId,
                Nombre = nombre,
                Email = email,
                Pass = pass,
                Imagen = ""
            };

            this.context.Usuarios.Add(usuario);
            await this.context.SaveChangesAsync();
        }

        public async Task<Usuario> GetUsuarioAsync(int id)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

    }
}
