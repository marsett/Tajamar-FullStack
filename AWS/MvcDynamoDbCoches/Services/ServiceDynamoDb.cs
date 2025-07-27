using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using MvcDynamoDbCoches.Models;

namespace MvcDynamoDbCoches.Services
{
    public class ServiceDynamoDb
    {
        public IDynamoDBContext context;
        public ServiceDynamoDb(IDynamoDBContext context)
        {
            this.context = context;
        }

        public async Task CreateCocheAsync(Coche car)
        {
            await this.context.SaveAsync<Coche>(car);
        }

        public async Task DeleteCocheAsync(int idCoche)
        {
            await this.context.DeleteAsync<Coche>(idCoche);
        }

        public async Task<Coche> FindCocheAsync(int idCoche)
        {
            // Si estamos buscando por partitio key tenemos
            // un método que lo realiza por nosotros
            return await this.context.LoadAsync<Coche>(idCoche);
        }

        public async Task<List<Coche>> GetCochesAsync()
        {
            // Debemos buscar la tabla que corresponde a nuestro model
            ITable tabla = this.context.GetTargetTable<Coche>();
            // Para buscar. no sabemos si buscamos todos o filtramos
            // Debemos crear un objeto llamado ScanOptions que llevaría
            // los filtros
            var scanOptions = new ScanOperationConfig();
            var results = tabla.Scan(scanOptions);
            // DynamoDb denomina a lo que almacena como Document
            List<Document> data = await results.GetNextSetAsync();
            // Convertimos Document a nuestro model
            var cars = this.context.FromDocuments<Coche>(data);
            return cars.ToList();
        }

        public async Task<List<Coche>> SearchCochesMarcaAsync(string marca)
        {
            // Para buscar se utilizan un conjunto de condiciones llamadas ScanConditions
            List<ScanCondition> conditions = new List<ScanCondition>();
            conditions.Add(new ScanCondition("Marca", ScanOperator.Equal, marca));
            var cars = await this.context.ScanAsync<Coche>(conditions).GetRemainingAsync();
            return cars.ToList();
        }
    }
}
