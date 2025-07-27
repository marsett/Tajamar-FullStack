using Microsoft.EntityFrameworkCore;
using MvcCoreDepartamentosEF.Data;
using MvcCoreDepartamentosEF.Models;

namespace MvcCoreDepartamentosEF.Repositories
{
    public class RepositoryDepartamento
    {
        private DepartamentoContext context;
        public RepositoryDepartamento(DepartamentoContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int idDepartamento)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == idDepartamento
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task InsertDepartamentoAsync(int idDepartamento, string nombre,
            string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = idDepartamento;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDepartamentoAsync(int idDepartamento)
        {
            Departamento departamento = await this.FindDepartamentoAsync(idDepartamento);
            this.context.Departamentos.Remove(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync(int idDepartamento, string nombre,
            string localidad)
        {
            Departamento departamento = await this.FindDepartamentoAsync(idDepartamento);
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            await this.context.SaveChangesAsync();
        }
    }
}
