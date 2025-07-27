using Microsoft.EntityFrameworkCore;
using MvcCoreDepartamentosEF.Data;
using MvcCoreDepartamentosEF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<RepositoryDepartamento>();
string connectionString = builder.Configuration.GetConnectionString("SqlDepartamentos");
builder.Services.AddDbContext<DepartamentoContext>
    (
        options => options.UseSqlServer(connectionString)
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Departamentos/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Departamentos}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
