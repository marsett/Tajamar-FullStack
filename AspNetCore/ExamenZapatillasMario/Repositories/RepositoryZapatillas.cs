using ExamenZapatillasMario.Data;
using ExamenZapatillasMario.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

#region
/*
 create procedure SP_PAGINAR_IMAGENES_ZAPATILLAS
(@idproducto int, @posicion int, @registros INT)
as
	select * from
	(
		select cast(ROW_NUMBER() over (order by IDIMAGEN) AS INT) AS POSICION,
		IDIMAGEN, IDPRODUCTO, IMAGEN
		FROM IMAGENESZAPASPRACTICA
		WHERE IDPRODUCTO = @idproducto
	) as query
	where QUERY.POSICION >= @posicion AND QUERY.POSICION < (@posicion + @registros)
go
 */
#endregion

namespace ExamenZapatillasMario.Repositories
{
    public class RepositoryZapatillas
    {
        private ZapatillasContext context;
        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }
        public async Task<List<ZapasPractica>> GetZapatillasAsync()
        {
            List<ZapasPractica> zapatillas = await this.context.ZapasPractica
                .ToListAsync();
            return zapatillas;
        }

        public async Task<ZapasPractica> FindZapatillaAsync(int idproducto)
        {
            ZapasPractica zapatilla = await this.context.ZapasPractica
                .FirstOrDefaultAsync(z => z.IdProducto == idproducto);
            return zapatilla;
        }

        public async Task<List<ImagenesZapasPractica>> GetImagenesZapatillaAsync(int idproducto)
        {
            List<ImagenesZapasPractica> imagenes = await this.context.ImagenesZapasPractica
                .Where(i => i.IdProducto == idproducto)
                .ToListAsync();
            return imagenes;
        }

        public async Task<List<ImagenesZapasPractica>> GetImagenesPaginacionAsync(int idproducto, int posicion, int registros)
        {
            string sql = "SP_PAGINAR_IMAGENES_ZAPATILLAS @idproducto, @posicion, @registros";
            SqlParameter pamIdProducto = new SqlParameter("@idproducto", idproducto);
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            SqlParameter pamRegistros = new SqlParameter("@registros", registros);

            var consulta = this.context.ImagenesZapasPractica
                .FromSqlRaw(sql, pamIdProducto, pamPosicion, pamRegistros);

            return await consulta.ToListAsync();
        }

        public async Task<int> GetNumeroImagenesAsync(int idproducto)
        {
            return await this.context.ImagenesZapasPractica
                .Where(i => i.IdProducto == idproducto)
                .CountAsync();
        }
    }
}
