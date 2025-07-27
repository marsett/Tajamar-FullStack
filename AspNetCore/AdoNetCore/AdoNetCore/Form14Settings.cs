using Microsoft.Extensions.Configuration;
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
    public partial class Form14Settings : Form
    {
        public Form14Settings()
        {
            InitializeComponent();
        }

        private void btnLeerSettings_Click(object sender, EventArgs e)
        {
            // Necesitamos un constructor de configuraciones
            ConfigurationBuilder builder = new ConfigurationBuilder();
            // En este entorno no es nativo, por lo que debemos
            // indicar de forma explícita el nombre del fichero y
            // su ubicación
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            // El objeto para recuperar las keys
            IConfigurationRoot configuration = builder.Build();
            // Existen claves que ya vienen por defecto: ConnectionStrings
            string connectionString = configuration.GetConnectionString("SqlTajamar");
            this.lblCadenaConexion.Text = connectionString;
            // Si no es una zona conocida como Imagenes/Colores
            // los datos se recuperan en cascada con cada key/subkey
            string imagen1 = configuration.GetSection("Imagenes:imagen1").Value;
            string imagen2 = configuration.GetSection("Imagenes:imagen2").Value;
            string colorFondo = configuration.GetSection("Colores:fondo").Value;
            string colorLetra = configuration.GetSection("Colores:letra").Value;
            this.pictureBox1.Load(imagen1);
            this.pictureBox2.Load(imagen2);
            this.btnLeerSettings.BackColor = Color.FromName(colorFondo);
            this.btnLeerSettings.ForeColor = Color.FromName(colorLetra);
        }
    }
}
