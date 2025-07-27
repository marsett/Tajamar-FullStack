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
    public partial class Form06ValidarMail : Form
    {
        public Form06ValidarMail()
        {
            InitializeComponent();
        }

        private void btnValidarMail_Click(object sender, EventArgs e)
        {
            //string mail = this.txtValidarMail.Text;
            //if (!mail.Contains("@"))
            //{
            //    this.lblResultado.Text = "Error: el email introducido no contiene @";
            //}
            //else if (mail.StartsWith("@") || mail.EndsWith("@"))
            //{
            //    this.lblResultado.Text = "Error: no puede contener @ al principio ni al final";
            //}
            //else if (mail.Replace("@", "").Length < mail.Length - 1)
            //{
            //    this.lblResultado.Text = "Error: no puede haber más de un @";
            //}
            //else if (mail.Length - mail.Replace(".", "").Length != 1)
            //{
            //    this.lblResultado.Text = "Error: el email debe contener exactamente un punto";
            //}
            //else if (mail.IndexOf(".") < mail.IndexOf("@"))
            //{
            //    this.lblResultado.Text = "Error: debe haber un punto después del @";
            //}
            //else
            //{
            //    string dominio = mail.Substring(mail.IndexOf(".") + 1);

            //    string dominioSinExtension = dominio.Split('.')[0];

            //    if (dominioSinExtension.Length >= 2 && dominioSinExtension.Length <= 4)
            //    {
            //        this.lblResultado.Text = "Email válido";
            //    }
            //    else
            //    {
            //        this.lblResultado.Text = "Error: el dominio debe tener entre 2 y 4 caracteres";
            //    }
            //}

            string email = this.txtValidarMail.Text;
            if (email.Contains("@") == false)
            {
                this.lblResultado.Text = "No existe @";
            }
            else if (email.IndexOf("@") == 0 || email.EndsWith("@") == true)
            {
                this.lblResultado.Text = "@ al inicio o al final";
            }
            else if (email.IndexOf("@") != email.LastIndexOf("@"))
            {
                this.lblResultado.Text = "Más de una @ en el mail";
            }
            else if (email.IndexOf(".") == -1)
            {
                this.lblResultado.Text = "no existe punto en el mail";
            }
            else if (email.LastIndexOf(".") < email.IndexOf("@"))
            {
                this.lblResultado.Text = "Necesitamos un punto después de @";
            }
            else
            {
                int ultimoPunto = email.LastIndexOf(".");
                string dominio = email.Substring(ultimoPunto + 1);
                if (dominio.Length >= 2 && dominio.Length <= 4)
                {
                    this.lblResultado.Text = "Email correcto";
                }
                else
                {
                    this.lblResultado.Text = "Dominio de 2 a 4 caracteres";
                }
            }

        }
    }
}
