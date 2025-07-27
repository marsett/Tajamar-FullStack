using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploCubosUltimoDia.Models
{
    [Table("VistaCompras")]
    public class VistaCompra
    {
        [Key]
        [Column("id_compra")]
        public int IdCompra { get; set; }

        [Column("nombre_cubo")]
        public string NombreCubo { get; set; }

        [Column("precio")]
        public int Precio { get; set; }

        [Column("fechacompra")]
        public DateTime FechaCompra { get; set; }

        [Column("id_user")]
        public int IdUsuario { get; set; }

        [Column("nombre_usuario")]
        public string NombreUsuario { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("id_cubo")]
        public int IdCubo { get; set; }

        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }
        [Column("precio_final")]
        public int PrecioFinal { get; set; }
    }
}
