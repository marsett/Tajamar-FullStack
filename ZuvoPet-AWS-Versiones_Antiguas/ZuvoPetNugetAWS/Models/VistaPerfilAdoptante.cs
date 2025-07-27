using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace ZuvoPetNugetAWS.Models
{
    [Table("V_AdoptantePerfil")]
    public class VistaPerfilAdoptante
    {
        [Key]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("NombreUsuario")]
        public string NombreUsuario { get; set; }
        [Required]
        [Column("Email")]
        public string Email { get; set; }
        [Column("FotoPerfil")]
        public string FotoPerfil { get; set; }
        [Column("Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("TipoVivienda")]
        public string TipoVivienda { get; set; }
        [Column("TieneJardin")]
        public bool TieneJardin { get; set; }
        [Column("OtrosAnimales")]
        public bool OtrosAnimales { get; set; }

        // Almacena el JSON de la base de datos
        [Column("RecursosDisponibles")]
        [Browsable(false)]
        public string RecursosDisponiblesJson { get; set; }

        // No se mapea a la base de datos, se deserializa desde el JSON
        [NotMapped]
        public List<string> RecursosDisponibles
        {
            get => string.IsNullOrEmpty(RecursosDisponiblesJson)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(RecursosDisponiblesJson);
            set => RecursosDisponiblesJson = JsonSerializer.Serialize(value);
        }

        [Column("TiempoEnCasa")]
        public string TiempoEnCasa { get; set; }
    }
}
