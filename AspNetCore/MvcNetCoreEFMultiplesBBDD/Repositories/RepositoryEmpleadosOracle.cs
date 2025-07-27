﻿using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

#region
/*
 CREATE OR REPLACE VIEW V_EMPLEADOS
AS
	SELECT EMP.EMP_NO AS IDEMPLEADO
	, EMP.APELLIDO, EMP.OFICIO
	, EMP.SALARIO, DEPT.DNOMBRE AS DEPARTAMENTO
	, DEPT.LOC AS LOCALIDAD
	FROM EMP
	INNER JOIN DEPT
	ON EMP.DEPT_NO = DEPT.DEPT_NO;
CREATE OR REPLACE PROCEDURE SP_ALL_EMPLEADOS
(p_cursor_empleados OUT SYS_REFCURSOR)
AS
BEGIN
	OPEN p_cursor_empleados for
	SELECT * FROM V_EMPLEADOS;
END;
 */
#endregion

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosOracle : IRepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleadosOracle(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            string sql = "begin ";
            sql += "SP_ALL_VEMPLEADOS (:p_cursor_empleados);";
            sql += " end;";
            OracleParameter pamCursor = new OracleParameter();
            pamCursor.ParameterName = "p_cursor_empleados";
            pamCursor.Value = null;
            pamCursor.Direction = ParameterDirection.Output;
            // Debemos indicar el tipo de dato de oracle cursor
            pamCursor.OracleDbType = OracleDbType.RefCursor;
            var consulta = this.context.EmpleadosView.
                FromSqlRaw(sql, pamCursor);
            return await consulta.ToListAsync();
        }

        public async Task<EmpleadoView> FindEmpleadoAsync(int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadosView
                           where datos.IdEmpleado == idEmpleado
                           select datos;
            var data = await consulta.ToListAsync();
            return data.First();
        }
    }
}
