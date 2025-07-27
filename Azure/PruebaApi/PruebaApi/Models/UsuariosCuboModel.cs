﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaApi.Models
{
    [Table("USUARIOSCUBO")]
    public class UsuariosCuboModel
    {
        [Key]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("PASS")]
        public string Pass { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
    }
}
