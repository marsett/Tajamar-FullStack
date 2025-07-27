using Microsoft.Azure.Cosmos;
using MvcCoreAzureCosmos.Models;

namespace MvcCoreAzureCosmos.Services
{
    public class ServiceCosmosDb
    {
        // Dentro de Cosmos trabajamos con client y containers
        // dentro de los containers están los items
        // Desde el código vamos a crear un container también
        // Recibiremos dos clases, una el CosmosClient para
        // trabajar con containers
        // Recibiremos un container que será nuestra tabla
        private CosmosClient clientCosmos;
        private Container containerCosmos;
        public ServiceCosmosDb(CosmosClient clientCosmos, Container containerCosmos)
        {
            this.clientCosmos = clientCosmos;
            this.containerCosmos = containerCosmos;
        }

        // Vamos a crear un método para crear nuestra base de datos y dentro
        // nuestro container para los items
        public async Task CreateDatabaseAsync()
        {
            // Creamos primero la base de datos
            await this.clientCosmos.CreateDatabaseIfNotExistsAsync("vehiculoscosmos");
            // Dentro de esta base de datos, crearemos nuestros container
            ContainerProperties properties = new ContainerProperties("containercoches", "/id");
            // Creamos el container dentro de nuestra bbdd
            await this.clientCosmos.GetDatabase("vehiculoscosmos")
                .CreateContainerIfNotExistsAsync(properties);
        }

        // Método para insertar elementos dentro de Cosmos
        public async Task InsertCocheAsync(Coche car)
        {
            // En el momento de insertar, Cosmos no sabe
            // asignar automáticamente su partition key
            // debemos decírselo de forma explícita
            await this.containerCosmos
                .CreateItemAsync<Coche>(car, new PartitionKey(car.Id));
        }

        public async Task<List<Coche>> GetCochesAsync()
        {
            // Una base de datos cosmos no sabe el número de registros reales
            // Debemos leer utilizando un bucle while mientras que existan
            // registros
            var query = this.containerCosmos.GetItemQueryIterator<Coche>();
            List<Coche> coches = new List<Coche>();
            while (query.HasMoreResults)
            {
                var results = await query.ReadNextAsync();
                // Son múltiples coches los que devuelve,
                // se almacenan dentro de nuestra colección a la vez
                coches.AddRange(results);
            }
            return coches;
        }

        public async Task UpdateCocheAsync(Coche car)
        {
            // Voy a utilizar un método llamado upsert
            // Dicho método, si encuentra el coche lo modifica
            // y si no lo encuentra lo inserta
            await this.containerCosmos.UpsertItemAsync<Coche>(car, new PartitionKey(car.Id));
        }

        public async Task DeleteCocheAsync(string id)
        {
            await this.containerCosmos.DeleteItemAsync<Coche>(id, new PartitionKey(id));
        }

        // Método para buscar un coche por su id
        public async Task<Coche> FindCocheAsync(string id)
        {
            ItemResponse<Coche> response = await
                this.containerCosmos.ReadItemAsync<Coche>
                (id, new PartitionKey(id));
            return response.Resource;
        }

        public async Task<List<Coche>> GetCochesMarcaAsync(string marca)
        {
            string sql = "select * from c where c.Marca='" + marca + "'";
            // Para aplicar los filtros se utiliza una clase
            // llamada QueryDefinition
            QueryDefinition definition = new QueryDefinition(sql);
            var query = this.containerCosmos.GetItemQueryIterator<Coche>();
            List<Coche> coches = new List<Coche>();
            while (query.HasMoreResults)
            {
                var results = await query.ReadNextAsync();
                coches.AddRange(results);
            }
            return coches;
        }
    }
}
