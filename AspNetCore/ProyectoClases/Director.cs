using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoClases
{
    public class Director: Empleado
    {
        public Director() 
        {
            Debug.WriteLine("Constructor DIRECTOR");
            this.SalarioMinimo += 200;
        }

        // Método sobrescrito
        public override int GetDiasVacaciones()
        {
            Debug.WriteLine("GetVacaciones() DIRECTOR");
            int vacacionesEmpleado = base.GetDiasVacaciones();
            return vacacionesEmpleado + 8;
        }

        // Método implementado
        public int GetDiasVacaciones(int extras)
        {
            return this.GetDiasVacaciones() + extras;
        }
    }
}
