using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCorePractica.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;
using AdoNetCorePractica.Models;

#region
/*
 * create procedure SP_ALLEMPLEADOS_HOSPITAL
(@nombre nvarchar(50), @suma int OUT, @media int OUT, @personas int OUT)
as
	select * from V_EMPLEADOS_HOSPITAL
	where NOMBRE = @nombre
	select @suma = sum(salario), @media = avg(salario),
	@personas = COUNT(apellido) from V_EMPLEADOS_HOSPITAL
	where NOMBRE = @nombre
go

create view V_EMPLEADOS_HOSPITAL
as
	select DOCTOR.APELLIDO, DOCTOR.ESPECIALIDAD, DOCTOR.SALARIO
	, HOSPITAL.HOSPITAL_COD, HOSPITAL.NOMBRE
	from DOCTOR
	INNER JOIN HOSPITAL
	on DOCTOR.HOSPITAL_COD = HOSPITAL.HOSPITAL_COD
	UNION
	select PLANTILLA.APELLIDO, PLANTILLA.FUNCION, PLANTILLA.SALARIO
	, HOSPITAL.HOSPITAL_COD, HOSPITAL.NOMBRE
	from PLANTILLA
	INNER JOIN HOSPITAL
	on PLANTILLA.HOSPITAL_COD = HOSPITAL.HOSPITAL_COD
go
*/
#endregion

namespace AdoNetCorePractica.Repositories
{
    public class RepositoryHospitalesEmpleados
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryHospitalesEmpleados()
        {
            string conexion = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(conexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<ListaHospitales> GetHospitalesAsync()
        {
            string sql = "SP_ALLHOSPITALES";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            ListaHospitales hospitales = new ListaHospitales();
            List<string> lista = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombreHospital = this.reader["NOMBRE"].ToString();
                lista.Add(nombreHospital);
            }
            await this.reader.CloseAsync();
            hospitales.Hospitales = lista;
            await this.cn.CloseAsync();
            return hospitales;
        }
        
        public async Task<DatosEmpleadosHospital> GetDatosEmpleadosAsync(string nombreHospital)
        {
            string sql = "SP_ALLEMPLEADOS_HOSPITAL";
            this.com.Parameters.AddWithValue("@nombre", nombreHospital);
            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@suma";
            pamSuma.Value = 0;
            pamSuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamSuma);
            SqlParameter pamMedia = new SqlParameter();
            pamMedia.ParameterName = "@media";
            pamMedia.Value = 0;
            pamMedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamMedia);
            SqlParameter pamPersonas = new SqlParameter();
            pamPersonas.ParameterName = "@personas";
            pamPersonas.Value = 0;
            pamPersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamPersonas);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            DatosEmpleadosHospital datosEmpleados = new DatosEmpleadosHospital();
            List<Empleado> datos = new List<Empleado>();
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                string funcion = this.reader["ESPECIALIDAD"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                Empleado empleado = new Empleado
                {
                    Apellido = apellido,
                    Oficio = funcion,
                    Salario = salario,
                };
                datos.Add(empleado);
            }
            await this.reader.CloseAsync();
            datosEmpleados.Empleados = datos;
            datosEmpleados.SumaSalarial = (int)pamSuma.Value;
            datosEmpleados.MediaSalarial = (int)pamMedia.Value;
            datosEmpleados.Personas = (int)pamPersonas.Value;
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return datosEmpleados;
        }
    }
}
