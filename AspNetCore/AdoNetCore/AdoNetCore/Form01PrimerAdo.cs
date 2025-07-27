using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace AdoNetCore
{
    public partial class Form01PrimerAdo : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        string connectionString;
        public Form01PrimerAdo()
        {
            InitializeComponent();
            this.connectionString = @"Data Source=LOCALMARIO\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(this.connectionString);
            this.com = new SqlCommand();
            this.cn.StateChange += Cn_StateChange;
        }

        private void Cn_StateChange(object sender, StateChangeEventArgs e)
        {
            this.lblMensaje.Text = "La conexión está pasando de " +
                e.OriginalState + " a " + e.CurrentState;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cn.State == ConnectionState.Closed)
                {
                    this.cn.Open();
                }
                this.lblMensaje.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }

        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            this.cn.Close();
            this.lblMensaje.BackColor = Color.Red;
        }

        private void btnLeerDatos_Click(object sender, EventArgs e)
        {
            // Consulta a realizar
            string sql = "select * from EMP";
            // Configuramos nuestro command
            // Indicamos la conexión del command
            this.com.Connection = this.cn;
            // Tipo de consulta a realizar
            this.com.CommandType = CommandType.Text;
            // La propia consulta
            this.com.CommandText = sql;
            // Aquí deberíamos abrir la conexión
            // Es una consulta de selección por lo que
            // debemos utilizar el método ExecuteReader()
            // que nos devuelve un DataReader
            this.reader = this.com.ExecuteReader();
            // Ya podemos leer datos
            // Leemos la primera columna
            for(int i=0; i<this.reader.FieldCount; i++)
            {
                string columna = this.reader.GetName(i);
                string tipoDato = this.reader.GetDataTypeName(i);
                this.lstColumnas.Items.Add(columna);
                this.lstTiposDato.Items.Add(tipoDato);
            }
            // Leemos el primer registro
            // Para leer datos debemos utilizar el método Read()
            // del lector
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstApellidos.Items.Add(apellido);
            }
            // Siempre debemos cerrar todo para poder reutilizarlo
            this.reader.Close();
        }
    }
}
