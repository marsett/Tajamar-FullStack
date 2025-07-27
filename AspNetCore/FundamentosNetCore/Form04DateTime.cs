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
    public partial class Form04DateTime : Form
    {
        public Form04DateTime()
        {
            InitializeComponent();
            // Al iniciar la clase (constructor), escribiremos la fecha actual
            this.txtFechaActual.Text = DateTime.Now.ToString();
        }

        private void chkCambiarFormato_CheckedChanged(object sender, EventArgs e)
        {
            // Recuperamos la fecha de la caja
            DateTime fecha = DateTime.Parse(this.txtFechaActual.Text);
            if (this.chkCambiarFormato.Checked == true)
            {
                this.txtFechaActual.Text = fecha.ToLongDateString();
            }
            else
            {
                this.txtFechaActual.Text = fecha.ToShortDateString();
            }
        }

        private void btnIncrementar_Click(object sender, EventArgs e)
        {
            int incremento = int.Parse(this.txtIncremento.Text);
            DateTime fecha = DateTime.Parse(this.txtFechaActual.Text);
            if (this.rbDias.Checked == true)
            {
                fecha = fecha.AddDays(incremento);
            }
            else if (this.rbMes.Checked == true)
            {
                fecha = fecha.AddMonths(incremento);
            }
            else
            {
                fecha = fecha.AddYears(incremento);
            }
            this.txtNuevaFecha.Text = fecha.ToString();
        }
    }
}
