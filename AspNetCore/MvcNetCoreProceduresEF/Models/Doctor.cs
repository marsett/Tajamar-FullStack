using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcNetCoreProceduresEF.Models
{
    [Table("DOCTOR")]
    public class Doctor
    {
        [Column("HOSPITAL_COD")]
        public int Hospital_Cod { get; set; }
        [Key]
        [Column("DOCTOR_NO")]
        public int Doctor_No { get; set; }
        [Column("APELLIDO")]
        public string Apellido { get; set; }
        [Column("ESPECIALIDAD")]
        public string Especialidad { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
