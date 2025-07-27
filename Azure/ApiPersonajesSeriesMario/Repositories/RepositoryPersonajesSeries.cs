using ApiPersonajesSeriesMario.Data;
using ApiPersonajesSeriesMario.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesSeriesMario.Repositories
{
    public class RepositoryPersonajesSeries
    {
        private SeriesContext context;
        public RepositoryPersonajesSeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int idPersonaje)
        {
            return await this.context.Personajes
                .FirstOrDefaultAsync(x => x.IdPersonaje == idPersonaje);
        }

        public async Task UpdatePersonajeSerieAsync
            (int idPersonaje, int idSerie)
        {
            Personaje personaje = await this.FindPersonajeAsync(idPersonaje);
            if(personaje != null)
            {
                personaje.IdSerie = idSerie;
                //this.context.Update(personaje);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int idSerie)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == idSerie);
        }

        public async Task<List<Personaje>> GetPersonajesPorSerieAsync(int idSerie)
        {
            return await this.context.Personajes.Where(x => x.IdSerie == idSerie).ToListAsync();
        }

        public async Task<List<Personaje>> GetPersonajesPorMultiplesSeriesAsync(List<int> idsSeries)
        {
            return await this.context.Personajes.Where(x => idsSeries.Contains(x.IdSerie)).ToListAsync();
        }
    }
}
