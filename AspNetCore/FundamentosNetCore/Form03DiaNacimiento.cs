using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FundamentosNetCore
{
    public partial class Form03DiaNacimiento : Form
    {
        public Form03DiaNacimiento()
        {
            InitializeComponent();
        }

        private void btnCalcularDia_Click(object sender, EventArgs e)
        {
            int dia = int.Parse(this.txtDia.Text);
            int mes = int.Parse(this.txtMes.Text);
            int ano = int.Parse(this.txtAno.Text);

            if (mes == 1)
            {
                mes = 13;
                ano--;
            }
            else if (mes == 2)
            {
                mes = 14;
                ano--;
            }

            string[] dias = { "Sábado", "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

            // 1
            int primera = ((mes + 1) * 3) / 5;

            // 2
            int segunda = ano / 4;

            // 3
            int tercera = ano / 100;

            // 4
            int cuarta = ano / 400;

            // 5
            int quinta = dia + (mes * 2) + ano + primera + segunda - tercera + cuarta + 2;

            // 6
            int sexta = quinta / 7;

            // 7
            int septima = quinta - (sexta * 7);

            string day = "vacío";

            for (int i = 0; i < dias.Length; i++)
            {
                day = dias[septima];
            }

            lblDiaSemana.Text = day;
        }
    }
}
