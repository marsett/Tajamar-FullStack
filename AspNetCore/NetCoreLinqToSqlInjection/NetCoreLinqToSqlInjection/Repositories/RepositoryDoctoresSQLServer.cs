using Microsoft.Data.SqlClient;
using NetCoreLinqToSqlInjection.Models;
using System.Data;

#region PROCEDIMIENTOS ALMACENADOS
/*
 create procedure SP_DELETE_DOCTOR
(@iddoctor int)
as
	delete from DOCTOR where DOCTOR_NO=@iddoctor
go 

create procedure SP_UPDATE_DOCTOR
(
    @idDoctor int,
    @apellido nvarchar(50),
    @especialidad nvarchar(50),
    @salario int,
	@idHospital int
)
as
    update DOCTOR
    set 
        HOSPITAL_COD = @idHospital, 
        APELLIDO = @apellido,
		ESPECIALIDAD = @especialidad,
        SALARIO = @salario
    where DOCTOR_NO = @idDoctor
go
*/
#endregion

namespace NetCoreLinqToSqlInjection.Repositories
{
    public class RepositoryDoctoresSQLServer: IRepositoryDoctores
    {
        private DataTable tableDoctores;
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDoctoresSQLServer()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.tableDoctores = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("select * from DOCTOR", connectionString);
            ad.Fill(this.tableDoctores);
        }

        public void DeleteDoctor(int idDoctor)
        {
            string sql = "SP_DELETE_DOCTOR";
            this.com.Parameters.AddWithValue("@iddoctor", idDoctor);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
        public void UpdateDoctor(int idDoctor, string apellido,
            string especialidad, int salario, int idHospital)
        {
            string sql = "SP_UPDATE_DOCTOR";
            this.com.Parameters.AddWithValue("@iddoctor", idDoctor);
            this.com.Parameters.AddWithValue("@apellido", apellido);
            this.com.Parameters.AddWithValue("@especialidad", especialidad);
            this.com.Parameters.AddWithValue("@salario", salario);
            this.com.Parameters.AddWithValue("@idhospital", idHospital);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public Doctor FindDoctor(int idDoctor)
        {
            var consulta = from datos in this.tableDoctores.AsEnumerable()
                           where datos.Field<int>("DOCTOR_NO") == idDoctor
                           select datos;
            var row = consulta.First();
            Doctor doc = new Doctor();
            doc.IdDoctor = row.Field<int>("DOCTOR_NO");
            doc.Apellido = row.Field<string>("APELLIDO");
            doc.Especialidad = row.Field<string>("ESPECIALIDAD");
            doc.Salario = row.Field<int>("SALARIO");
            doc.IdHospital = row.Field<int>("HOSPITAL_COD");
            return doc;
        }


        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tableDoctores.AsEnumerable()
                           select datos;
            List<Doctor> doctores = new List<Doctor>();
            foreach(var row in consulta)
            {
                Doctor doctor = new Doctor();
                doctor.IdDoctor = row.Field<int>("DOCTOR_NO");
                doctor.Apellido = row.Field<string>("APELLIDO");
                doctor.Especialidad = row.Field<string>("ESPECIALIDAD");
                doctor.Salario = row.Field<int>("SALARIO");
                doctor.IdHospital = row.Field<int>("HOSPITAL_COD");
                doctores.Add(doctor);
            }
            return doctores;
        }

        public void InsertDoctor(int idDoctor, string apellido,
            string especialidad, int salario, int idHospital)
        {
            string sql = "insert into DOCTOR values (@idhospital, @iddoctor, @apellido, " +
                "@especialidad, @salario)";
            this.com.Parameters.AddWithValue("@iddoctor", idDoctor);
            this.com.Parameters.AddWithValue("@apellido", apellido);
            this.com.Parameters.AddWithValue("@especialidad", especialidad);
            this.com.Parameters.AddWithValue("@salario", salario);
            this.com.Parameters.AddWithValue("@idhospital", idHospital);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public List<Doctor> GetDoctorPorEspecialidad(string especialidad)
        {
            var consulta = from datos in this.tableDoctores.AsEnumerable()
                           where datos.Field<string>("ESPECIALIDAD").ToUpper() == especialidad.ToUpper()
                           select datos;
            consulta = consulta.OrderBy(z => z.Field<string>("APELLIDO"));
            List<Doctor> doctores = new List<Doctor>();
            foreach (var row in consulta)
            {
                Doctor doctor = new Doctor
                {
                    IdHospital = row.Field<int>("HOSPITAL_COD"),
                    IdDoctor = row.Field<int>("DOCTOR_NO"),
                    Apellido = row.Field<string>("APELLIDO"),
                    Especialidad = row.Field<string>("ESPECIALIDAD"),
                    Salario = row.Field<int>("SALARIO")
                };
                doctores.Add(doctor);
            }
            return doctores;
        }

        public List<string> GetEspecialidades()
        {
            var consulta = (from datos in this.tableDoctores.AsEnumerable()
                            select datos.Field<string>("ESPECIALIDAD")).Distinct();
            return consulta.ToList();
        }
    }
}
