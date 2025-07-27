using Microsoft.EntityFrameworkCore;
using MvcExamenComicsAWS.Data;
using MvcExamenComicsAWS.Models;

namespace MvcExamenComicsAWS.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;
        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }
        public async Task<List<Comic>> GetComicsAsync()
        {
            return await this.context.Comics.ToListAsync();
        }
        private async Task<int> GetMaxIdComicAsync()
        {
            return await this.context.Comics.MaxAsync(x => x.IdComic) + 1;
        }
        public async Task CreateComicAsync(string nombre, string imagen)
        {
            Comic comic = new Comic();
            comic.IdComic = await this.GetMaxIdComicAsync();
            comic.Nombre = nombre;
            comic.Imagen = imagen;
            await this.context.Comics.AddAsync(comic);
            await this.context.SaveChangesAsync();
        }
    }
}
