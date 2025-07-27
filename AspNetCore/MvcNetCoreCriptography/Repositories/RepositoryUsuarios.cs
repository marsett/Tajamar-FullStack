using Microsoft.EntityFrameworkCore;
using MvcNetCoreCriptography.Data;
using MvcNetCoreCriptography.Helpers;
using MvcNetCoreCriptography.Models;

namespace MvcNetCoreCriptography.Repositories
{
    public class RepositoryUsuarios
    {
        private UsuariosContext context;

        public RepositoryUsuarios(UsuariosContext context)
        {
            this.context = context;
        }

        private async Task<int> GetMaxIdUser()
        {
            if (this.context.Usuarios.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Usuarios.
                    MaxAsync(x => x.IdUsuario) + 1;
            }
        }

        public async Task RegisterUserAsync(string nombre, string email, string password, string imagen)
        {
            Usuario user = new Usuario();
            user.IdUsuario = await this.GetMaxIdUser();
            user.Nombre = nombre;
            user.Email = email;
            user.Imagen = imagen;
            // Cada usuario tendrá un salt diferente
            user.Salt = HelperCriptography.GenerateSalt();
            // Almacenamos el password cifrado a byte[]
            user.Password = HelperCriptography.EncryptPassword(password, user.Salt);
            this.context.Usuarios.Add(user);
            await this.context.SaveChangesAsync();
        }

        // Necesitamos un método para hacer un login de usuario
        // y devolvemos al usuario si hemos comprobado todo
        // correctamente como tenemos cifrado, debemos hacer el
        // login pidiendo datos únicos (email, username, nif)
        public async Task<Usuario> LogInUserAsync(string email, string password)
        {
            // Buscamos al usuario por el dato único (email)
            var consulta = from datos in this.context.Usuarios
                           where datos.Email == email
                           select datos;
            Usuario user = await consulta.FirstOrDefaultAsync();
            if(user == null)
            {
                return null;
            }else
            {
                // Recuperamos el salt del usuario de bbdd
                string salt = user.Salt;
                // Convertimos el password que nos han dado y el salt
                // a byte[]
                byte[] temp = HelperCriptography.EncryptPassword(password, salt);
                // Recuperamos el password de byte[] de bbdd
                byte[] passBytes = user.Password;
                // Por último, realizamos la comparación de arrays
                bool response = HelperCriptography.CompararArrays(temp, passBytes);
                if(response == true)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
