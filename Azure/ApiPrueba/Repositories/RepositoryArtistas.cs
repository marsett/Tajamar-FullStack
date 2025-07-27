using ApiPrueba.Data;
using ApiPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.Repositories
{
    public class RepositoryArtistas
    {
        private ArtistasContext context;

        public RepositoryArtistas(ArtistasContext context)
        {
            this.context = context;
        }

        public async Task<List<Artista>> GetArtistasAsync()
        {
            return await this.context.Artistas.ToListAsync();
        }

        public async Task<Artista> FindArtistaAsync
            (int idArtista)
        {
            return await this.context.Artistas
                .FirstOrDefaultAsync
                (x => x.IdArtista == idArtista);
        }

        public async Task InsertArtistaAsync(int id, string nombre
            , string cancion, int edad, string pais)
        {
            Artista artista = new Artista();
            artista.IdArtista = id;
            artista.Nombre = nombre;
            artista.CancionFavorita = cancion;
            artista.Edad = edad;
            artista.Pais = pais;
            await this.context.Artistas.AddAsync(artista);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateArtistaAsync
            (int id, string nombre
            , string cancion, int edad, string pais)
        {
            Artista artista = await this.FindArtistaAsync(id);
            artista.Nombre = nombre;
            artista.CancionFavorita = cancion;
            artista.Edad = edad;
            artista.Pais = pais;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteArtistaAsync(int id)
        {
            Artista artista = await this.FindArtistaAsync(id);
            this.context.Artistas.Remove(artista);
            await this.context.SaveChangesAsync();
        }
    }

}
