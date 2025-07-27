using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace MvcCoreAzureStorage.Services
{
    public class ServiceStorageFiles
    {
        // Todo servicio storage siempre utiliza clients para trabajar
        // Un client puede ser directamente sobre un shared o podría ser
        // sobre todo el servicio de files
        private ShareDirectoryClient root;
        public ServiceStorageFiles(IConfiguration configuration)
        {
            string keys = configuration.GetValue<string>("AzureKeys:StorageAccount");
            // Nuestro cliente trabajará sobre un shared determinado
            ShareClient client = new ShareClient(keys, "ejemplofiles");
            this.root = client.GetRootDirectoryClient();
        }

        // Método para recuperar todos los ficheros de la raíz
        // de shared
        public async Task<List<string>> GetFilesAsync()
        {
            List<string> files = new List<string>();
            await foreach (ShareFileItem item in this.root.GetFilesAndDirectoriesAsync())
            {
                files.Add(item.Name);
            }
            return files;
        }

        public async Task<string> ReadFileAsync(string fileName)
        {
            ShareFileClient fileClient = this.root.GetFileClient(fileName);
            ShareFileDownloadInfo data = await fileClient.DownloadAsync();
            Stream stream = data.Content;
            string contenido = "";
            using(StreamReader reader = new StreamReader(stream))
            {
                contenido = await reader.ReadToEndAsync();
            }
            return contenido;
        }

        public async Task UploadFileAsync(string fileName, Stream stream)
        {
            ShareFileClient fileClient = this.root.GetFileClient(fileName);
            await fileClient.CreateAsync(stream.Length);
            await fileClient.UploadAsync(stream);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            ShareFileClient fileClient = this.root.GetFileClient(fileName);
            await fileClient.DeleteAsync();
        }
    }
}
