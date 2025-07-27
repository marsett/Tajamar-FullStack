using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using ExamenApiAzureMario.Models;

namespace ExamenApiAzureMario.Services
{
    public class ServiceBlobs
    {
        private BlobServiceClient client;

        public ServiceBlobs(BlobServiceClient client)
        {
            this.client = client;
        }

        public string GetBlobUrl(string containerName, string blobName)
        {
            BlobContainerClient container = this.client.GetBlobContainerClient(containerName);
            BlobClient blob = container.GetBlobClient(blobName);
            return blob.Uri.AbsoluteUri;
        }
    }
}
