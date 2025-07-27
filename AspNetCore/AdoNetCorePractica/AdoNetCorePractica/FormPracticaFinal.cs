using AdoNetCorePractica.Models;
using AdoNetCorePractica.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetCorePractica
{
    public partial class FormPracticaFinal : Form
    {
        private RepositoryDepartamentosEmpleados repo;
        public FormPracticaFinal()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentosEmpleados();
            this.CargarDepartamentos();
        }

        public async Task CargarDepartamentos()
        {
            List<string> nombres = await this.repo.GetListaDepartamentosAsync();
            this.cmbDepartamentos.Items.Clear();
            foreach (string nombre in nombres)
            {
                this.cmbDepartamentos.Items.Add(nombre);
            }
        }

        private async Task CargarEmpleados(string departamentoSeleccionado)
        {
            this.lstEmpleados.Items.Clear();
            this.txtApellido.Clear();
            this.txtOficio.Clear();
            this.txtSalario.Clear();
            DatosDepartamentosEmpleados datos = await this.repo.GetEmpleadosAsync(departamentoSeleccionado);
            this.txtId.Text = datos.Departamento.Id.ToString();
            this.txtNombre.Text = datos.Departamento.Nombre;
            this.txtLocalidad.Text = datos.Departamento.Localidad;
            foreach (Empleado dato in datos.Empleados)
            {
                if (dato.Salario == 0)
                {
                    this.lstEmpleados.Items.Add("No existen empleados");
                }
                else
                {
                    this.lstEmpleados.Items.Add(dato.Apellido + " - " + dato.Oficio + " - " + dato.Salario);
                }
            }
        }


        private async void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDepartamentos.SelectedIndex != -1)
            {
                string departamentoSeleccionado = this.cmbDepartamentos.SelectedItem.ToString();
                this.CargarEmpleados(departamentoSeleccionado);
            }
        }

        private async void btnInsertarDepartamento_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;
            await this.repo.InsertDepartamentoAsync(id, nombre, localidad);
            this.CargarDepartamentos();
        }

        private async void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedIndex != -1)
            {
                string seleccionado = this.lstEmpleados.SelectedItem.ToString();
                string apellido = seleccionado.Split('-')[0].Trim();
                Empleado empleado = await this.repo.GetEmpleadoAsync(apellido);
                this.txtApellido.Text = empleado.Apellido;
                this.txtOficio.Text = empleado.Oficio;
                this.txtSalario.Text = empleado.Salario.ToString();
            }
        }

        private async void btnUpdateEmpleado_Click(object sender, EventArgs e)
        {
            string departamentoSeleccionado = this.cmbDepartamentos.SelectedItem.ToString();
            string seleccionado = this.lstEmpleados.SelectedItem.ToString();
            string apellidoAntiguo = seleccionado.Split('-')[0].Trim();
            string apellidoNuevo = this.txtApellido.Text;
            string oficio = this.txtOficio.Text.Trim();
            int salario = int.Parse(this.txtSalario.Text);
            await this.repo.UpdateEmpleadoAsync(apellidoAntiguo, apellidoNuevo, oficio, salario);
            this.CargarEmpleados(departamentoSeleccionado);
        }
    }
}
