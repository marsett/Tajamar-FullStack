using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using AwsChatGptPruebaExamenLambda.Helpers;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsChatGptPruebaExamenLambda
{
    public class Function
    {
        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            try
            {
                context.Logger.LogInformation("Procesando request de ChatGPT");

                // Agregar logs de diagnóstico
                context.Logger.LogInformation($"Request method: {request?.HttpMethod}");
                context.Logger.LogInformation($"Request body: {request?.Body}");
                context.Logger.LogInformation($"Request headers: {JsonConvert.SerializeObject(request?.Headers)}");

                // Verificar que el request no sea nulo
                if (request == null)
                {
                    context.Logger.LogError("Request es nulo");
                    return CreateResponse(400, new { error = "Request es nulo" });
                }

                // Verificar que el body no sea nulo o vacío
                if (string.IsNullOrEmpty(request.Body))
                {
                    context.Logger.LogError("Request body es nulo o vacío");
                    return CreateResponse(400, new { error = "Request body es requerido" });
                }

                // Parsear el input del body con manejo de errores
                ChatGPTRequest requestBody;
                try
                {
                    requestBody = JsonConvert.DeserializeObject<ChatGPTRequest>(request.Body);
                }
                catch (Exception ex)
                {
                    context.Logger.LogError($"Error parseando JSON: {ex.Message}");
                    return CreateResponse(400, new { error = "JSON inválido en el body" });
                }

                if (requestBody == null || string.IsNullOrEmpty(requestBody.Prompt))
                {
                    context.Logger.LogError("Prompt es nulo o vacío");
                    return CreateResponse(400, new { error = "Prompt es requerido" });
                }

                context.Logger.LogInformation($"Prompt recibido: {requestBody.Prompt}");

                // Obtener la API key usando tu helper con manejo de errores
                string secretJson;
                try
                {
                    secretJson = await HelperSecretManager.GetSecretAsync();
                    context.Logger.LogInformation("Secret obtenido correctamente");
                }
                catch (Exception ex)
                {
                    context.Logger.LogError($"Error obteniendo secret: {ex.Message}");
                    return CreateResponse(500, new { error = $"Error obteniendo API key: {ex.Message}" });
                }

                if (string.IsNullOrEmpty(secretJson))
                {
                    context.Logger.LogError("Secret JSON es nulo o vacío");
                    return CreateResponse(500, new { error = "No se pudo obtener el secret" });
                }

                Dictionary<string, string> secretDict;
                try
                {
                    secretDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(secretJson);
                }
                catch (Exception ex)
                {
                    context.Logger.LogError($"Error parseando secret JSON: {ex.Message}");
                    return CreateResponse(500, new { error = "Error parseando configuración de secrets" });
                }

                if (secretDict == null || !secretDict.ContainsKey("AWS_Key"))
                {
                    context.Logger.LogError("Secret no contiene AWS_Key");
                    return CreateResponse(500, new { error = "Configuración de API key incorrecta" });
                }

                var apiKey = secretDict["AWS_Key"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    context.Logger.LogError("API Key es nula o vacía");
                    return CreateResponse(500, new { error = "API Key no configurada correctamente" });
                }

                context.Logger.LogInformation("API Key obtenida correctamente");

                // Llamar a OpenAI
                var response = await CallOpenAI(requestBody.Prompt, apiKey, context);

                return CreateResponse(200, new { response = response });
            }
            catch (Exception ex)
            {
                context.Logger.LogError($"Error general: {ex.Message}");
                context.Logger.LogError($"Stack trace: {ex.StackTrace}");
                return CreateResponse(500, new { error = $"Error interno: {ex.Message}" });
            }
        }

        private async Task<string> CallOpenAI(string prompt, string apiKey, ILambdaContext context)
        {
            try
            {
                context.Logger.LogInformation("Iniciando llamada a OpenAI");

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "user", content = prompt }
                    },
                    max_tokens = 256,
                    temperature = 0.7
                };

                var json = JsonConvert.SerializeObject(requestBody);
                context.Logger.LogInformation($"Request a OpenAI: {json}");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

                context.Logger.LogInformation($"Status code de OpenAI: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    context.Logger.LogError($"OpenAI API Error: {response.StatusCode} - {errorContent}");
                    throw new Exception($"OpenAI API error: {response.StatusCode} - {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                context.Logger.LogInformation($"Response de OpenAI: {responseContent}");

                var openAIResponse = JsonConvert.DeserializeObject<OpenAIResponse>(responseContent);

                if (openAIResponse?.Choices == null || openAIResponse.Choices.Length == 0)
                {
                    throw new Exception("Respuesta de OpenAI no contiene choices");
                }

                return openAIResponse.Choices[0].Message.Content;
            }
            catch (Exception ex)
            {
                context.Logger.LogError($"Error en CallOpenAI: {ex.Message}");
                throw new Exception($"Error llamando OpenAI: {ex.Message}");
            }
        }

        private APIGatewayProxyResponse CreateResponse(int statusCode, object body)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = statusCode,
                Body = JsonConvert.SerializeObject(body),
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" },
                    { "Access-Control-Allow-Origin", "*" },
                    { "Access-Control-Allow-Headers", "Content-Type,X-Amz-Date,Authorization,X-Api-Key,X-Amz-Security-Token" },
                    { "Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT" }
                }
            };
        }
    }

    public class ChatGPTRequest
    {
        public string Prompt { get; set; }
    }

    public class OpenAIResponse
    {
        public Choice[] Choices { get; set; }
    }

    public class Choice
    {
        public Message Message { get; set; }
    }

    public class Message
    {
        public string Content { get; set; }
    }
}