using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcNetCorePaginacionRegistros.Data;
using MvcNetCorePaginacionRegistros.Models;
using System.Data;

#region
/*
 create view V_DEPARTAMENTOS_INDIVIDUAL
as
select CAST(ROW_NUMBER() over (order by DEPT_NO) as int ) AS POSICION
, DEPT_NO, DNOMBRE, LOC from DEPT
go

create procedure SP_GRUPO_DEPARTAMENTOS
(@posicion int)
as
	select DEPT_NO, DNOMBRE, LOC from V_DEPARTAMENTOS_INDIVIDUAL
	where POSICION >= @posicion AND POSICION < (@posicion + 2)
go

create view V_GRUPO_EMPLEADOS
as
	select CAST(ROW_NUMBER() over (order by APELLIDO) as INT) as POSICION,
	EMP_NO, APELLIDO, OFICIO, SALARIO, DEPT_NO FROM EMP
go
create procedure SP_GRUPO_EMPLEADOS
(@posicion int)
as
	select EMP_NO, APELLIDO, OFICIO, SALARIO, DEPT_NO FROM V_GRUPO_EMPLEADOS
	where POSICION >= @posicion AND POSICION < (@posicion + 3)
go

create procedure SP_GRUPO_EMPLEADOS_OFICIO
(@posicion int, @oficio nvarchar(50))
as
	select EMP_NO, APELLIDO, OFICIO, SALARIO, DEPT_NO
	from(
		select 
			ROW_NUMBER() over (order by APELLIDO) as POSICION,
			EMP_NO, APELLIDO, OFICIO, SALARIO, DEPT_NO FROM EMP
			where OFICIO = @oficio
	) 
	query where POSICION >= @posicion AND POSICION < (@posicion + 2)
go

create procedure SP_GRUPO_EMPLEADOS_OFICIO_OUT
(@posicion int, @oficio nvarchar(50)
, @registros int out)
as
--ALMACENAMOS EL NÚMERO DE REGISTROS DEL FILTRO
select @registros = count(EMP_NO) from EMP
where OFICIO=@oficio
	select EMP_NO, APELLIDO, OFICIO, SALARIO, DEPT_NO
	from(
		select 
			ROW_NUMBER() over (order by APELLIDO) as POSICION,
			EMP_NO, APELLIDO, OFICIO, SALARIO, DEPT_NO FROM EMP
			where OFICIO = @oficio
	) 
	query where POSICION >= @posicion AND POSICION < (@posicion + 2)
go

create procedure SP_EMPLEADOS_DEPARTAMENTO_OUT
(@posicion int, @iddepartamento int, @num_empleados int out)
as
	SELECT @num_empleados = COUNT(EMP_NO) 
    FROM EMP 
    WHERE DEPT_NO = @iddepartamento
    
    SELECT EMP_NO, APELLIDO, OFICIO, SALARIO, DEPT_NO
    FROM (
        SELECT CAST(ROW_NUMBER() OVER (ORDER BY EMP_NO) AS INT) AS POSICION,
               EMP_NO, APELLIDO, OFICIO, SALARIO, DEPT_NO
        FROM EMP 
        WHERE DEPT_NO = @iddepartamento
    ) AS EMPLEADOS
    WHERE POSICION = @posicion
go
 */
#endregion

