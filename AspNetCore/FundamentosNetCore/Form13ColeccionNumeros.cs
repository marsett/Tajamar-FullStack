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
    public partial class Form13ColeccionNumeros : Form
    {
        public Form13ColeccionNumeros()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.lstNumeros.Items.Clear();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int numeroRandom = rnd.Next(0, 10);
                this.lstNumeros.Items.Add(numeroRandom);
            }
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            int suma = 0;
            int pares = 0;
            int impares = 0;
            foreach (int item in this.lstNumeros.Items)
            {
                Console.WriteLine(item);
                suma += item;

                if (item % 2 == 0)
                {
                    pares += item;
                }else
                {
                    impares += item;
                }
            }
            this.txtSuma.Text = suma.ToString();
            this.txtPares.Text = pares.ToString();
            this.txtImpares.Text = impares.ToString();
        }
    }
}
