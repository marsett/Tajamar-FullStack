using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundamentosNetCore
{
    public partial class Form08StringBuilder : Form
    {
        public Form08StringBuilder()
        {
            InitializeComponent();
        }

        private void btnInvertirString_Click(object sender, EventArgs e)
        {
            Stopwatch krono = new Stopwatch();
            string cadena = this.txtTexto.Text;
            int longitud = cadena.Length;
            krono.Start();
            for (int i = 0; i < cadena.Length; i++)
            {
                // Recuperamos la última letra
                char letra = cadena[longitud - 1];
                // Eliminamos la última letra
                cadena = cadena.Remove(longitud - 1, 1);
                // Insertamos la letra en la posición del bucle
                cadena = cadena.Insert(i, letra.ToString());
            }
            krono.Stop();
            // El objeto krono contiene una serie de propiedades
            // para saber el tiempo que ha pasado
            this.lblTiempo.Text = "Segundos: " +
                krono.Elapsed.Seconds +
                ", Milisegundos: " +
                krono.Elapsed.Milliseconds;
            this.txtTexto.Text = cadena;
        }

        private void btnInvertirStringBuilder_Click(object sender, EventArgs e)
        {
            // StringBuilder se utiliza para grandes cantidades de texto.
            Stopwatch krono = new Stopwatch();
            StringBuilder cadena = new StringBuilder();
            // Para añadir contenido al StringBuilder
            cadena.Append(this.txtTexto.Text);
            int longitud = cadena.Length;
            krono.Start();
            for (int i = 0; i < cadena.Length; i++)
            {
                char letra = cadena[longitud - 1];
                cadena = cadena.Remove(longitud - 1, 1);
                cadena = cadena.Insert(i, letra);
            }
            krono.Stop();
            this.lblTiempo.Text = "Segundos: " +
                krono.Elapsed.Seconds +
                ", Milisegundos: " +
                krono.Elapsed.Milliseconds;
            this.txtTexto.Text = cadena.ToString();
        }
    }
}
