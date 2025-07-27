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
    public partial class Form07SumarNumerosString : Form
    {
        public Form07SumarNumerosString()
        {
            InitializeComponent();
        }

        private void btnSumarNumeros_Click(object sender, EventArgs e)
        {
            string textoNumeros = this.txtNumeros.Text;
            int suma = 0;
            for (int i = 0; i < textoNumeros.Length; i++)
            {
                // Recuperamos cada uno de los caracteres
                char caracter = textoNumeros[i];
                // Convertimos el carácter a número
                // Con esta conversión está recuperando el valor
                // ASCII del número
                //int numero = caracter;

                //int numero = int.Parse(caracter.ToString());
                int numero = Convert.ToInt32(caracter.ToString());
                suma += numero;
            }
            this.lblResultado.Text = "La suma es " + suma;
        }
    }
}
