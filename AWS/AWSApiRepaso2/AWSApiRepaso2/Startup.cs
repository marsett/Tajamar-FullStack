using AWSApiRepaso2.Data;
using AWSApiRepaso2.Helpers;
using AWSApiRepaso2.Models;
using AWSApiRepaso2.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace AWSApiRepaso2;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services) {
        string jsonSecrets = HelperSecretManager.GetSecretAsync().Result;
        KeysModel keysModel = JsonConvert.DeserializeObject<KeysModel>(jsonSecrets);

        services.AddSingleton<KeysModel>(x => keysModel);

        string connectionString = keysModel.MySql;
        services.AddDbContext<PeliculasContext>
            (options => options.UseSqlServer(connectionString));

        services.AddTransient<RepositoryPeliculas>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", x => x.AllowAnyOrigin());
        });

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api Repaso",
                Version = "v1"
            });
        });

        services.AddAuthorization();

        services.AddControllers();
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(options => options.AllowAnyOrigin());

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(url: "swagger/v1/swagger.json",
                "ApiRepaso");
            options.RoutePrefix = "";
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}