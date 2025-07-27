using Microsoft.EntityFrameworkCore;
using PruebaApi.Data;
using PruebaApi.Models;

namespace PruebaApi.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<UsuariosCuboModel> ValidarUsuario(string email, string password)
        {
            return await this.context.UsuariosCubo.FirstOrDefaultAsync(u => u.Email == email && u.Pass == password);
        }

        #region SIN TOKEN

        // Mostrar todos los cubos
        public async Task<List<CubosModel>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }

        // Buscar cubos por marca
        public async Task<List<CubosModel>> GetCubosMarcaAsync(string marca)
        {
            return await this.context.Cubos.Where(c => c.Marca == marca).ToListAsync();
        }

        // Crear nuevo Usuario (no importar imagen aquí)
        public async Task InsertUsuarioAsync(string nombre, string email, string pass)
        {
            int newId = await this.context.UsuariosCubo.MaxAsync(u => u.IdUsuario) + 1;

            UsuariosCuboModel usuario = new UsuariosCuboModel
            {
                IdUsuario = newId,
                Nombre = nombre,
                Email = email,
                Pass = pass,
                Imagen = ""
            };

            this.context.UsuariosCubo.Add(usuario);
            await this.context.SaveChangesAsync();
        }

        #endregion

        #region CON TOKEN

        // Perfil Usuario
        public async Task<UsuariosCuboModel> GetUsuarioAsync(int id)
        {
            return await this.context.UsuariosCubo.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        // Pedidos Usuario
        public async Task<List<CompraCubosModel>> GetPedidosUsuarioAsync(int id)
        {
            return await this.context.CompraCubos.Where(c => c.IdUsuario == id).ToListAsync();
        }

        // Realizar pedido Usuario
        public async Task InsertPedidoUsuario(int idCubo, int idUsuario, DateTime fechaPedido)
        {
            int newIdCompra = await this.context.CompraCubos.MaxAsync(c => c.IdPedido) + 1;

            CompraCubosModel compra = new CompraCubosModel
            {
                IdPedido = newIdCompra,
                IdCubo = idCubo,
                IdUsuario = idUsuario,
                FechaPedido = fechaPedido
            };

            this.context.CompraCubos.Add(compra);
            await this.context.SaveChangesAsync();
        }

        #endregion
    }
}
