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
    public partial class Form03EliminarEnfermos : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form03EliminarEnfermos()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALMARIO\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.CargarEnfermos();
        }

        private void btnEliminarEnfermo_Click(object sender, EventArgs e)
        {
            // Debemos indicar el tipo de datos a enviar como parámetro
            // INSCRIPCION es un número, por lo que debemos hacer un
            // casting para int
            int inscripcion = int.Parse(this.txtInscripcion.Text);
            string sql = "delete from ENFERMO where INSCRIPCION=@inscripcion";
            // Creamos el parámetro para la inscripción
            //SqlParameter pamInscripcion = new SqlParameter();
            SqlParameter pamInscripcion = new SqlParameter("@inscripcion", inscripcion);
            //pamInscripcion.ParameterName = "@inscripcion";
            // Value debe ser del mismo tipo que el parámetro (int)
            //pamInscripcion.Value = inscripcion;
            //pamInscripcion.DbType = DbType.Int32;
            // Direction indica si el parámetro es entrada o salida
            // Por defecto, es input
            //pamInscripcion.Direction = ParameterDirection.Input;
            // Añadimos el parámetro al command
            this.com.Parameters.Add(pamInscripcion);
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            this.CargarEnfermos();
            MessageBox.Show("Enfermos eliminados " + eliminados);
        }

        private void CargarEnfermos()
        {
            string sql = "select * from ENFERMO";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEnfermos.Items.Clear();
            while (this.reader.Read())
            {
                string inscripcion = this.reader["INSCRIPCION"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEnfermos.Items.Add(inscripcion + " - " + apellido);
            }
            this.reader.Close();
            this.cn.Close();
        }
    }
}
