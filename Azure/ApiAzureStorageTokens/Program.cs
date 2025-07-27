using ApiAzureStorageTokens;
using ApiAzureStorageTokens.Services;

var builder = WebApplication.CreateBuilder(args);

// Recuperar credenciales desde configuraci�n
string basicAuthUser = builder.Configuration.GetValue<string>("BasicAuth:Username");
string basicAuthPass = builder.Configuration.GetValue<string>("BasicAuth:Password");

// Add services to the container.
builder.Services.AddTransient<ServiceSaSToken>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Aplicar Basic Authentication
app.UseBasicAuth(basicAuthUser, basicAuthPass);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Azure Minimal Api");
    options.RoutePrefix = "";
});
app.UseHttpsRedirection();

// Necesitamos un m�todo GET para acceder al token mediante el curso
// el m�todo, al declararlo, lleva el routing de acceso y tambi�n
// puede llevar par�metros
// Necesitamos recuperar el service dentro de nuestro m�todo del
// minimal api

app.MapGet("/token/{curso}", (string curso, ServiceSaSToken service) =>
{
    string token = service.GenerateToken(curso);
    return new { token = token };
});

app.Run();
