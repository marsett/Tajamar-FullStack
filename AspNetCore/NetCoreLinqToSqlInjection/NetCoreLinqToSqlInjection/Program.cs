using NetCoreLinqToSqlInjection.Models;
using NetCoreLinqToSqlInjection.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Resolvemos el servicio Coche
//builder.Services.AddTransient<Coche>();
//builder.Services.AddSingleton<Coche>();
//builder.Services.AddSingleton<ICoche, Deportivo>();
Coche car = new Coche();
car.Marca = "Porsche";
car.Modelo = "GT3";
car.Imagen = "gt3.jpg";
car.Velocidad = 0;
car.VelocidadMaxima = 280;
// Para enviar nuestro objeto personalizado se utiliza lambda
builder.Services.AddSingleton<ICoche, Coche>(x => car);

builder.Services.AddTransient<IRepositoryDoctores, RepositoryDoctoresOracle>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Coches");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Coches}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
