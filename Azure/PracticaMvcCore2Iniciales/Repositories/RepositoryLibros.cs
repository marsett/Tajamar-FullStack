using Microsoft.EntityFrameworkCore;
using PracticaMvcCore2Iniciales.Data;
using PracticaMvcCore2Iniciales.Models;

namespace PracticaMvcCore2Iniciales.Repositories
{
    public class RepositoryLibros
    {
        private LibrosContext context;
        public RepositoryLibros(LibrosContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> LogInAsync(string email, string password)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(user => user.Email == email && user.Pass == password);
        }
        public async Task<List<Libro>> GetLibrosAsync()
        {
            return await this.context.Libros.ToListAsync();
        }

        public async Task<List<Genero>> GetGenerosAsync()
        {
            return await this.context.Generos.ToListAsync();
        }

        public async Task<List<Libro>> GetLibrosPorGeneroAsync(int idgenero)
        {
            return await this.context.Libros
                .Where(libro => libro.IdGenero == idgenero).ToListAsync();
        }

        public async Task<Libro> BuscarLibroAsync(int idlibro)
        {
            return await this.context.Libros
                .FirstOrDefaultAsync(libro => libro.IdLibro == idlibro);
        }

        public async Task<Usuario> BuscarUsuarioAsync(int idusuario)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(usuario => usuario.IdUsuario == idusuario);
        }

        public async Task<List<Libro>> GetLibrosDelCarroAsync(List<int> carrito)
        {
            return await this.context.Libros
                .Where(libro => carrito.Contains(libro.IdLibro)).ToListAsync();
        }

        public async Task<List<VistaPedido>> GetVistaPedidosAsync(int idusuario)
        {
            return await this.context.VistaPedidos
                .Where(vistaPedidos => vistaPedidos.IdUsuario == idusuario).ToListAsync();
        }

        public async Task FinalCompraAsync(List<int> carrito, int idusuario)
        {
            int idfactura = await MaximaFacturaAsync();
            foreach(int idlibro in carrito.Distinct())
            {
                int idpedido = await MaximoPedidoAsync();
                await this.context.Pedidos.AddAsync(
                    new Pedido
                    {
                        IdPedido = idpedido,
                        IdFactura = idfactura,
                        IdLibro = idlibro,
                        Fecha = DateTime.Now,
                        Cantidad = carrito.Where(id => id == idlibro).Count(),
                        IdUsuario = idusuario
                    }
                );
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<int> MaximaFacturaAsync()
        {
            if(this.context.Pedidos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Pedidos.MaxAsync(p => p.IdFactura) + 1;
            }
        }
        public async Task<int> MaximoPedidoAsync()
        {
            if (this.context.Pedidos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Pedidos.MaxAsync(p => p.IdPedido) + 1;
            }
        }

        public async Task<List<VistaPedido>> GetPedidosAsync(int idusuario)
        {
            return await this.context.VistaPedidos
                .Where(vistaPedidos => vistaPedidos.IdUsuario == idusuario).ToListAsync();
        }
    }
}
