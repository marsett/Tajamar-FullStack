using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Models;

namespace MvcCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == idHospital
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task InsertHospitalAsync(int idHospital, string nombre,
            string direccion, string telefono, int camas)
        {
            // Creamos un model
            Hospital hospital = new Hospital();
            // Asignamos sus propiedades
            hospital.IdHospital = idHospital;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            // Añadimos nuestro model a la colección del DbSet del context
            await this.context.Hospitales.AddAsync(hospital);
            // Indicamos que almacenamos los datos en la bbdd
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteHospitalAsync(int idHospital)
        {
            // Buscamos el model para eliminarlo
            Hospital hospital = await this.FindHospitalAsync(idHospital);
            // Eliminamos de la colección DbSet<T> del context
            this.context.Hospitales.Remove(hospital);
            // Actualizamos la base de datos
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateHospitalAsync(int idHospital, string nombre,
            string direccion, string telefono, int camas)
        {
            // Buscamos el objeto hospital a modificar
            Hospital hospital = await this.FindHospitalAsync(idHospital);
            // Podemos modificar todo lo que deseemos excepto el campo [Key]
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            // No tenemos ningún método para realizar un update dentro del
            // context y DbSet<T>
            await this.context.SaveChangesAsync();
        }
    }
}
