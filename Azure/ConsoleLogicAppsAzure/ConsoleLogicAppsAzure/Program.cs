using ConsoleLogicAppsAzure.Services;

Console.WriteLine("Probando Logic Apps");
Console.WriteLine("Introduzca un email");
string email = Console.ReadLine();
Console.WriteLine("Introduzca un asunto");
string asunto = Console.ReadLine();
Console.WriteLine("Escriba un mensaje");
string mensaje = Console.ReadLine();
ServiceLogicApps service = new ServiceLogicApps();
await service.SendEmailAsync(email, asunto, mensaje);
Console.WriteLine("Email enviado correctamente\nPulse ENTER para fin");
Console.ReadLine();