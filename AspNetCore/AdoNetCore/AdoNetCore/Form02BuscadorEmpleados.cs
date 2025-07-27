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
    public partial class Form02BuscadorEmpleados : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form02BuscadorEmpleados()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALMARIO\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
        }

        private void btnBuscadorEmpleados_Click(object sender, EventArgs e)
        {
            string salario = this.txtSalario.Text;
            string sql = "select * from EMP where salario >= " + salario;
            // Conexión
            this.com.Connection = this.cn;
            // Tipo de consulta
            this.com.CommandType = CommandType.Text;
            // La consulta
            this.com.CommandText = sql;
            // Abrimos la conexión
            // Entrar y salir
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            // Dibujamos los datos
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string ape = this.reader["APELLIDO"].ToString();
                string sal = this.reader["SALARIO"].ToString();
                this.lstEmpleados.Items.Add(ape + " - " + sal);
            }
            // Liberamos todos los recursos utilizados
            // Salir
            this.reader.Close();
            this.cn.Close();
        }

        private void btnBuscarPorOficio_Click(object sender, EventArgs e)
        {
            string sql = "select * from EMP where OFICIO='" + this.txtOficio.Text + "'";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string ape = this.reader["APELLIDO"].ToString();
                string ofi = this.reader["OFICIO"].ToString();
                this.lstEmpleados.Items.Add(ape + " - " + ofi);
            }
            this.reader.Close();
            this.cn.Close();
        }
    }
}
