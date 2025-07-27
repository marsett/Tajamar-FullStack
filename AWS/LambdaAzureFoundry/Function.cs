using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using LambdaAzureFoundry.Models;
using LambdaAzureFoundry.Helpers;
using Newtonsoft.Json;
using System.Text;
using LambdaAzureFoundry.Helpers.AWSConsoleSecretsManager.Helpers;

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace LambdaAzureFoundry;

public class Function
{
    private static readonly HttpClient httpClient = new HttpClient();

    public async Task<QuestionResponse> FunctionHandler(QuestionRequest request, ILambdaContext context)
    {
        try
        {
            context.Logger.LogInformation($"Pregunta recibida: {request?.Pregunta}");

            // Validación de entrada
            if (request == null || string.IsNullOrEmpty(request.Pregunta))
            {
                return new QuestionResponse
                {
                    Success = false,
                    Error = "No se proporcionó ninguna pregunta válida",
                    Respuesta = null,
                    Completion_Tokens = 0,
                    Prompt_Tokens = 0,
                    Total_Tokens = 0
                };
            }

            // Obtener credenciales
            string miSecreto = await HelperSecretManager.GetSecretAsync();
            AwsSecretos model = JsonConvert.DeserializeObject<AwsSecretos>(miSecreto);

            // Llamar a la función de Azure OpenAI
            var result = await AskQuestion(request.Pregunta, model.API_KEY, model.ENDPOINT);

            context.Logger.LogInformation("Respuesta obtenida exitosamente");
            return result;
        }
        catch (Exception ex)
        {
            context.Logger.LogError($"Error: {ex.Message}");
            return new QuestionResponse
            {
                Success = false,
                Error = ex.Message,
                Respuesta = null,
                Completion_Tokens = 0,
                Prompt_Tokens = 0,
                Total_Tokens = 0
            };
        }
    }

    // Función que llama a Azure OpenAI y devuelve un objeto estructurado
    private static async Task<QuestionResponse> AskQuestion(string question, string apiKey, string endpoint)
    {
        var payload = new
        {
            messages = new object[]
            {
                new
                {
                    role = "system",
                    content = new object[]
                    {
                        new
                        {
                            type = "text",
                            text = "You are an AI assistant that helps people find information."
                        }
                    }
                },
                new
                {
                    role = "user",
                    content = new object[]
                    {
                        new
                        {
                            type = "text",
                            text = question
                        }
                    }
                }
            },
            temperature = 0.7,
            top_p = 0.95,
            max_tokens = 800,
            stream = false
        };

        return await SendRequest(payload, apiKey, endpoint);
    }

    // Función que envía la request y devuelve un objeto estructurado
    private static async Task<QuestionResponse> SendRequest(object payload, string apiKey, string endpoint)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("api-key", apiKey);

            var response = await httpClient.PostAsync(endpoint,
                new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                var responseData = jsonObject?.choices?[0]?.message?.content;
                var completionTokens = (int)(jsonObject?.usage?.completion_tokens ?? 0);
                var promptTokens = (int)(jsonObject?.usage?.prompt_tokens ?? 0);
                var totalTokens = (int)(jsonObject?.usage?.total_tokens ?? 0);

                if (responseData != null)
                {
                    return new QuestionResponse
                    {
                        Success = true,
                        Respuesta = responseData.ToString(),
                        Completion_Tokens = completionTokens,
                        Prompt_Tokens = promptTokens,
                        Total_Tokens = totalTokens,
                        Error = null
                    };
                }
                else
                {
                    return new QuestionResponse
                    {
                        Success = false,
                        Error = "Response data is null",
                        Respuesta = null,
                        Completion_Tokens = 0,
                        Prompt_Tokens = 0,
                        Total_Tokens = 0
                    };
                }
            }
            else
            {
                return new QuestionResponse
                {
                    Success = false,
                    Error = $"HTTP Error: {response.StatusCode}, {response.ReasonPhrase}",
                    Respuesta = null,
                    Completion_Tokens = 0,
                    Prompt_Tokens = 0,
                    Total_Tokens = 0
                };
            }
        }
        catch (Exception ex)
        {
            return new QuestionResponse
            {
                Success = false,
                Error = ex.Message,
                Respuesta = null,
                Completion_Tokens = 0,
                Prompt_Tokens = 0,
                Total_Tokens = 0
            };
        }
    }
}