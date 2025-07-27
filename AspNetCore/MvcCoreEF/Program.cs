using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<RepositoryHospital>();
string connectionString = builder.Configuration.GetConnectionString("SqlHospital");
// Para inyectar un servicio context se utiliza el m�todo
// AddDbContext con las opciones que necesite la bbdd
builder.Services.AddDbContext<HospitalContext>
    (
        options => options.UseSqlServer(connectionString)
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Hospitales/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hospitales}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
