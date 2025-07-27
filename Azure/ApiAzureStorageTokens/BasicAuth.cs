using System.Text;

namespace ApiAzureStorageTokens
{
    public static class BasicAuth
    {
        public static void UseBasicAuth(this WebApplication app, string username, string password)
        {
            app.Use(async (context, next) =>
            {
                string authHeader = context.Request.Headers["Authorization"];

                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
                    var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
                    var credentials = decodedCredentials.Split(':');

                    if (credentials.Length == 2 &&
                        credentials[0] == username &&
                        credentials[1] == password)
                    {
                        await next.Invoke();
                        return;
                    }
                }

                context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"MinimalApi\"";
                context.Response.StatusCode = 401; // Unauthorized
            });
        }
    }
}
