using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Newtonsoft.Json;
using ApiCrudAWSSeries.Repositories;
using ApiCrudAWSSeries.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApiCrudAWSSeries;

public class Functions
{
    private RepositorySeries repo;
    public Functions(RepositorySeries repo)
    {
        this.repo = repo;
    }
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public async Task<IHttpResult> Get(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        List<Serie> series = await this.repo.GetSeriesAsync();
        return HttpResults.Ok(series);
    }
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/find/{id}")]
    public async Task<IHttpResult> FindSerie(int id, ILambdaContext context)
    {
        Serie serie = await this.repo.FindSerieAsync(id);
        return HttpResults.Ok(serie);
    }
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Post, "/post")]
    public async Task<IHttpResult> Post([FromBody] Serie serie, ILambdaContext context)
    {
        await this.repo.CreateSerieAsync(serie.Nombre, serie.Imagen, serie.Anyo);
        return HttpResults.Ok();
    }
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Put, "/put/{id}")]
    public async Task<IHttpResult> Put(int id, [FromBody] Serie serie, ILambdaContext context)
    {
        await this.repo.UpdateSerieAsync(id, serie.Nombre, serie.Imagen, serie.Anyo);
        return HttpResults.Ok();
    }
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Delete, "/delete/{id}")]
    public async Task<IHttpResult> Delete(int id)
    {
        await this.repo.DeleteSerieAsync(id);
        return HttpResults.Ok();
    }
}
