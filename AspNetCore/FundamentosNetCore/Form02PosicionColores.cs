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
    public partial class Form02PosicionColores : Form
    {
        public Form02PosicionColores()
        {
            InitializeComponent();
        }

        private void btnCambiarPosicion_Click(object sender, EventArgs e)
        {
            int posicionx = int.Parse(this.txtPosicionX.Text);
            int posiciony = int.Parse(this.txtPosicionY.Text);

            this.btnCambiarPosicion.Location = new Point(posicionx, posiciony);
        }

        private void btnCambiarColor_Click(object sender, EventArgs e)
        {
            int rojo = int.Parse(this.txtRojo.Text);
            int verde = int.Parse(this.txtVerde.Text);
            int azul = int.Parse(this.txtAzul.Text);
            if (rojo < 0 || rojo > 255)
            {
                MessageBox.Show("El valor rojo debe estar entre 0 y 255", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
            }
            else if (azul < 0 || azul > 255)
            {
                MessageBox.Show("El valor azul debe estar entre 0 y 255", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
            }
            else
            {
                this.BackColor = Color.FromArgb(rojo, verde, azul);
            }
        }
    }
}
