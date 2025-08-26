using BibliotecaLibrosAPI.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuración de servicios para permitir solicitudes CORS
builder.Services.AddCors(options =>
{
    // Definición de una política de CORS llamada "AllowSpecificOrigin"
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            // Especifica que solo se permite el origen de la URL indicada
            builder.WithOrigins("http://127.0.0.1:5500") // URL del frontend

                   // Permite cualquier encabezado en la solicitud
                   .AllowAnyHeader()

                   // Permite cualquier método HTTP (GET, POST, PUT, DELETE, etc.)
                   .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configuración de los servicios de la aplicación para usar un contexto de base de datos
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer("Server=LOCALMARIO\\SQLEXPRESS;Database=BibliotecaLibrosAPI;Trusted_Connection=True;Encrypt=False;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilita el uso de la política CORS llamada "AllowSpecificOrigin"
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
