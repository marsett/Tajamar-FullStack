using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPrueba.Models
{
    [Table("Artistas")]
    public class Artista
    {
        [Key]
        [Column("IdArtista")]
        public int IdArtista { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("CancionFavorita")]
        public string CancionFavorita { get; set; }

        [Column("Edad")]
        public int Edad { get; set; }

        [Column("Pais")]
        public string Pais { get; set; }
    }
}
