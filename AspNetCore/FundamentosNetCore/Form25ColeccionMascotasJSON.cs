using ProyectoClases;
using ProyectoClases.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.Json;

namespace FundamentosNetCore
{
    public partial class Form25ColeccionMascotasJSON : Form
    {
        ColeccionMascotas mascotasList;
        public Form25ColeccionMascotasJSON()
        {
            InitializeComponent();

            this.mascotasList = new ColeccionMascotas();
        }
        private void DibujarMascotas()
        {
            this.lstMascotas.Items.Clear();
            foreach (Mascota mascota in this.mascotasList)
            {
                this.lstMascotas.Items.Add(mascota.Nombre);
            }
        }

        private void btnNuevaMascota_Click(object sender, EventArgs e)
        {
            Mascota mascota = new Mascota
            {
                Nombre = this.txtNombre.Text,
                Raza = this.txtRaza.Text,
                Years = int.Parse(this.txtAnos.Text)
            };
            this.mascotasList.Add(mascota);
            this.DibujarMascotas();
            this.txtNombre.Clear();
            this.txtRaza.Clear();
            this.txtAnos.Clear();
        }

        private async void btnGuardarMascotas_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("mascotaslist.json"))
            {
                string json = JsonSerializer.Serialize(this.mascotasList);
                await writer.WriteAsync(json);
                writer.Close();
                this.lstMascotas.Items.Clear();
                this.mascotasList.Clear();
            }
        }

        private async void btnLeerMascotas_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("mascotaslist.json"))
            {
                string json = await reader.ReadToEndAsync();
                this.mascotasList = JsonSerializer.Deserialize<ColeccionMascotas>(json);
                reader.Close();
                this.DibujarMascotas();
            }
        }

        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.lstMascotas.SelectedIndex;
            if (index != -1)
            {
                Mascota mascota = this.mascotasList[index];
                this.txtNombre.Text = mascota.Nombre;
                this.txtRaza.Text = mascota.Raza;
                this.txtAnos.Text = mascota.Years.ToString();
            }
        }
    }
}
