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
    public partial class FormHospitales : Form
    {
        private RepositoryHospitalesEmpleados repo;
        public FormHospitales()
        {
            InitializeComponent();
            this.repo = new RepositoryHospitalesEmpleados();
            this.CargarHospitales();
        }

        private async Task CargarHospitales()
        {
            ListaHospitales nombres = await this.repo.GetHospitalesAsync();
            this.cmbHospitales.Items.Clear();
            foreach (string nombre in nombres.Hospitales)
            {
                this.cmbHospitales.Items.Add(nombre);
            }
        }

        private async void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbHospitales.SelectedIndex != -1)
            {
                string hospitalSeleccionado = this.cmbHospitales.SelectedItem.ToString();
                this.lstEmpleadosHospital.Items.Clear();
                DatosEmpleadosHospital datos = await this.repo.GetDatosEmpleadosAsync(hospitalSeleccionado);
                foreach (Empleado dato in datos.Empleados)
                {
                    this.lstEmpleadosHospital.Items.Add(dato.Apellido + " - " + dato.Oficio + " - " + dato.Salario);
                }
                this.txtSumaSalarial.Text = datos.SumaSalarial.ToString();
                this.txtMediaSalarial.Text = datos.MediaSalarial.ToString();
                this.txtPersonas.Text = datos.Personas.ToString();
            }
        }
    }
}
