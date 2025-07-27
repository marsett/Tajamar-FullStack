using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebJobChollometro.Data;
using WebJobChollometro.Repositories;

//Console.WriteLine("Bienvenido a nuestros chollos");
string connectionString = "Data Source=sqlmario3213.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=adminsql;Password=Admin123;Encrypt=True;Trust Server Certificate=True";

// Necesitamos utilizar inyección de dependencias para poder
// crear los objetos
var provider = new ServiceCollection().
    AddTransient<RepositoryChollometro>().
    AddDbContext<ChollometroContext>
    (
        options => options.UseSqlServer(connectionString)
    ).BuildServiceProvider();
// Desde este código necesitamos recuperar el repo inyectado
RepositoryChollometro repo = provider.GetService<RepositoryChollometro>();
//Console.WriteLine("Pulse Enter para iniciar");
//Console.ReadLine();
await repo.PopulateChollosAzureAsync();
//Console.WriteLine("Proceso completado correctamente");
//Console.WriteLine("¡Enhorabuena!");