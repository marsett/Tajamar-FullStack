using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcNetCoreProceduresEF.Data;
using MvcNetCoreProceduresEF.Models;
using System.Data.Common;

#region
/*
 create procedure SP_TODOS_ENFERMOS
as
	select * from ENFERMO
go
create procedure SP_FIND_ENFERMO
(@inscripcion nvarchar(50))
as
	select * from ENFERMO where INSCRIPCION=@inscripcion
go
create procedure SP_DELETE_ENFERMO
(@inscripcion nvarchar(50))
as
	delete from ENFERMO where INSCRIPCION=@inscripcion
go
create procedure SP_INSERT_ENFERMO
(	
	@apellido nvarchar(50),
	@direccion nvarchar(50),
	@fechanacimiento DateTime,
	@sexo nvarchar(1)
)
as
	declare @maxid int;
	select @maxid = max(CAST(INSCRIPCION AS INT)) + 1 from ENFERMO
	declare @nss bigint;
	set @nss = CAST(RAND() * 1000000000 AS bigint);
	insert into ENFERMO (INSCRIPCION, APELLIDO, DIRECCION, FECHA_NAC, S, NSS)
	values (@maxid, @apellido, @direccion, @fechanacimiento, @sexo, @nss)
go
create procedure SP_GET_DOCTORES
as
	select * from DOCTOR
go

create procedure SP_UPDATE_SALARIO_DOCTOR
(@especialidad nvarchar(50), @salario int)
as
	begin
		update DOCTOR
		set SALARIO = SALARIO + @salario
		where ESPECIALIDAD = @especialidad;
	end
go
 */
#endregion

namespace MvcNetCoreProceduresEF.Repositories
{
    public class RepositoryEnfermos
    {
        public HospitalContext context;
        public RepositoryEnfermos(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Enfermo>> GetEnfermosAsync()
        {
            // Para consultas de selección debemos mapear
            // manualmente los datos
            using(DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                string sql = "SP_TODOS_ENFERMOS";
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                // Abrimos la conexión a través del command
                com.Connection.Open();
                // Ejecutamos nuestro reader
                DbDataReader reader = await com.ExecuteReaderAsync();
                List<Enfermo> enfermos = new List<Enfermo>();
                while (await reader.ReadAsync())
                {
                    Enfermo enfermo = new Enfermo
                    {
                        Inscripcion = reader["INSCRIPCION"].ToString(),
                        Apellido = reader["APELLIDO"].ToString(),
                        Direccion = reader["DIRECCION"].ToString(),
                        FechaNacimiento = DateTime.Parse(reader["FECHA_NAC"].ToString()),
                        Genero = reader["S"].ToString(),
                    };
                    enfermos.Add(enfermo);
                }
                await reader.CloseAsync();
                await com.Connection.CloseAsync();
                return enfermos;
            }
        }

        public Enfermo FindEnfermo(string inscripcion)
        {
            // Para llamar a procedimientos almacenados
            // con parámetros la llamada se realiza mediante
            // el nombre del procedimiento y cada parámetro
            // a continuación separado mediante comas
            // SP_PROCEDIMIENTO @PARAM1, @PARAM2
            string sql = "SP_FIND_ENFERMO @INSCRIPCION";
            // Debemos crear un parámetro
            SqlParameter pamInscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            // Si los datos que devuelve el procedimiento
            // están mapeados con un model, podemos utilizar
            // el método FromSqlRaw con LINQ
            // Cuando utilizamos LINQ con procedimientos almacenados
            // la consulta y la extracción de datos se realizan en dos pasos
            // No se puede hacer LINQ y extraer a la vez
            var consulta = this.context.Enfermos.FromSqlRaw(sql, pamInscripcion);
            // Para extraer los datos necesitamos también el método AsEnumerable()
            Enfermo enfermo = consulta.AsEnumerable().FirstOrDefault();
            return enfermo;
        }
        //public async Task<Enfermo> FindEnfermoAsync(string inscripcion)
        //{
        //    string sql = "SP_FIND_ENFERMO";
        //    SqlParameter pamInscripcion = new SqlParameter("@INSCRIPCION", inscripcion);

        //    using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
        //    {
        //        com.CommandType = System.Data.CommandType.StoredProcedure;
        //        com.CommandText = sql;
        //        com.Parameters.Add(pamInscripcion);
        //        await com.Connection.OpenAsync();
        //        DbDataReader reader = await com.ExecuteReaderAsync();
        //        await reader.ReadAsync();
        //        Enfermo enfermo = new Enfermo
        //            {
        //                Inscripcion = reader["INSCRIPCION"].ToString(),
        //                Apellido = reader["APELLIDO"].ToString(),
        //                Direccion = reader["DIRECCION"].ToString(),
        //                FechaNacimiento = DateTime.Parse(reader["FECHA_NAC"].ToString()),
        //                Genero = reader["S"].ToString(),
        //            };

        //        await reader.CloseAsync();
        //        await com.Connection.CloseAsync();
        //        com.Parameters.Clear();
        //        return enfermo;
        //    }

        //}

        public async Task<Enfermo> FindEnfermoAsync(string inscripcion)
        {
            string sql = "SP_FIND_ENFERMO @INSCRIPCION";
            SqlParameter pamInscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            var consulta = 
                await this.context.Enfermos.FromSqlRaw(sql, pamInscripcion).ToListAsync();
            Enfermo enfermo = consulta.FirstOrDefault();
            return enfermo;
        }

        public async Task DeleteEnfermoAsync(string inscripcion)
        {
            string sql = "SP_DELETE_ENFERMO";
            SqlParameter pamInscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Parameters.Add(pamInscripcion);
                await com.Connection.OpenAsync();
                com.ExecuteNonQuery();
                await com.Connection.CloseAsync();
                com.Parameters.Clear();
            }
        }

