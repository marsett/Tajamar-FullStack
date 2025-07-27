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
    public partial class Form17ListDelegados : Form
    {
        // Declaramos una variable contador
        int contador;
        List<Button> botones;
        public Form17ListDelegados()
        {
            InitializeComponent();
            this.contador = 0;
            this.botones = new List<Button>();
            //this.button1.Click += BotonPulsado;
            //this.button2.Click += BotonPulsado;
            //this.button3.Click += BotonPulsado;
            // Si almacenamos todos los objetos dentro de
            // la colección, podemos hacer la acción
            // delegada con un foreach
            foreach (Control miControl in this.Controls)
            {
                // Debemos preguntar por los button
                if (miControl is Button)
                {
                    this.botones.Add((Button)miControl);
                }
            }

            foreach(Button boton in this.botones)
            {
                boton.Click += BotonPulsado;
            }
        }

        // Quiero que al pulsar cualquier botón en este método
        // cambie de color el botón pulsado
        void BotonPulsado(Object sender, EventArgs e)
        {
            this.contador += 1;
            this.txtContador.Text = this.contador.ToString();
            // sender es el objeto que realiza la llamada
            Button miBoton = (Button)sender;
            miBoton.BackColor = Color.Yellow;
        }
    }
}
