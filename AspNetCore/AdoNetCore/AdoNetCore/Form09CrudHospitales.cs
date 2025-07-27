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
    public partial class Form09CrudHospitales : Form
    {
        private RepositoryHospital repo;
        public Form09CrudHospitales()
        {
            InitializeComponent();
            this.repo = new RepositoryHospital();
            this.LoadHospitales();
        }

        private async void LoadHospitales()
        {
            List<Hospital> hospitales = await this.repo.GetHospitalesAsync();
            this.lstHospitales.Items.Clear();
            foreach (Hospital hospital in hospitales)
            {
                this.lstHospitales.Items.Add(hospital.Hospital_Cod + " - " +
                    hospital.Nombre + " - " + hospital.Direccion + " - " +
                    hospital.Telefono + " - " + hospital.Num_Cama);
            }
        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            int hospital_cod = int.Parse(this.txtHospitalCod.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int num_cama = int.Parse(this.txtNumCama.Text);
            await this.repo.InsertHospitalAsync(hospital_cod, nombre, direccion, telefono, num_cama);
            this.LoadHospitales();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int hospital_cod = int.Parse(this.txtHospitalCod.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int num_cama = int.Parse(this.txtNumCama.Text);
            await this.repo.UpdateHospitalAsync(hospital_cod, nombre, direccion, telefono, num_cama);
            this.LoadHospitales();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int hospital_cod = int.Parse(this.txtHospitalCod.Text);
            await this.repo.DeleteHospitalAsync(hospital_cod);
            this.LoadHospitales();
        }
    }
}
