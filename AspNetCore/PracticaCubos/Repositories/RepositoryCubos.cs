using Microsoft.EntityFrameworkCore;
using PracticaCubos.Data;
using PracticaCubos.Models;

#region
/*
 CREATE TABLE COMPRA (
    id_compra INT NOT NULL,
    id_cubo INT NOT NULL,
    cantidad INT NOT NULL,
    precio INT NOT NULL,
    fechapedido DATETIME NOT NULL
);

CREATE TABLE CUBOS (
    id_cubo INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(500) NOT NULL,
    modelo VARCHAR(500) NOT NULL,
    marca VARCHAR(500) NOT NULL,
    imagen VARCHAR(500) NOT NULL,
    precio INT NOT NULL
);

INSERT INTO COMPRA (id_compra, id_cubo, cantidad, precio, fechapedido) VALUES 
(1, 2, 4, 3, '2022-02-20 02:18:02.090'),
(1, 2, 8, 4, '2022-02-20 02:18:02.307'),
(1, 6, 6, 4, '2022-02-20 02:18:02.437'),
(2, 14, 1, 3, '2022-02-20 14:32:16.723'),
(2, 5, 2, 4, '2022-02-20 14:32:16.890'),
(3, 2, 1, 5, '2022-02-20 20:29:59.257'),
(4, 7, 1, 5, '2022-02-20 20:45:23.100'),
(4, 11, 1, 3, '2022-02-20 20:45:23.277');

INSERT INTO CUBOS (id_cubo, nombre, modelo, marca, imagen, precio) VALUES 
(2, 'Megaminx', 'Megaminx', 'ShengShou Cube', 'shengshou-legend-3x3-s.jpg', 3),
(4, 'Sandwich', 'Gear', 'QiYi MoFangGe', '17c496ece5b2e99c316777d06ef23eb63b433efa_original.jpeg', 3),
(5, 'Mirror 2x2x2', 'Mirror', 'QiYi MoFangGe', '554080103-0.jpg', 4),
(6, 'Meilong Pyraminx', 'Pyraminx', 'MoYu', '4545050103-0.jpg', 4),
(7, 'Fisher cube', 'Fisher', 'QiYi MoFangGe', 'b8912421b62b2be51f17fd3a9bf39a499f580d5e_original.jpeg', 5),
(8, 'Lingpo', '2X2X2', 'MoYu', '61ZhSt6ZshL._SL1001_.jpg', 3),
(9, 'Skewb', 'Skewb', 'ShengShou Cube', 'qiyi-qiheng-skewb.jpg', 5),
(10, 'Yileng Fisher', 'Fisher', 'MoYu', 'qiyi-yileng-fisher-negro.jpg', 6),
(11, 'Megaminx 13x13x13', 'Megaminx', 'ShengShou Cube', '26dfa7e1eca203c545b2d58711ca29ad.jpg', 590),
(12, 'Elephant 2x2x2', '2X2X2', 'QiYi MoFangGe', 'yongjun-special-2x2x2-cube-elephant-blue-35135.jpg', 6),
(14, 'Mastermorphix 3x3x3', 'Mastermorphix', 'ShengShou Cube', 'qiyi-mastermorphix.jpg', 5),
(15, 'Weipo WRS', '2x2x2', 'MoYu', 'moyu-weipo-wrs-m-2x2.jpg', 4),
(16, 'DaYan TengYun', '2x2', 'Dayan', 'dayan-tengyun-2x2-plus-m.jpg', 22),
(17, 'Qiyi Wuxia', '2x2', 'Qiyi', 'qiyi-wuxia-2x2-magnetico.jpg', 18);
 */
#endregion

namespace PracticaCubos.Repositories
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
            string sql = "CALL GetAllCubos();";
            var consulta = await this.context.Cubo
                            .FromSqlRaw(sql)
                            .ToListAsync();
            return consulta;
        }

        public async Task<Cubo> FindCuboAsync(int id)
        {
            var consulta = from datos in this.context.Cubo
                           where datos.IdCubo == id
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task UpdateCuboAsync(int idCubo, string nombre,
            string modelo, string marca, string imagen, int precio)
        {
            Cubo cubo = await this.FindCuboAsync(idCubo);
            cubo.Nombre = nombre;
            cubo.Modelo = modelo;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            await this.context.SaveChangesAsync();
        }

        public async Task InsertCuboAsync(string nombre,
            string modelo, string marca, string imagen, int precio)
        {
            Cubo cubo = new Cubo();
            int maxId = await this.context.Cubo.MaxAsync(c => c.IdCubo);
            cubo.IdCubo = maxId + 1;
            cubo.Nombre = nombre;
            cubo.Modelo = modelo;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            await this.context.Cubo.AddAsync(cubo);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<Cubo>> GetCubosSessionAsync(List<int> ids)
        {
            var consulta = from datos in this.context.Cubo
                           where ids.Contains(datos.IdCubo)
                           select datos;
            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return await consulta.ToListAsync();
            }
        }

        public async Task<List<VistaCompra>> GetComprasRealizadasAsync()
        {

            string sql = "CALL SP_VistaCompras();";
            var compras = await this.context.VistaCompra.FromSqlRaw(sql).ToListAsync();
            return compras;
        }

        public async Task<int> GetMaxIdCompraAsync()
        {
            return await this.context.Compra.MaxAsync(c => c.IdCompra);
        }

        public async Task InsertCompra(Compra compra)
        {
            await this.context.Compra.AddAsync(compra);
            await this.context.SaveChangesAsync();
        }

    }
}
