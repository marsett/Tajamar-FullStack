using Microsoft.Data.SqlClient;
using MvcDoctoresPracticaFinal.Models;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcDoctoresPracticaFinal.Repositories
{
    public class RepositoryDoctores
    {
        private DataTable tablaDoctores;
        private SqlConnection cn;
        private SqlCommand com;

        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Encrypt=True;Trust Server Certificate=True";
            string sql = "select * from DOCTOR";
            SqlDataAdapter adDoc = new SqlDataAdapter(sql, connectionString);
            this.tablaDoctores = new DataTable();
            adDoc.Fill(this.tablaDoctores);
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable() select datos;
            List<Doctor> doctores = new List<Doctor>();
            foreach (var row in consulta)
            {
                Doctor doctor = new Doctor
                {
                    Hospital_Cod = row.Field<int>("HOSPITAL_COD"),
                    Doctor_No = row.Field<int>("DOCTOR_NO"),
                    Apellido = row.Field<string>("APELLIDO"),
                    Especialidad = row.Field<string>("ESPECIALIDAD"),
                    Salario = row.Field<int>("SALARIO")
                };
                doctores.Add(doctor);
            }
            return doctores;
        }

        public Doctor FindDoctor(int doctorno)
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable()
                           where datos.Field<int>("DOCTOR_NO") == doctorno
                           select datos;
            var row = consulta.First();
            Doctor doc = new Doctor
            {
                Hospital_Cod = row.Field<int>("HOSPITAL_COD"),
                Doctor_No = row.Field<int>("DOCTOR_NO"),
                Apellido = row.Field<string>("APELLIDO"),
                Especialidad = row.Field<string>("ESPECIALIDAD"),
                Salario = row.Field<int>("SALARIO")
            };
            return doc;
        }

        public List<Doctor> GetDoctorPorEspecialidad(string especialidad)
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable()
                           where datos.Field<string>("ESPECIALIDAD") == especialidad
                           select datos;
            consulta = consulta.OrderBy(z => z.Field<string>("APELLIDO"));
            List<Doctor> doctores = new List<Doctor>();
            foreach (var row in consulta)
            {
                Doctor doctor = new Doctor
                {
                    Hospital_Cod = row.Field<int>("HOSPITAL_COD"),
                    Doctor_No = row.Field<int>("DOCTOR_NO"),
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
            var consulta = (from datos in this.tablaDoctores.AsEnumerable()
                            select datos.Field<string>("ESPECIALIDAD")).Distinct();
            return consulta.ToList();
        }

        public void EliminarDoctor(int doctorno)
        {
            string sql = "delete from DOCTOR where DOCTOR_NO=@doctorno";
            this.com.Parameters.AddWithValue("@doctorno", doctorno);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            string sql = "update DOCTOR set APELLIDO=@apellido," +
                " ESPECIALIDAD=@especialidad, SALARIO=@salario" +
                " where HOSPITAL_COD=@hospital_cod and DOCTOR_NO=@doctor_no";
            this.com.Parameters.AddWithValue("@hospital_cod", doctor.Hospital_Cod);
            this.com.Parameters.AddWithValue("@doctor_no", doctor.Doctor_No);
            this.com.Parameters.AddWithValue("@apellido", doctor.Apellido);
            this.com.Parameters.AddWithValue("@especialidad", doctor.Especialidad);
            this.com.Parameters.AddWithValue("@salario", doctor.Salario);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void InsertDoctor(Doctor doctor)
        {
            string sql = "INSERT INTO DOCTOR (HOSPITAL_COD, DOCTOR_NO, " +
                " APELLIDO, ESPECIALIDAD, SALARIO) " +
             "VALUES (@hospital_cod, @doctor_no, @apellido, @especialidad, @salario)";
            this.com.Parameters.AddWithValue("@hospital_cod", doctor.Hospital_Cod);
            this.com.Parameters.AddWithValue("@doctor_no", doctor.Doctor_No);
            this.com.Parameters.AddWithValue("@apellido", doctor.Apellido);
            this.com.Parameters.AddWithValue("@especialidad", doctor.Especialidad);
            this.com.Parameters.AddWithValue("@salario", doctor.Salario);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

    }
}
