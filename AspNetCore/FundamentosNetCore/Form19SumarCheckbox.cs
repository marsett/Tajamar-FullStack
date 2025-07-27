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
    public partial class Form19SumarCheckbox : Form
    {
        List<CheckBox> checkboxs;
        int suma;

        public Form19SumarCheckbox()
        {
            InitializeComponent();
            this.checkboxs = new List<CheckBox>();
            this.suma = 0;

            foreach (CheckBox checkbox in this.panel1.Controls)
            {
                this.checkboxs.Add(checkbox);
                checkbox.CheckedChanged += ActualizarSuma;
            }
        }

        private void btnIniciarApp_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            this.suma = 0;
            this.txtSuma.Text = this.suma.ToString();

            foreach (CheckBox checkbox in this.checkboxs)
            {
                int numAleat = random.Next(1, 99);
                checkbox.Text = numAleat.ToString();
                checkbox.Checked = false;
            }
        }

        private void ActualizarSuma(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            int numero = int.Parse(checkbox.Text);

            if (checkbox.Checked)
            {
                this.suma += numero;
            }
            else
            {
                this.suma -= numero;
            }

            this.txtSuma.Text = this.suma.ToString();
        }
    }
}
