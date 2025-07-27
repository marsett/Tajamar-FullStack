using NugetCoches;

Console.WriteLine("Mis coches de Nuget");
Garaje g = new Garaje();
List<Coche> cars = g.GetCoches();
foreach(Coche c in cars)
{
    Console.WriteLine(c.Marca + " " + c.Modelo);
}
Console.WriteLine("Fin de programa");
