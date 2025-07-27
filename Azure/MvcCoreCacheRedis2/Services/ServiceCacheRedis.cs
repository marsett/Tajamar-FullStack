using MvcCoreCacheRedis.Models;
using MvcCoreCacheRedis2.Helpers;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MvcCoreCacheRedis2.Services
{
    public class ServiceCacheRedis
    {
        private IDatabase database;
        public ServiceCacheRedis()
        {
            this.database = HelperCacheMultiplexer.Connection.GetDatabase();
        }

        // Método para almacenar productos
        // Las claves deben ser únicas por usuario
        public async Task AddProductoFavoritoAsync(Producto producto)
        {
            // Redis trabaja con keys/values para recuperar los elementos o
            // almacenar los elementos en formato json
            // Almacenar en redis un conjunto de productos favoritos
            string jsonProductos = await this.database.StringGetAsync("favoritos");
            List<Producto> productosList;
            if(jsonProductos == null)
            {
                productosList = new List<Producto>();
            }
            else
            {
                // Recuperamos la colección de cache redis
                productosList = JsonConvert.DeserializeObject<List<Producto>>(jsonProductos);
            }
            // Agregamos el producto nuevo
            productosList.Add(producto);
            // Con el producto agregado, volvemos a generar el json de productos
            jsonProductos = JsonConvert.SerializeObject(productosList);
            // Almacenamos los datos de nuevo en cache redis
            await this.database.StringSetAsync("favoritos", jsonProductos);
        }

        // Realizamos un método para recuperar los productos favoritos
        public async Task<List<Producto>> GetProductosFavoritosAsync()
        {
            string jsonProductos = await this.database.StringGetAsync("favoritos");
            if(jsonProductos == null)
            {
                return null;
            }
            else
            {
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(jsonProductos);
                return productos;
            }
        }

        public async Task DeleteProductoFavoritoAsync(int idProducto)
        {
            // Esto no es una base de datos, no podemos filtrar ni buscar,
            // solamente extraer
            List<Producto> favoritos = await this.GetProductosFavoritosAsync();
            // Si existen favoritos, eliminamos
            if(favoritos != null)
            {
                // Buscamos el producto a eliminar
                Producto productoDelete = favoritos.FirstOrDefault(x => x.IdProducto == idProducto);
                // Eliminamos el producto de la colección
                favoritos.Remove(productoDelete);
                // Si eliminamos todos los productos, debemos eliminar cache redis
                if(favoritos.Count == 0)
                {
                    await this.database.KeyDeleteAsync("favoritos");
                }
                else
                {
                    // Almacenamos los productos favoritos de nuevo
                    string jsonProductos = JsonConvert.SerializeObject(favoritos);
                    // Volvemos a guardar nuestro cache redis
                    // Vamos a darle tiempo al guardar un elemento en redis
                    // Si no le decimos nada, por defecto redis almacena los datos 24 horas
                    await this.database.StringSetAsync("favoritos", jsonProductos, TimeSpan.FromMinutes(30));
                }
            }
        }
    }
}
