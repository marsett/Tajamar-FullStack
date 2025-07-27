using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using AdoNetCore.Models;

namespace AdoNetCore.Repositories
{
    public class RepositoryHospital
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString = @"Data Source=LOCALMARIO\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            string sql = "select * from HOSPITAL";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Hospital> hospitales = new List<Hospital>();
            while (await this.reader.ReadAsync())
            {
                int hospital_cod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                string nombre = this.reader["NOMBRE"].ToString();
                string direccion = this.reader["DIRECCION"].ToString();
                string telefono = this.reader["TELEFONO"].ToString();
                int num_cama = int.Parse(this.reader["NUM_CAMA"].ToString());
                Hospital hospital = new Hospital();
                hospital.Hospital_Cod = hospital_cod;
                hospital.Nombre = nombre;
                hospital.Direccion = direccion;
                hospital.Telefono = telefono;
                hospital.Num_Cama = num_cama;
                hospitales.Add(hospital);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return hospitales;
        }

        public async Task InsertHospitalAsync(int hospital_cod, string nombre, string direccion, string telefono, int num_cama)
        {
            string sql = "insert into HOSPITAL values(@hospital_cod, @nombre, @direccion, @telefono, @num_cama)";
            SqlParameter pamHospitalCod = new SqlParameter("@hospital_cod", hospital_cod);
            this.com.Parameters.Add(pamHospitalCod);
            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);
            this.com.Parameters.Add(pamNombre);
            SqlParameter pamDireccion = new SqlParameter("@direccion", direccion);
            this.com.Parameters.Add(pamDireccion);
            SqlParameter pamTelefono = new SqlParameter("@telefono", telefono);
            this.com.Parameters.Add(pamTelefono);
            SqlParameter pamNumCama = new SqlParameter("@num_cama", num_cama);
            this.com.Parameters.Add(pamNumCama);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task UpdateHospitalAsync(int hospital_cod, string nombre, string direccion, string telefono, int num_cama)
        {
            string sql = "update HOSPITAL set NOMBRE=@nombre, DIRECCION=@direccion, TELEFONO=@telefono, NUM_CAMA=@num_cama " +
                "where HOSPITAL_COD=@hospital_cod";
            // Tenemos un método para almacenar parámetros directamente en el command
            // sin crear objetos, este método solamente lo utilizamos cuando los
            // parámetros sean tipados primitivos
            this.com.Parameters.AddWithValue("@hospital_cod", hospital_cod);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@num_cama", num_cama);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task DeleteHospitalAsync(int hospital_cod)
        {
            string sql = "delete from HOSPITAL where HOSPITAL_COD=@hospital_cod";
            this.com.Parameters.AddWithValue("@hospital_cod", hospital_cod);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }
    }
}
