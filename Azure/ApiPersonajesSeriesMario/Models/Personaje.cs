﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPersonajesSeriesMario.Models
{
    [Table("PERSONAJES")]
    public class Personaje
    {
        [Key]
        [Column("IDPERSONAJE")]
        public int IdPersonaje { get; set; }

        [Column("PERSONAJE")]
        public string Nombre { get; set; }

        [Column("IMAGEN")]
        public string Imagen { get; set; }

        [Column("IDSERIE")]
        public int IdSerie { get; set; }

    }
}
