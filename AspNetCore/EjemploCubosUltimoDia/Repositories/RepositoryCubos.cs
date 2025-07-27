using EjemploCubosUltimoDia.Data;
using EjemploCubosUltimoDia.Models;
using Microsoft.EntityFrameworkCore;

#region
/*
 ALTER VIEW VistaCompras AS
SELECT 
    C.id_compra,
    C.nombre_cubo,
    C.precio,
    C.fechapedido as fechacompra,
    U.id_user,
    U.nombre AS nombre_usuario,
    U.email,
    CB.id_cubo,
    CB.modelo,
    CB.marca,
    CB.imagen,
    C.precio AS precio_final
FROM COMPRA C
LEFT JOIN USUARIOS U ON U.id_user = C.id_compra
LEFT JOIN CUBOS CB ON CB.nombre = C.nombre_cubo;
 */
#endregion

namespace EjemploCubosUltimoDia.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;
        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<List<Compra>> GetComprasAsync()
        {
            return await this.context.Compras.ToListAsync();
        }

        public async Task<List<string>> GetMarcasAsync()
        {
            return await this.context.Cubos
                .Select(c => c.Marca)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Cubo>> GetCubosByMarcaAsync
            (string marca)
        {
            return await this.context.Cubos
                .Where(l => l.Marca == marca)
                .ToListAsync();
        }

        public async Task<List<VistaCompra>> GetVistaPedidosAsync
            (int idusuario)
        {
            return await this.context.VistaCompras
                .Where(vp => vp.IdUsuario == idusuario)
                .ToListAsync();
        }

        public async Task<Cubo> FindCuboAsync(int idcubo)
        {
            return await this.context.Cubos
                .FirstOrDefaultAsync(l => l.IdCubo == idcubo);
        }

        public async Task<Usuario> FindUsuarioAsync(int idusuario)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(u => u.IdUser == idusuario);
        }

        public async Task<Usuario> LoginUsuarioAsync
            (string email, string password)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email &&
                u.Password == password);
        }

        public async Task<List<Cubo>> GetCubosCarritoAsync
            (List<int> carrito)
        {
            return await this.context.Cubos
                .Where(l => carrito.Contains(l.IdCubo))
                .ToListAsync();
        }

        public async Task<int> GetMaxIdCompraAsync()
        {
            return await this.context.Compras.MaxAsync(c => c.IdCompra) + 1;
        }

        public async Task FinalizarCompraAsync(List<int> carrito, int idusuario)
        {
            int idcompra = await GetMaxIdCompraAsync();
            DateTime fechaPedido = DateTime.Now;

            foreach (int idcubo in carrito.Distinct())
            {
                var infoCubo = await FindCuboAsync(idcubo);

                await this.context.Compras.AddAsync
                    (new Compra
                    {
                        IdCompra = idcompra,
                        NombreCubo = infoCubo.Nombre,
                        Precio = infoCubo.Precio,
                        FechaPedido = fechaPedido
                    });

                await this.context.SaveChangesAsync();
                idcompra++;
            }
        }

        public async Task<List<VistaCompra>> GetComprasUsuarioAsync
            (int idusuario)
        {
            return await this.context.VistaCompras
                .Where(vp => vp.IdUsuario == idusuario)
                .ToListAsync();
        }
    }
}