        public async Task DeleteEnfermoRawAsync(string inscripcion)
        {
            string sql = "SP_DELETE_ENFERMO @INSCRIPCION";
            SqlParameter pamInscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            // Dentro del context tenemos un método para poder llamar
            // a procedimientos de consultas de acción
            await this.context.Database.ExecuteSqlRawAsync(sql, pamInscripcion);
        }

        //public async Task InsertEnfermoAsync(string apellido, string direccion, 
        //    DateTime fechaNacimiento, string sexo)
        //{
        //    string sql = "SP_INSERT_ENFERMO";
        //    SqlParameter pamApellido = new SqlParameter("@apellido", apellido);
        //    SqlParameter pamDireccion = new SqlParameter("@direccion", direccion);
        //    SqlParameter pamFechaNacimiento = new SqlParameter("@fechanacimiento", fechaNacimiento);
        //    SqlParameter pamSexo = new SqlParameter("@sexo", sexo);
        //    using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
        //    {
        //        com.CommandType = System.Data.CommandType.StoredProcedure;
        //        com.CommandText = sql;

        //        com.Parameters.Add(pamApellido);
        //        com.Parameters.Add(pamDireccion);
        //        com.Parameters.Add(pamFechaNacimiento);
        //        com.Parameters.Add(pamSexo);

        //        await com.Connection.OpenAsync();
        //        await com.ExecuteNonQueryAsync();
        //        await com.Connection.CloseAsync();

        //        com.Parameters.Clear();
        //    }
        //}

        public async Task InsertEnfermoAsync(string apellido, string direccion,
            DateTime fechaNacimiento, string sexo)
        {
                string sql = "SP_INSERT_ENFERMO @apellido, @direccion "
                    + ", @fechanacimiento, @sexo";
                SqlParameter pamApellido =
                    new SqlParameter("@apellido", apellido);
                SqlParameter pamDireccion =
                    new SqlParameter("@direccion", direccion);
                SqlParameter pamFecha =
                    new SqlParameter("@fechanacimiento", fechaNacimiento);
                SqlParameter pamGen =
                    new SqlParameter("@sexo", sexo);
                await this.context.Database
                    .ExecuteSqlRawAsync(sql, pamApellido, pamDireccion
                    , pamFecha, pamGen);
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                string sql = "SP_GET_DOCTORES";
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader = await com.ExecuteReaderAsync();
                List<Doctor> doctores = new List<Doctor>();
                while (await reader.ReadAsync())
                {
                    Doctor doctor = new Doctor
                    {
                        Hospital_Cod = int.Parse(reader["HOSPITAL_COD"].ToString()),
                        Doctor_No = int.Parse(reader["DOCTOR_NO"].ToString()),
                        Apellido = reader["APELLIDO"].ToString(),
                        Especialidad = reader["ESPECIALIDAD"].ToString(),
                        Salario = int.Parse(reader["SALARIO"].ToString())
                    };
                    doctores.Add(doctor);
                }
                await reader.CloseAsync();
                await com.Connection.CloseAsync();
                return doctores;
            }
        }

        public List<string> GetEspecialidades()
        {
            string sql = "SP_GET_DOCTORES";
            var consulta = this.context.Doctores
                .FromSqlRaw(sql)
                .AsEnumerable()
                .Select(d => d.Especialidad)
                .Distinct()
                .ToList();
            return consulta;
        }

        public async Task UpdateSalarioDoctorAsync(string especialidad, int salario)
        {
            string sql = "SP_UPDATE_SALARIO_DOCTOR";
            SqlParameter pamEspecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamSalario = new SqlParameter("@SALARIO", salario);
            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Parameters.Add(pamEspecialidad);
                com.Parameters.Add(pamSalario);
                await com.Connection.OpenAsync();
                com.ExecuteNonQuery();
                await com.Connection.CloseAsync();
                com.Parameters.Clear();
            }
        }

    }
}
