using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetCore.Repositories
{
    public class RepositoryDepartamentosEmpleados
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;
        public RepositoryDepartamentosEmpleados()
        {
            string connectionString = @"Data Source=LOCALMARIO\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
        }

        public async Task<List<string>> GetNombresDepartamentosAsync()
        {
            string sql = "select DNOMBRE from DEPT";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> departamentos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return departamentos;
        }

        public async Task<List<string>> GetEmpleadosPorDepartamentoAsync(string departamentoSeleccionado)
        {
            string sql = "select EMP.APELLIDO from EMP inner join DEPT on" +
                " EMP.DEPT_NO = DEPT.DEPT_NO where DNOMBRE=@departamento";

            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;

            SqlParameter pamDept = new SqlParameter("@departamento", departamentoSeleccionado);
            this.com.CommandText = sql;
            this.com.Parameters.Clear();
            this.com.Parameters.Add(pamDept);

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            List<string> apellidos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                apellidos.Add(apellido);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return apellidos;
        }

        public async Task BorrarEmpleadoAsync(string empleadoSeleccionado)
        {
            string sql = "DELETE FROM EMP WHERE APELLIDO =@apellidoempleado";
            SqlParameter pamApellidoEmpleado = new SqlParameter("@apellidoempleado", empleadoSeleccionado);
            this.com.Parameters.Add(pamApellidoEmpleado);
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }
    }
}
