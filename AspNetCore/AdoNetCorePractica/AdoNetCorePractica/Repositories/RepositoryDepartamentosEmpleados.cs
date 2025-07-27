using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using AdoNetCorePractica.Helpers;
using AdoNetCorePractica.Models;

#region
/*
     create procedure SP_ALLDEPARTAMENTOS
as
	select *  from DEPT
go

create procedure SP_EMPLEADOSDEPARTAMENTO
(@nombreDepartamento nvarchar(50))
as
	select * from V_EMPLEADOS_DEPARTAMENTOS
	where DNOMBRE = @nombreDepartamento
go

create view V_EMPLEADOS_DEPARTAMENTOS
as
	SELECT 
        DEPT.DEPT_NO, DEPT.DNOMBRE, DEPT.LOC,
        EMP.APELLIDO, EMP.OFICIO, EMP.SALARIO
	from DEPT
	LEFT JOIN EMP
	on DEPT.DEPT_NO = EMP.DEPT_NO 
go

create procedure SP_INSERTARDEPARTAMENTO
(@id int, @nombre nvarchar(50), @localidad nvarchar(50))
as
	insert into DEPT values (@id, @nombre, @localidad)
go

create procedure SP_OBTENEREMPLEADO
(@apellido nvarchar(50))
as
    select * from V_EMPLEADOS_DEPARTAMENTOS
    where APELLIDO = @apellido
go

create procedure SP_ACTUALIZAREMPLEADO
(
    @apellidoAntiguo nvarchar(50),
    @apellidoNuevo nvarchar(50),
    @oficio nvarchar(50),
    @salario int
)
as
    update EMP
    set 
        APELLIDO = @apellidoNuevo, 
        OFICIO = @oficio, 
        SALARIO = @salario
    where APELLIDO = @apellidoAntiguo
go
*/
#endregion

namespace AdoNetCorePractica.Repositories
{
    public class RepositoryDepartamentosEmpleados
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDepartamentosEmpleados()
        {
            string conexion = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(conexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetListaDepartamentosAsync()
        {
            string sql = "SP_ALLDEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> lista = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombreDepartamento = this.reader["DNOMBRE"].ToString();
                lista.Add(nombreDepartamento);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return lista;
        }

        public async Task<DatosDepartamentosEmpleados> GetEmpleadosAsync(string nombreDepartamento)
        {
            string sql = "SP_EMPLEADOSDEPARTAMENTO";
            this.com.Parameters.AddWithValue("@nombreDepartamento", nombreDepartamento);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            DatosDepartamentosEmpleados datosDeptEmp = new DatosDepartamentosEmpleados();
            List<Empleado> empleados = new List<Empleado>();
            Departamento departamento = null;
            while (await this.reader.ReadAsync())
            {
                int id = int.Parse(this.reader["DEPT_NO"].ToString());
                string nombre = this.reader["DNOMBRE"].ToString();
                string loc = this.reader["LOC"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                string oficio = this.reader["OFICIO"].ToString();
                int salario = 0;
                int.TryParse(this.reader["SALARIO"].ToString(), out salario);
                Empleado empleado = new Empleado
                {
                    Apellido = apellido,
                    Oficio = oficio,
                    Salario = salario,
                };
                empleados.Add(empleado);
                departamento = new Departamento
                {
                    Id = id,
                    Nombre = nombre,
                    Localidad = loc
                };
            }
            await this.reader.CloseAsync();
            datosDeptEmp.Empleados = empleados;
            datosDeptEmp.Departamento = departamento;
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return datosDeptEmp;
        }

        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            string sql = "SP_INSERTARDEPARTAMENTO";
            this.com.Parameters.AddWithValue("@id", id); ;
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@localidad", localidad);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int afectados = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            MessageBox.Show("Número de departamentos insertados: " + afectados);
        }

        public async Task<Empleado> GetEmpleadoAsync(string apellido)
        {
            string sql = "SP_OBTENEREMPLEADO";
            this.com.Parameters.AddWithValue("@apellido", apellido);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            Empleado empleado = null;
            while (await this.reader.ReadAsync())
            {
                string ap = this.reader["APELLIDO"].ToString();
                string oficio = this.reader["OFICIO"].ToString();
                int salario = 0;
                int.TryParse(this.reader["SALARIO"].ToString(), out salario);
                empleado = new Empleado
                {
                    Apellido = ap,
                    Oficio = oficio,
                    Salario = salario
                };
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return empleado;
        }

        public async Task UpdateEmpleadoAsync(string apellidoAntiguo, string apellidoNuevo, string oficio, int salario)
        {
            string sql = "SP_ACTUALIZAREMPLEADO";
            this.com.Parameters.AddWithValue("@apellidoAntiguo", apellidoAntiguo);
            this.com.Parameters.AddWithValue("@apellidoNuevo", apellidoNuevo);
            this.com.Parameters.AddWithValue("@oficio", oficio);
            this.com.Parameters.AddWithValue("@salario", salario);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int afectados = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            MessageBox.Show("Número de empleados actualizados: " + afectados);
        }
    }
}
