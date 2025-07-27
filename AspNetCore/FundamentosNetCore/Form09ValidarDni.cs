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
    public partial class Form09ValidarDni : Form
    {
        public Form09ValidarDni()
        {
            InitializeComponent();
        }

        private void btnValidarDni_Click(object sender, EventArgs e)
        {
            string dni = this.txtDni.Text;
            int longitud = dni.Length;
            char[] letras = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

            if (longitud == 9)
            {
                string numeros = dni.Substring(0, 8);
                char letraDni = dni[8];
                int numeroDni = int.Parse(numeros);
                
                int indiceLetra = numeroDni % 23;
                char letraEsperada = letras[indiceLetra];

                if (letraEsperada == letraDni)
                {
                    this.lblResultado.Text = "DNI válido";
                }
                else
                {
                    this.lblResultado.Text = "La letra del DNI no coincide";
                }
            }
            else
            {
                this.lblResultado.Text = "El DNI debe tener 9 caracteres";
            }
        }

    }
}
