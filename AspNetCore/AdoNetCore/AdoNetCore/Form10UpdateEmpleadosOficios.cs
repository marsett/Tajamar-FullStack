using AdoNetCore.Models;
using AdoNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetCore
{
    public partial class Form10UpdateEmpleadosOficios : Form
    {
        RepositoryUpdateEmpleados repo;
        public Form10UpdateEmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryUpdateEmpleados();
            this.LoadOficios();
        }

        private async Task LoadOficios()
        {
            List<string> oficios = await this.repo.GetOficiosAsync();
            this.lstOficios.Items.Clear();
            foreach (string ofi in oficios)
            {
                this.lstOficios.Items.Add(ofi);
            }
        }

        private async void lstOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lstOficios.SelectedIndex != -1)
            {
                string oficio = this.lstOficios.SelectedItem.ToString();
                await this.LoadEmpleados(oficio);
                DatosEmpleadosOficios datos = await this.repo.GetDatosEmpleadosOficiosAsync(oficio);
                this.lblSumaSalarial.Text = "Suma: " + datos.SumaSalarial;
                this.lblMediaSalarial.Text = "Media: " + datos.MediaSalarial;
                this.lblMaximoSalario.Text = "Máximo: " + datos.MaximoSalario;
            }
        }

        private async Task LoadEmpleados(string oficio)
        {
            List<string> empleados = await this.repo.GetEmpleadosOficioAsync(oficio);
            this.lstEmpleados.Items.Clear();
            foreach(string ape in empleados)
            {
                this.lstEmpleados.Items.Add(ape);
            }
        }

        private async void btnIncrementarSalarios_Click(object sender, EventArgs e)
        {
            int incremento = int.Parse(this.txtIncremento.Text);
            string newOficio = this.txtOficio.Text;
            string oldOficio = this.lstOficios.SelectedItem.ToString();
            int modificados = await this.repo.UpdateSalarioEmpleadosOficio(oldOficio, newOficio, incremento);
            MessageBox.Show("Salarios modificados " + modificados);
            await this.LoadOficios();
            DatosEmpleadosOficios datos = await this.repo.GetDatosEmpleadosOficiosAsync(newOficio);
            this.lblSumaSalarial.Text = "Suma: " + datos.SumaSalarial;
            this.lblMediaSalarial.Text = "Media: " + datos.MediaSalarial;
            this.lblMaximoSalario.Text = "Máximo: " + datos.MaximoSalario;
        }
    }
}
