using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;
using Microsoft.EntityFrameworkCore;
using ExamenApiAzureMario.Data;
using ExamenApiAzureMario.Helpers;
using ExamenApiAzureMario.Repositories;
using ExamenApiAzureMario.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
});

SecretClient secretClient = builder.Services.BuildServiceProvider().GetRequiredService<SecretClient>();

KeyVaultSecret secretConnectionString = await secretClient.GetSecretAsync("SqlAzure");
KeyVaultSecret secretStorageAccount = await secretClient.GetSecretAsync("StorageAccount");

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAuthorization();

HelperActionServicesOAuth helper = new HelperActionServicesOAuth(builder.Configuration);
builder.Services.AddSingleton<HelperActionServicesOAuth>(helper);
builder.Services.AddAuthentication(helper.GetAuthenticationOptions())
                .AddJwtBearer(helper.GetJwtBearerOptions());

string connectionString = secretConnectionString.Value;
builder.Services.AddDbContext<CubosContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<RepositoryCubos>();

string azurekeys = secretStorageAccount.Value;
BlobServiceClient blobServiceClient = new BlobServiceClient(azurekeys);
builder.Services.AddTransient<BlobServiceClient>(x => blobServiceClient);
builder.Services.AddTransient<ServiceBlobs>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Examen API MARIO"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();