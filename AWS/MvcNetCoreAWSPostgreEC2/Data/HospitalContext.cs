using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgreEC2.Models;

namespace MvcNetCoreAWSPostgreEC2.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options): base(options) { }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
