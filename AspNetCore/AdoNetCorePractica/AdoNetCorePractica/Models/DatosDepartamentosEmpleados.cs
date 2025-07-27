using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetCorePractica.Models
{
    public class DatosDepartamentosEmpleados
    {
        public Departamento Departamento { get; set; }
        public List<Empleado> Empleados { get; set; }
    }
}
