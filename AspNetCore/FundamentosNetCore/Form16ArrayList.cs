using System;
using System.Collections;
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
    public partial class Form16ArrayList : Form
    {
        public Form16ArrayList()
        {
            InitializeComponent();
            // Declaramos una colección de button
            List<Button> botones = new List<Button>();
            botones.Add(this.button1);
            botones.Add(this.button2);
            botones.Add(this.button3);
            // El objeto es reconocible por su tipado T
            botones[0].BackColor = Color.AliceBlue;
            // Tenemos errores de compilación
            //botones.Add(this.textBox1);
            // Vamos a crear una colección no tipada
            // y almacenar los botones
            ArrayList coleccion = new ArrayList();
            coleccion.Add(this.button1);
            coleccion.Add(this.button2);
            coleccion.Add(this.button3);
            // Añadimos un textbox a la colección
            coleccion.Add(this.textBox1);
            // Si intentamos acceder a un elemento de la colección
            // y a sus propiedades, no podemos sin hacer casting
            ((Button)coleccion[0]).BackColor = Color.Yellow;
            // Mediante la abstracción, podemos convertir y recorrer
            // todos los objetos dentro de bucles de referencia
            //foreach(Button boton in coleccion)
            //{
            //    boton.BackColor = Color.LightBlue;
            //}
            // Si tengo objetos de clases distintas, debemos abstraernos
            foreach(Control control in coleccion)
            {
                control.BackColor = Color.LightGreen;
                // La clase textbox contiene un método Paste()
                // para pegar el contenido del portapapeles en
                // el interior del control. Debemos preguntar por el
                // tipo del control
                if(control is TextBox)
                {
                    ((TextBox)control).Paste();
                }
            }

        }
    }
}
