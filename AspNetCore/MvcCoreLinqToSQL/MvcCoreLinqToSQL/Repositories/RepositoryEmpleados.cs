using Microsoft.Data.SqlClient;
using MvcCoreLinqToSQL.Models;
using System.Data;

namespace MvcCoreLinqToSQL.Repositories
{
    public class RepositoryEmpleados
    {
        private DataTable tablaEmpleados;

        public RepositoryEmpleados()
        {
            string connectionString = @"Data Source=LOCALMARIO\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Encrypt=True;Trust Server Certificate=True";
            string sql = "select * from EMP";
            SqlDataAdapter adEmp = new SqlDataAdapter(sql, connectionString);
            this.tablaEmpleados = new DataTable();
            // Recuperamos los datos
            adEmp.Fill(this.tablaEmpleados);
        }

        // Método para recuperar todos los empleados
        public List<Empleado> GetEmpleados()
        {
            // Las consultas LINQ se almacenan en genéricos (var)
            var consulta = from datos in this.tablaEmpleados.AsEnumerable() select datos;
            // Ahora mismo tenemos dentro de consulta la información de la tabla empleados
            // En este ejemplo tenemos objeto DataRow que son filas dentro de la tabla
            // Debemos recorrer dichas filas y extraer la información en objetos de tipo empleado
            List<Empleado> empleados = new List<Empleado>();
            // Recorremos cada fila de la consulta
            foreach (var row in consulta)
            {
                Empleado emp = new Empleado();
                // Para extraer datos de un DataRow
                // DataRow.Field<tipo>("COLUMNA")
                emp.IdEmpleado = row.Field<int>("EMP_NO");
                emp.Apellido = row.Field<string>("APELLIDO");
                emp.Oficio = row.Field<string>("OFICIO");
                emp.Salario = row.Field<int>("SALARIO");
                emp.IdDepartamento = row.Field<int>("DEPT_NO");
                empleados.Add(emp);
            }
            return empleados;
        }

        // Método para buscar empleados por su id
        public Empleado FindEmpleado(int idEmpleado)
        {
            var consulta = from datos in this.tablaEmpleados.AsEnumerable()
                           where datos.Field<int>("EMP_NO") == idEmpleado
                           select datos;
            // Nosotros sabemos que esta consulta devuelve una fila
            // LINQ siempre devuelve una colección
            // Dentro del conjunto tenemos métodos lambda que nos
            // permiten realizar cositas
            // Tenemos un método que nos devuelve el primer valor del conjunto
            // First();
            var row = consulta.First();
            Empleado emp = new Empleado();
            emp.IdEmpleado = row.Field<int>("EMP_NO");
            emp.Apellido = row.Field<string>("APELLIDO");
            emp.Oficio = row.Field<string>("OFICIO");
            emp.Salario = row.Field<int>("SALARIO");
            emp.IdDepartamento = row.Field<int>("DEPT_NO");
            return emp;
        }

        public List<Empleado> GetEmpleadosOficioSalario(string oficio, int salario)
        {
            var consulta = from datos in this.tablaEmpleados.AsEnumerable()
                           where datos.Field<string>("OFICIO") == oficio
                           && datos.Field<int>("SALARIO") >= salario
                           select datos;
            // Debemos comprobar si tenemos datos o no...
            if(consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                List<Empleado> empleados = new List<Empleado>();
                foreach (var row in consulta)
                {
                    Empleado empleado = new Empleado
                    {
                        IdEmpleado = row.Field<int>("EMP_NO"),
                        Apellido = row.Field<string>("APELLIDO"),
                        Oficio = row.Field<string>("OFICIO"),
                        Salario = row.Field<int>("SALARIO"),
                        IdDepartamento = row.Field<int>("DEPT_NO")
                    };
                    empleados.Add(empleado);
                }
                return empleados;
            }
        }

        public ResumenEmpleados GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.tablaEmpleados.AsEnumerable()
                           where datos.Field<string>("OFICIO") == oficio
                           select datos;
            // Quisiera ordenar los empleados por su salario
            consulta = consulta.OrderBy(z => z.Field<int>("SALARIO"));
            int personas = consulta.Count();
            int maximo = consulta.Max(x => x.Field<int>("SALARIO"));
            double media = consulta.Average(x => x.Field<int>("SALARIO"));
            List<Empleado> empleados = new List<Empleado>();
            foreach(var row in consulta)
            {
                Empleado empleado = new Empleado
                {
                    IdEmpleado = row.Field<int>("EMP_NO"),
                    Apellido = row.Field<string>("APELLIDO"),
                    Oficio = row.Field<string>("OFICIO"),
                    Salario = row.Field<int>("SALARIO"),
                    IdDepartamento = row.Field<int>("DEPT_NO"),
                };
                empleados.Add(empleado);
            }
            ResumenEmpleados resumen = new ResumenEmpleados();
            resumen.Personas = personas;
            resumen.MaximoSalario = maximo;
            resumen.MediaSalarial = media;
            resumen.Empleados = empleados;
            return resumen;
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.tablaEmpleados.AsEnumerable()
                           select datos.Field<string>("OFICIO")).Distinct();
            return consulta.ToList();
        }
    }
}
