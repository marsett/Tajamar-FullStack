using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundamentosNetCore
{
    public partial class Form18SumarBotones : Form
    {
        List<Button> botones;
        int suma;
        public Form18SumarBotones()
        {
            InitializeComponent();
            this.botones = new List<Button>();
            this.suma = 0;
            // Almacenamos todos los controles del panel
            // dentro de nuestra colección
            foreach (Button boton in this.panel1.Controls)
            {
                this.botones.Add(boton);
                boton.Click += SumarNumeros;
            }
        }

        void SumarNumeros(object sender, EventArgs e)
        {
            // Capturamos el botón
            Button boton = (Button)sender;
            int numero = int.Parse(boton.Text);
            this.suma += numero;
            this.txtSuma.Text = suma.ToString();
        }

        private void btnIniciarApp_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            this.suma = 0;
            this.txtSuma.Text = suma.ToString();
            // Recorremos todos los botones de mi colección
            foreach(Button boton in this.botones)
            {
                int numAleat = random.Next(1, 99);
                boton.Text = numAleat.ToString();
            }
        }
    }
}
