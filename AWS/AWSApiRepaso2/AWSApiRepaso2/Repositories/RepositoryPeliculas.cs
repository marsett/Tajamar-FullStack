using AWSApiRepaso2.Data;
using AWSApiRepaso2.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSApiRepaso2.Repositories
{
    public class RepositoryPeliculas
    {
        private PeliculasContext context;

        public RepositoryPeliculas(PeliculasContext context) {
            this.context = context;
        }

        public async Task<List<Pelicula>> GetPeliculasAsync() {
            return await this.context.Peliculas.ToListAsync();
        }

        public async Task<Pelicula> FindPeliculaAsync(int id) {
            return await this.context.Peliculas.FirstOrDefaultAsync(p => p.IdPelicula == id);
        }

        public async Task<List<Pelicula>> GetPeliculasActoresAsync(string actor) {
            return await this.context.Peliculas
                .Where(p => p.Actores.Contains(actor))
                .ToListAsync();
        }

        public async Task<int> GetNextIdAsync() {
            var lastPelicula = await this.context.Peliculas
                .OrderByDescending(p => p.IdPelicula)
                .FirstOrDefaultAsync();
            return lastPelicula == null ? 1 : lastPelicula.IdPelicula + 1;
        }

        public async Task CreatePeliculaAsync(Pelicula pelicula) {
            pelicula.IdPelicula = await GetNextIdAsync();
            this.context.Peliculas.Add(pelicula);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePeliculaAsync(Pelicula pelicula) {
            Pelicula editar = await this.FindPeliculaAsync(pelicula.IdPelicula);
            editar.Genero = pelicula.Genero;
            editar.Titulo = pelicula.Titulo;
            editar.Nacionalidad = pelicula.Nacionalidad;
            editar.Argumento = pelicula.Argumento;
            editar.Actores = pelicula.Actores;
            editar.Duracion = pelicula.Duracion;
            editar.Precio = pelicula.Precio;
            editar.Youtube = pelicula.Youtube;

            this.context.Peliculas.Update(editar);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePeliculaAsync(int id) {
            Pelicula pelicula = await this.FindPeliculaAsync(id);
            if (pelicula != null) {
                this.context.Peliculas.Remove(pelicula);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
