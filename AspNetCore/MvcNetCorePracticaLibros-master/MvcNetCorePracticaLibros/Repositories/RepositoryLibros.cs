using Microsoft.EntityFrameworkCore;
using MvcNetCorePracticaLibros.Data;
using MvcNetCorePracticaLibros.Models;

namespace MvcNetCorePracticaLibros.Repositories
{
    public class RepositoryLibros
    {
        private LibrosContext context;

        public RepositoryLibros(LibrosContext context)
        {
            this.context = context;
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
            return await this.context.Libros.ToListAsync();
        }

        public async Task<List<Genero>> GetGenerosAsync()
        {
            return await this.context.Generos.ToListAsync();
        }

        public async Task<List<Libro>> GetLibrosByGeneroAsync
            (int idgenero)
        {
            return await this.context.Libros
                .Where(l => l.IdGenero == idgenero)
                .ToListAsync();
        }

        public async Task<List<VistaPedido>> GetVistaPedidosAsync
            (int idusuario)
        {
            return await this.context.VistaPedidos
                .Where(vp => vp.IdUsuario == idusuario)
                .ToListAsync();
        }

        public async Task<Libro> FindLibroAsync(int idlibro)
        {
            return await this.context.Libros
                .FirstOrDefaultAsync(l => l.IdLibro == idlibro);
        }

        public async Task<Usuario> FindUsuarioAsync(int idusuario)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(u => u.IdUsuario == idusuario);
        }

        public async Task<Usuario> LoginUsuarioAsync
            (string email, string password)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email &&
                u.Pass == password);
        }

        public async Task<List<Libro>> GetLibrosCarritoAsync
            (List<int> carrito)
        {
            return await this.context.Libros
                .Where(l => carrito.Contains(l.IdLibro))
                .ToListAsync();
        }

        public async Task<int> GetMaxIdPedidoAsync()
        {
            if (this.context.Pedidos.Count() == 0) return 1;
            else return await this.context.Pedidos
                    .MaxAsync(p => p.IdPedido) + 1;
        }

        public async Task<int> GetMaxIdFacturaAsync()
        {
            if (this.context.Pedidos.Count() == 0) return 1;
            else return await this.context.Pedidos
                    .MaxAsync(p => p.IdFactura) + 1;
        }

        public async Task FinalizarCompraAsync(List<int> carrito, int idusuario)
        {
            int idfactura = await GetMaxIdFacturaAsync();
            DateTime fecha = DateTime.Now;
            foreach (int idlibro in carrito.Distinct())
            {
                int idpedido = await GetMaxIdPedidoAsync();
                await this.context.Pedidos.AddAsync
                    (new Pedido
                    {
                        IdPedido = idpedido,
                        IdFactura = idfactura,
                        IdLibro = idlibro,
                        Fecha = fecha,
                        Cantidad = carrito.Where(id => id == idlibro).Count(),
                        IdUsuario = idusuario
                    });
                await this.context.SaveChangesAsync();
            }
        }
        public async Task<List<VistaPedido>> GetPedidosUsuarioAsync
            (int idusuario)
        {
            return await this.context.VistaPedidos
                .Where(vp => vp.IdUsuario == idusuario)
                .ToListAsync();
        }
        
    }
}
