using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaAzureFoundry.Helpers
{
    using Amazon.SecretsManager.Model;
    using Amazon.SecretsManager;
    using Amazon;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace AWSConsoleSecretsManager.Helpers
    {
        public class HelperSecretManager
        {
            public static async Task<string> GetSecretAsync()
            {
                string secretName = "secretosopenai";
                string region = "us-east-1";

                IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

                GetSecretValueRequest request = new GetSecretValueRequest
                {
                    SecretId = secretName,
                    VersionStage = "AWSCURRENT",
                };

                GetSecretValueResponse response;
                response = await client.GetSecretValueAsync(request);
                string secret = response.SecretString;
                return secret;
            }
        }
    }

}
