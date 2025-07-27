using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaMvcCore2Iniciales.Models
{
    #region
    /*
     CREATE OR ALTER VIEW VISTAPEDIDOS 
		AS
		SELECT 
			P.IDPEDIDO AS IDVISTAPEDIDOS,
			U.IdUsuario,
			U.Nombre,
			U.Apellidos,
			L.Titulo,
			L.Precio,
			L.Portada,
			P.FECHA AS Fecha,
			(L.Precio * P.CANTIDAD) AS PrecioFinal
		FROM
			PEDIDOS P
			INNER JOIN USUARIOS U ON P.IDUSUARIO = U.IdUsuario
			INNER JOIN LIBROS L ON P.IDLIBRO = L.IdLibro
     */
    #endregion
    [Table("VISTAPEDIDOS")]
	public class VistaPedido
    {
		[Key]
		[Column("IDVISTAPEDIDOS")]
		public int IdVistaPedidos { get; set; }
		[Column("IdUsuario")]
		public int IdUsuario { get; set; }
		[Column("Nombre")]
		public string Nombre { get; set; }
        [Column("Apellidos")]
        public string Apellidos { get; set; }
		[Column("Titulo")]
		public string Titulo { get; set; }
		[Column("Precio")]
		public int Precio {  get; set; }
		[Column("Portada")]
		public string Portada { get; set; }
		[Column("Fecha")]
		public DateTime Fecha { get; set; }
		[Column("PrecioFinal")]
		public int PrecioFinal { get; set; }
    }
}