namespace MvcNetCorePaginacionRegistros.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<ModelEmpleadosDepartamento> GetEmpleadosDepartamentoAsync(int posicion, int iddepartamento)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTO_OUT @posicion, @iddepartamento, @num_empleados out";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            SqlParameter pamIddepartamento = new SqlParameter("@iddepartamento", iddepartamento);
            SqlParameter pamNumEmpleados = new SqlParameter("@num_empleados", 0);
            pamNumEmpleados.Direction = ParameterDirection.Output;

            var consulta =
                this.context.Empleados.FromSqlRaw
                (sql, pamPosicion, pamIddepartamento, pamNumEmpleados);
            List<Empleado> empleados = await consulta.ToListAsync();

            int registros = int.Parse(pamNumEmpleados.Value.ToString());

            Departamento dept = await GetDepartamentoDetallesAsync(iddepartamento);

            return new ModelEmpleadosDepartamento
            {
                Departamento = dept,
                NumeroRegistros = registros,
                Empleados = empleados,
                Posicion = posicion,
            };
        }

        public async Task<Departamento> GetDepartamentoDetallesAsync(int iddepartamento)
        {
            Departamento dept = await this.context.Departamentos.
                Where(x => x.IdDepartamento == iddepartamento).FirstOrDefaultAsync();
            return dept;
        }

        public async Task<List<Departamento>> GetDepartamentosDropdownAsync()
        {
            List<Departamento> departamentos = await this.context.Departamentos.
                ToListAsync();
            return departamentos;
        }

        public async Task<ModelEmpleadosOficio> GetEmpleadosOficioOutAsync(int posicion, string oficio)
        {
            string sql = "SP_GRUPO_EMPLEADOS_OFICIO_OUT @posicion, @oficio, @registros out";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            SqlParameter pamOficio = new SqlParameter("@oficio", oficio);
            SqlParameter pamRegistros = new SqlParameter("@registros", 0);
            pamRegistros.Direction = ParameterDirection.Output;
            var consulta =
                this.context.Empleados.FromSqlRaw
                (sql, pamPosicion, pamOficio, pamRegistros);
            //PRIMERO DEBEMOS EJECUTAR LA CONSULTA PARA PODER 
            //RECUPERAR LOS PARAMETROS DE SALIDA
            List<Empleado> empleados = await consulta.ToListAsync();

            int registros = int.Parse(pamRegistros.Value.ToString());
            return new ModelEmpleadosOficio
            {
                NumeroRegistros = registros,
                Empleados = empleados
            };
        }

        public async Task<int> GetEmpleadosOficioCountAsync(string oficio)
        {
            return await this.context.Empleados.
                Where(x => x.Oficio == oficio).CountAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(int posicion, string oficio)
        {
            string sql = "SP_GRUPO_EMPLEADOS_OFICIO @posicion, @oficio";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            SqlParameter pamOficio = new SqlParameter("@oficio", oficio);
            var consulta = this.context.Empleados.FromSqlRaw(sql, pamPosicion, pamOficio);
            return await consulta.ToListAsync();
        }

        public async Task<int> GetEmpleadosCountAsync()
        {
            return await this.context.Empleados.CountAsync();
        }

        public async Task<List<Empleado>> GetGrupoEmpleadosAsync(int posicion)
        {
            string sql = "SP_GRUPO_EMPLEADOS @posicion";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            var consulta = this.context.Empleados.FromSqlRaw(sql, pamPosicion);
            return await consulta.ToListAsync();
        }

        public async Task<int> GetNumeroRegistrosVistaDepartamentosAsync()
        {
            return await this.context.VistaDepartamentos.CountAsync();
        }

        public async Task<List<Departamento>> GetGrupoDepartamentosAsync(int posicion)
        {
            string sql = "SP_GRUPO_DEPARTAMENTOS @posicion";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            var consulta = this.context.Departamentos.FromSqlRaw(sql, pamPosicion);
            return await consulta.ToListAsync();
        }

        public async Task<List<VistaDepartamento>> GetGrupoVistaDepartamentoAsync(int posicion)
        {
            var consulta = from datos in this.context.VistaDepartamentos
                           where datos.Posicion >= posicion
                           && datos.Posicion < (posicion + 2)
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<VistaDepartamento> GetVistaDepartamentoAsync(int posicion)
        {
            VistaDepartamento departamento = await this.context.VistaDepartamentos.
                Where(z => z.Posicion == posicion).FirstOrDefaultAsync();
            return departamento;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            var departamentos = await this.context.Departamentos.ToListAsync();
            return departamentos;
        }
        public async Task<List<Empleado>> GetEmpleadosDepartamentoAsync(int idDepartamento)
        {
            var empleados = this.context.Empleados.
                            Where(x => x.IdDepartamento == idDepartamento);
            if (empleados.Count() == 0)
            {
                return null;
            }
            else
            {
                return await empleados.ToListAsync();
            }
        }
    }
}
