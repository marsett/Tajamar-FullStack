using Microsoft.EntityFrameworkCore;
using MvcCoreDepartamentosEF.Models;

namespace MvcCoreDepartamentosEF.Data
{
    public class DepartamentoContext: DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext> options)
            :base(options)
        {
            
        }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
