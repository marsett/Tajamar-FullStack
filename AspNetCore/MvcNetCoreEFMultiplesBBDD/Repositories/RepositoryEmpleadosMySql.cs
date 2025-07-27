using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

#region
/*
 CREATE VIEW V_EMPLEADOS AS
SELECT 
    EMP.EMP_NO AS IDEMPLEADO,
    EMP.APELLIDO, 
    EMP.OFICIO, 
    EMP.SALARIO,
    DEPT.DNOMBRE AS DEPARTAMENTO,
    DEPT.LOC AS LOCALIDAD
FROM EMP
INNER JOIN DEPT ON EMP.DEPT_NO = DEPT.DEPT_NO;
 */
#endregion

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosMySql : IRepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleadosMySql(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            //var consulta = from datos in this.context.EmpleadosView
            //               select datos;
            //return await consulta.ToListAsync();
            string sql = "CALL SP_ALL_EMPLEADOS();";
            var consulta = await this.context.EmpleadosView
                .FromSqlRaw(sql)
                .ToListAsync();
            return consulta;
        }
        public async Task<EmpleadoView> FindEmpleadoAsync(int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadosView
                           where datos.IdEmpleado == idEmpleado
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }
        //var data = await consulta.ToListAsync();
        //    return data.First();
    }
}
