using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgreEC2.Data;
using MvcNetCoreAWSPostgreEC2.Models;

namespace MvcNetCoreAWSPostgreEC2.Repositories
{
    public class RepositoryHospitales
    {
        private HospitalContext context;
        public RepositoryHospitales(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }
        public async Task<Departamento> FindDepartamentoAsync(int idDepartamento)
        {
            return await this.context.Departamentos
                .FirstOrDefaultAsync(x => x.IdDepartamento == idDepartamento);
        }
        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
