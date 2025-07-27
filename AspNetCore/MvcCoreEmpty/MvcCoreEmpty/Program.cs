var builder = WebApplication.CreateBuilder(args);
// Todo lo que indiquemos serán servicios
// Añadimos los servicios de vistas y controllers
builder.Services.AddControllersWithViews();

var app = builder.Build();
// Debemos indicar que utilizaremos rutas para
// controllers y views

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
    );

app.Run();
