using ApiOAuthEmpleados.Data;
using ApiOAuthEmpleados.Helpers;
using ApiOAuthEmpleados.Repositories;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

HelperCryptography.Initialize(builder.Configuration);
// Inyectamos HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Creamos una instancia de nuestro helper
HelperActionServicesOAuth helper = new HelperActionServicesOAuth(builder.Configuration);
// Esta instancia solamente debemos crearla una vez
// para que nuestra aplicaci�n pueda validar con todo lo que ha creado
builder.Services.AddSingleton<HelperActionServicesOAuth>(helper);
// Habilitamos la seguridad utilizando la clase helper
builder.Services.AddAuthentication(helper.GetAuthenticateSchema())
    .AddJwtBearer(helper.GetJwtBearerOptions());

builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
});

// Add services to the container.
// Ya no utilizaremos configuration nunca m�s
// Necesitamos recuperar el objeto inyectado
//SecretClient secretClient = builder.Services.BuildServiceProvider().GetService<SecretClient>();
//KeyVaultSecret secret = await secretClient.GetSecretAsync("SqlAzure");
//string connectionString = secret.Value;
string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryHospital>();
builder.Services.AddDbContext<HospitalContext>(
    options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Api Seguridad Empleados");
    options.RoutePrefix = "";
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
