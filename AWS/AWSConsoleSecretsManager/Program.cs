using AWSConsoleSecretsManager;
using AWSConsoleSecretsManager.Helpers;
using AWSConsoleSecretsManager.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

Console.WriteLine("Ejemplo Secrets Manager");
string miSecreto = await HelperSecretManager.GetSecretAsync();
Console.WriteLine(miSecreto);
// Podemos serializar nuestro string y deserializarlo con 
// la clase KeysModel ya que las propiedades se llaman igual
KeysModel model = JsonConvert.DeserializeObject<KeysModel>(miSecreto);
Console.WriteLine("MySql: " + model.MySql);
// Almacenamos el objeto KeysModel dentro del Builder
var provider = new ServiceCollection().AddTransient<ClaseTest>().AddSingleton<KeysModel>(x => model).BuildServiceProvider();
// En cualquier clase ya podemos recuperar las keys
// Vamos a comprobar si funciona dentro de clasetest
var test = provider.GetService<ClaseTest>();
Console.WriteLine("Bucket Value: " + test.GetBucketValue());

Console.WriteLine("Pulse enter para finalizar");
Console.ReadLine();