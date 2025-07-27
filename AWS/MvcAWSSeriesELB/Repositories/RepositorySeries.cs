using Microsoft.EntityFrameworkCore;
using MvcAWSSeriesELB.Data;
using MvcAWSSeriesELB.Models;

namespace MvcAWSSeriesELB.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }
        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }
        private async Task<int> GetMaxIdSerieAsync()
        {
            return await this.context.Series.MaxAsync(x => x.IdSerie) + 1;
        }
        public async Task CreateSerieAsync(string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie();
            serie.IdSerie = await this.GetMaxIdSerieAsync();
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;
            await this.context.Series.AddAsync(serie);
            await this.context.SaveChangesAsync();
        }
    }
}
