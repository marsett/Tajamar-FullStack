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
    public partial class Form09Isbn : Form
    {
        public Form09Isbn()
        {
            InitializeComponent();
        }

        private void btnValidarISBN_Click(object sender, EventArgs e)
        {
            string isbn = this.txtISBN.Text;
            int longitud = isbn.Length;
            int contador = 0;

            if (longitud == 10)
            {
                for(int i = 0; i < isbn.Length; i++)
                {
                    int numero = int.Parse(isbn[i].ToString());
                    int multiplicacion = numero * (i + 1);
                    contador += multiplicacion;
                }
                if(contador % 11 == 0)
                {
                    this.lblResultado.Text = "ISBN correcto";
                    this.lblResultado.ForeColor = Color.Blue;
                }
                else
                {
                    this.lblResultado.Text = "ISBN incorrecto";
                    this.lblResultado.ForeColor = Color.Red;
                }
            }
            else
            {
                this.lblResultado.Text = "El ISBN debe tener 10 caracteres";
            }
        }
    }
}
