using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoClases;

namespace FundamentosNetCore
{
    public partial class Form20TestClases : Form
    {
        public Form20TestClases()
        {
            InitializeComponent();
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombre = "Alumno";
            persona.Apellidos = "Navidad";
            persona.Edad = 25;
            persona.Genero = TipoGenero.Femenino;

            this.lstClases.Items.Add("Indizada " + persona[0]);
            this.lstClases.Items.Add("Indizada " + persona[33]);

            persona.Nacionalidad = Paises.Euskalherria;

            persona.Domicilio = new Direccion();
            persona.Domicilio.Calle = "Oficina principal de Correos";
            persona.Domicilio.Ciudad = "Napapiiri, Finlandia";
            persona.Domicilio.CodigoPostal = 96930;

            this.lstClases.Items.Add("Dirección: "
                + persona.Domicilio.Calle
                + ", " + persona.Domicilio.Ciudad
                + ", " + persona.Domicilio.CodigoPostal);

            this.lstClases.Items.Add("Nombre: " +
                persona.Nombre + ", Apellidos: " +
                persona.Apellidos);
            this.lstClases.Items.Add("Edad: " + persona.Edad);
            this.lstClases.Items.Add("Género: " + persona.Genero
                + ", Nacionalidad: " + persona.Nacionalidad);
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            //Empleado empleado = new Empleado("Empleado", "Empleado");
            Empleado empleado = new Empleado();
            empleado.Nombre = "Empleado";
            empleado.Apellidos = "Empleado";

            this.lstClases.Items.Add(empleado.GetNombreCompleto());
            this.lstClases.Items.Add("Vacaciones Empleado " + empleado.GetDiasVacaciones());
            this.lstClases.Items.Add("Salario empleado " + empleado.GetSalarioMinimo());

            Director dire = new Director();
            dire.Nombre = "Dire";
            dire.Apellidos = "Director";
            this.lstClases.Items.Add(dire.GetNombreCompleto());
            this.lstClases.Items.Add("Salario Dire " + dire.GetSalarioMinimo());
            this.lstClases.Items.Add("Vacaciones Director " + dire.GetDiasVacaciones());
        }
    }
}
