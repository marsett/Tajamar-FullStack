using Azure.Data.Tables;
using Azure.Data.Tables.Sas;

namespace ApiAzureStorageTokens.Services
{
    public class ServiceSaSToken
    {
        private TableClient tableAlumnos;
        public ServiceSaSToken(IConfiguration configuration)
        {
            string azureKeys = configuration.GetValue<string>("AzureKeys:StorageAccount");
            TableServiceClient serviceClient = new TableServiceClient(azureKeys);
            this.tableAlumnos = serviceClient.GetTableClient("alumnos");
        }

        public string GenerateToken(string curso)
        {
            // Necesitamos los permisos de acceso, por ahora
            // solamente permitiremos lectura
            TableSasPermissions permisos = TableSasPermissions.Read | TableSasPermissions.Add;
            // El acceso al token está delimitado por un tiempo
            // necesitamos incluir el tiempo que tendrá acceso
            // a leer los elementos
            TableSasBuilder builder = this.tableAlumnos.GetSasBuilder(permisos, DateTime.UtcNow.AddMinutes(30));
            // Como row key y partition key son string podemos
            // limitar el acceso de forma alfabética a los datos,
            // ya sea por row key, partition key o los dos
            builder.PartitionKeyStart = curso;
            builder.PartitionKeyEnd = curso;
            // Con esto ya podemos generar el token que
            // es un acceso por uri
            Uri uriToken = this.tableAlumnos.GenerateSasUri(builder);
            string token = uriToken.AbsoluteUri;
            return token;
        }
    }
}
