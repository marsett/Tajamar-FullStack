using Amazon.S3;
using Amazon.S3.Model;
using System.Net;

namespace MvcNetCoreAWSS3.Services
{
    public class ServiceStorageS3
    {
        // Vamos a recibir el nombre del bucket
        // a partir del appsettings.json
        private string BucketName;
        // La clase-interface para trabajar con los
        // buckets se llama IAmazonS3 y vamos a recibirla mediante
        // inyección
        private IAmazonS3 ClientS3;
        public ServiceStorageS3(IConfiguration configuration, IAmazonS3 clientS3)
        {
            this.BucketName = configuration.GetValue<string>("AWS:BucketName");
            this.ClientS3 = clientS3;
        }
        // Comenzamos creando un método para subir ficheros
        public async Task<bool> UploadFileAsync(string fileName, Stream stream)
        {
            PutObjectRequest request = new PutObjectRequest
            {
                Key = fileName,
                BucketName = this.BucketName,
                InputStream = stream
            };
            // Para trabajar se utiliza la clase IAmazonS3
            // con una petición de PutObject
            PutObjectResponse response = await this.ClientS3.PutObjectAsync(request);
            if(response.HttpStatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            DeleteObjectResponse response = await this.ClientS3.DeleteObjectAsync(this.BucketName, fileName);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Método para recuperar los ficheros del bucket aunque no
        // tengamos versiones, debemos indicar las versiones
        // en el recorrido de los ficheros
        public async Task<List<string>> GetVersionsFileAsync()
        {
            ListVersionsResponse response = await this.ClientS3.ListVersionsAsync(this.BucketName);
            // Extraemos todas las keys de nuestros ficheros, es decir,
            // el nombre de todos los ficheros. Por defecto nos devuelve
            // la última versión
            List<string> fileNames = response.Versions.Select(x => x.Key).ToList();
            return fileNames;
        }

        // Método para recuperar un fichero si no fuera
        // público nuestro bucket
        public async Task<Stream> GetPrivateFileAsync(string fileName)
        {
            GetObjectResponse response = await this.ClientS3.GetObjectAsync(this.BucketName, fileName);
            return response.ResponseStream;
        }
    }
}
