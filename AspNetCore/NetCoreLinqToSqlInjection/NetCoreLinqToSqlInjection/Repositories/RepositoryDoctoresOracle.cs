using Microsoft.Data.SqlClient;
using NetCoreLinqToSqlInjection.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

#region PROCEDIMIENTOS ALMACENADOS
/*
 CREATE OR REPLACE PROCEDURE sp_delete_doctor
(p_iddoctor DOCTOR.DOCTOR_NO%TYPE)
AS
BEGIN
	DELETE FROM DOCTOR WHERE DOCTOR_NO=MARIO;
	COMMIT;
END;

CREATE OR REPLACE PROCEDURE sp_update_doctor
(p_idhospital DOCTOR.HOSPITAL_COD%TYPE ,p_iddoctor DOCTOR.DOCTOR_NO%TYPE,
p_apellido DOCTOR.APELLIDO%TYPE, p_especialidad DOCTOR.ESPECIALIDAD%TYPE,
p_salario DOCTOR.SALARIO%TYPE)
AS
BEGIN
	UPDATE DOCTOR SET 
		HOSPITAL_COD = p_idhospital, 
        APELLIDO = p_apellido,
		ESPECIALIDAD = p_especialidad,
        SALARIO = p_salario
    	where DOCTOR_NO = p_iddoctor;
	COMMIT;
END;
*/
#endregion

namespace NetCoreLinqToSqlInjection.Repositories
{
    public class RepositoryDoctoresOracle : IRepositoryDoctores
    {
        private DataTable tableDoctores;
        private OracleConnection cn;
        private OracleCommand com;
        private OracleDataReader reader;

        public RepositoryDoctoresOracle()
        {
            string connectionString = @"Data Source=LOCALHOST:1521/XE; Persist Security Info=True;User ID=SYSTEM; Password=oracle";
            this.tableDoctores = new DataTable();
            this.cn = new OracleConnection(connectionString);
            this.com = new OracleCommand();
            this.com.Connection = this.cn;
            OracleDataAdapter ad = new OracleDataAdapter("select * from DOCTOR", connectionString);
            ad.Fill(this.tableDoctores);
        }

        public void DeleteDoctor(int idDoctor)
        {
            string sql = "sp_delete_doctor";
            OracleParameter pamIdDoctor = new OracleParameter(":p_iddoctor", idDoctor);
            this.com.Parameters.Add(pamIdDoctor);
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
            OracleParameter pamIdHospital = new OracleParameter(":p_idhospital", idHospital);
            this.com.Parameters.Add(pamIdHospital);
            OracleParameter pamIdDoctor = new OracleParameter(":p_iddoctor", idDoctor);
            this.com.Parameters.Add(pamIdDoctor);
            OracleParameter pamApellido = new OracleParameter(":p_apellido", apellido);
            this.com.Parameters.Add(pamApellido);
            OracleParameter pamEspecialidad = new OracleParameter(":p_especialidad", especialidad);
            this.com.Parameters.Add(pamEspecialidad);
            OracleParameter pamSalario = new OracleParameter(":p_salario", salario);
            this.com.Parameters.Add(pamSalario);

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
            foreach (var row in consulta)
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

        public void InsertDoctor(int idDoctor, string apellido, string especialidad, int salario, int idHospital)
        {
            string sql = "insert into DOCTOR values (:idhospital, :iddoctor, :apellido, " +
                ":especialidad, :salario)";
            OracleParameter pamIdHospital = new OracleParameter(":idhospital", idHospital);
            this.com.Parameters.Add(pamIdHospital);
            OracleParameter pamIdDoctor = new OracleParameter(":iddoctor", idDoctor);
            this.com.Parameters.Add(pamIdDoctor);
            OracleParameter pamApellido = new OracleParameter(":apellido", apellido);
            this.com.Parameters.Add(pamApellido);
            OracleParameter pamEspecialidad = new OracleParameter(":especialidad", especialidad);
            this.com.Parameters.Add(pamEspecialidad);
            OracleParameter pamSalario = new OracleParameter(":salario", salario);
            this.com.Parameters.Add(pamSalario);
            
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
