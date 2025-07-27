using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoNetCore
{
    public partial class Form05UpdateSalas : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form05UpdateSalas()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALMARIO\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.CargarSalas();
        }

        private async void btnModificarSalas_Click(object sender, EventArgs e)
        {
            string nuevaSala = this.txtNuevaSala.Text;
            string currentSala = this.lstSalas.SelectedItem.ToString();
            string sql = "update SALA set NOMBRE = @nuevaSala where NOMBRE=@currentSala";
            SqlParameter pamNuevoNombre = new SqlParameter("@nuevaSala", nuevaSala);
            this.com.Parameters.Add(pamNuevoNombre);
            SqlParameter pamCurrentSala = new SqlParameter("@currentSala", currentSala);
            this.com.Parameters.Add(pamCurrentSala);
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int eliminados = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            this.CargarSalas();
            MessageBox.Show("Salas actualizadas " + eliminados);
        }

        private async void CargarSalas()
        {
            string sql = "select distinct NOMBRE from SALA";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.lstSalas.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.lstSalas.Items.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
        }
    }
}
