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
    public partial class Form15Metodos : Form
    {
        public Form15Metodos()
        {
            InitializeComponent();
        }

        // Recibimos un número wrapper por valor
        void GetDobleValor(int num)
        {
            num = num * 2;
        }

        private void btnDobleValor_Click(object sender, EventArgs e)
        {
            int numero = int.Parse(this.txtNumero.Text);
            this.GetDobleValor(numero);
            this.lblResultado.Text = numero.ToString();
        }

        void CambiarColor(Button boton)
        {
            boton.BackColor = Color.LightGreen;
        }

        private void btnObjetoReferencia_Click(object sender, EventArgs e)
        {
            this.CambiarColor(this.btnDobleReferencia);
            this.CambiarColor(this.btnDobleValor);
        }

        void GetDobleReferencia(ref int num)
        {
            num = num * 2;
        }

        int GetDoble(int num)
        {
            return num * 2;
        }

        private void btnDobleReferencia_Click(object sender, EventArgs e)
        {
            int numero = int.Parse(this.txtNumero.Text);
            numero = this.GetDoble(numero);
            // Las dos variables apuntan al mismo espacio de memoria
            this.GetDobleReferencia(ref numero);
            this.lblResultado.Text = numero.ToString();
        }

        private void MetodoEvento(object sender, EventArgs e)
        {

        }

        private void Form15Metodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.lblRaton.Text = "X: " + e.X + ", Y: " + e.Y;
        }

        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Como no podemos eliminar, debemos también admitir
            // la tecla se borrar (tenemos un char), debemos saber
            // qué tecla traducida a char corresponde con la de borrar
            // existe una enumeración llamada keys que nos ofrece los
            // códigos ascii de todas las teclas
            char teclaBorrar = (char)Keys.Back;
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != teclaBorrar)
            {
                e.Handled = true;
            }
        }

        private void txtSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            char teclaBorrar = (char)Keys.Back;
            if (char.IsLetter(e.KeyChar) == false && e.KeyChar != teclaBorrar)
            {
                e.Handled = true;
            }
        }
    }
}
