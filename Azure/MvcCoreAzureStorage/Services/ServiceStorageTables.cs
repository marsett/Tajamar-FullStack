using Azure.Data.Tables;
using MvcCoreAzureStorage.Models;

namespace MvcCoreAzureStorage.Services
{
    public class ServiceStorageTables
    {
        private TableClient tableClient;
        public ServiceStorageTables(TableServiceClient tableService)
        {
            this.tableClient = tableService.GetTableClient("clientes");
        }
        public async Task CreateClientAsync(int id, string nombre, string empresa, int salario, int edad)
        {
            Cliente cliente = new Cliente
            {
                IdCliente = id,
                Empresa = empresa,
                Nombre = nombre,
                Salario = salario,
                Edad = edad
            };
            await this.tableClient.AddEntityAsync(cliente);
        }

        // Internamente, se pueden buscar clientes por cualquier campo
        // si vamos a realizar una búsqueda, por ejemplo para details
        // no se puede buscar solamente por su row key. se genera
        // una combinación de row key y partition key para buscar
        // por entidad única
        public async Task<Cliente> FindClientAsync(string partitionKey, string rowKey)
        {
            Cliente cliente = await this.tableClient.GetEntityAsync<Cliente>(partitionKey, rowKey);
            return cliente;
        }

        // Para eliminar un elemento único también necesitamos pk y rk
        public async Task DeleteClientAsync(string partitionKey, string rowKey)
        {
            await this.tableClient.DeleteEntityAsync(partitionKey, rowKey);
        }


        public async Task<List<Cliente>> GetClientesAsync()
        {
            List<Cliente> clientes = new List<Cliente>();
            // Para buscar, necesitamos utilizar un objeto query
            // con un filter
            var query = this.tableClient.QueryAsync<Cliente>(filter: "");
            // Debemos extraer todos los datos del query
            await foreach (var item in query)
            {
                clientes.Add(item);
            }
            return clientes;
        }

        public async Task<List<Cliente>> GetClientesEmpresasAsync(string empresa)
        {
            // Tenemos dos tipos de filter, los dos se utilizan
            // con query
            // 1) Si realizamos el filter con QueryAsync, debemos utilizar
            // una sintaxis y extraer los datos manuales
            // string filtro = "Campo eq valor";
            // string filtro = "Campo eq valor and Campo2 gt valor2";
            // string filtro = "Campo lt valor and Campo2 gt valor2";
            // string filtroSalario = "Salario gt 250000 and Salario lt 300000";
            // var query =
            //    this.tableClient.QueryAsync<Cliente>
            // 
            // 2) Si realizamos la consulta con Query,
            // podemos utilizar lambda y extraer los datos directamente,
            // pero no es asíncrono
            var query = this.tableClient.Query<Cliente>(x => x.Empresa == empresa);
            return query.ToList();
        }
    }
}
