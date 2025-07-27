namespace MvcNetCorePaginacionRegistros.Models
{
    public class ModelEmpleadosDepartamento
    {
        public Departamento Departamento { get; set; }
        public List<Empleado> Empleados { get; set; }
        public int NumeroRegistros { get; set; }
        public int Posicion { get; set; }
    }
}
