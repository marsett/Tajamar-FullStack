using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using ApiAWSPersonas.Models;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApiAWSPersonas;

public class Functions
{
    public List<Persona> personasList;
    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    public Functions()
    {
        this.personasList = new List<Persona>();
        Persona p = new Persona
        {
            IdPersona = 1,
            Nombre = "José",
            Email = "jose@gmail.com",
            Edad = 45
        };
        this.personasList.Add(p);
        p = new Persona
        {
            IdPersona = 2,
            Nombre = "Mario",
            Email = "mario@gmail.com",
            Edad = 21
        };
        this.personasList.Add(p);
        p = new Persona
        {
            IdPersona = 3,
            Nombre = "Sandokan",
            Email = "sandokan@gmail.com",
            Edad = 675
        };
        this.personasList.Add(p);
        p = new Persona
        {
            IdPersona = 4,
            Nombre = "Genghis Khan",
            Email = "khan@gmail.com",
            Edad = 1045
        };
        this.personasList.Add(p);
    }


    /// <summary>
    /// A Lambda function to respond to HTTP Get methods from API Gateway
    /// </summary>
    /// <remarks>
    /// This uses the <see href="https://github.com/aws/aws-lambda-dotnet/blob/master/Libraries/src/Amazon.Lambda.Annotations/README.md">Lambda Annotations</see> 
    /// programming model to bridge the gap between the Lambda programming model and a more idiomatic .NET model.
    /// 
    /// This automatically handles reading parameters from an APIGatewayProxyRequest
    /// as well as syncing the function definitions to serverless.template each time you build.
    /// 
    /// If you do not wish to use this model and need to manipulate the API Gateway 
    /// objects directly, see the accompanying Readme.md for instructions.
    /// </remarks>
    /// <param name="context">Information about the invocation, function, and execution environment</param>
    /// <returns>The response as an implicit <see cref="APIGatewayProxyResponse"/></returns>
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public IHttpResult Get(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        string json = JsonConvert.SerializeObject(this.personasList);
        return HttpResults.Ok(json);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/find/{id}")]
    public IHttpResult Find(int id, ILambdaContext context)
    {
        Persona persona = this.personasList.FirstOrDefault(x => x.IdPersona == id);
        string json = JsonConvert.SerializeObject(persona);
        return HttpResults.Ok(json);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Post, "/post")]
    // Para recibir objetos, debemos incluir [FromBody]
    // en la declaración del método en el objeto
    public IHttpResult Post([FromBody]Persona persona, ILambdaContext context)
    {
        string json = JsonConvert.SerializeObject(persona);
        return HttpResults.Ok(json);
    }
}
