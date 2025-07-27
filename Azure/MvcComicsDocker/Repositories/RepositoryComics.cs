using Microsoft.EntityFrameworkCore;
using MvcComicsDocker.Data;
using MvcComicsDocker.Models;
using System.ComponentModel;

namespace MvcComicsDocker.Repositories
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
            return await this.context.Comics
                .MaxAsync(z => z.IdComic) + 1;
        }

        public async Task CreateComic(string nombre, string imagen)
        {
            Comic c = new Comic();
            c.IdComic = await this.GetMaxIdComicAsync();
            c.Nombre = nombre;
            c.Imagen = imagen;
            await this.context.Comics.AddAsync(c);
            await this.context.SaveChangesAsync();
        }
    }
}
