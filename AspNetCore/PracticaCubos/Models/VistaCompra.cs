using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaCubos.Models
{
    [Table("VISTACOMPRAS")]
    public class VistaCompra
    {
        [Key]
        [Column("IdCompra")]
        public int IdCompra { get; set; }
        [Column("IdCubo")]
        public int IdCubo {  get; set; }
        [Column("NombreCubo")]
        public string NombreCubo { get; set; }
        [Column("PrecioIndividual")]
        public int PrecioIndividual { get; set; }
        [Column("CantidadComprada")]
        public int CantidadComprada { get; set; }
        [Column("PrecioFinal")]
        public int PrecioFinal { get; set; }
        [Column("FechaPedido")]
        public DateTime FechaPedido { get; set; }
    }
}
