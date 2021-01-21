using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Toolaku.Models.DTO;
using ToolakuV2_API.Helpers;

namespace ToolakuV2_API.Controllers
{
    [RoutePrefix("api/upload")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UploadController : ApiController
    {
        private const string Container = "mytenantimage";
        private const string ContainerDocs = "mytenantdocs";

        [HttpPost, Route("image")]
        [Authorize]
        public async Task<IHttpActionResult> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var accountName = ConfigurationManager.AppSettings["storage:account:name"];
            var accountKey = ConfigurationManager.AppSettings["storage:account:key"];
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer imagesContainer = blobClient.GetContainerReference(Container);
            var provider = new AzureStorageMultipartFormDataStreamProvider(imagesContainer);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error has occured. Details: {ex.Message}");
            }

            // Retrieve the filename of the file you have uploaded
            var filename = @"https://toolakufiles.blob.core.windows.net/mytenantimage/" + provider.FileData.FirstOrDefault()?.LocalFileName;
            if (string.IsNullOrEmpty(filename))
            {
                return BadRequest("An error has occured while uploading your file. Please try again.");
            }

            var basicResponse = new BasicApiResponse
            {
                ReturnCode = 0,                
                ResponseMessage = $"File Successfully uploaded",
            };

            basicResponse.Result = new List<Dictionary<string, string>>();

            var dictionary = new Dictionary<string, string>();
            dictionary.Add("ImageFileName", filename);
            basicResponse.Result.Add(dictionary);

            //return Ok($"File: {filename} has successfully uploaded");
            return Ok(basicResponse);
        }

        [HttpPost, Route("doc")]
        [Authorize]
        public async Task<IHttpActionResult> UploadDoc()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var accountName = ConfigurationManager.AppSettings["storage:account:name"];
            var accountKey = ConfigurationManager.AppSettings["storage:account:key"];
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer docsContainer = blobClient.GetContainerReference(ContainerDocs);
            var provider = new AzureStorageMultipartFormDocDataStreamProvider(docsContainer);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error has occured. Details: {ex.Message}");
            }

            // Retrieve the filename of the file you have uploaded
            var filename = @"https://toolakufiles.blob.core.windows.net/mytenantdocs/" + provider.FileData.FirstOrDefault()?.LocalFileName;
            if (string.IsNullOrEmpty(filename))
            {
                return BadRequest("An error has occured while uploading your file. Please try again.");
            }

            var basicResponse = new BasicApiResponse
            {
                ReturnCode = 0,
                ResponseMessage = $"Document Successfully uploaded",                
            };

            basicResponse.Result = new List<Dictionary<string, string>>();

            var dictionary = new Dictionary<string, string>();
            dictionary.Add("DocFileName", filename);
            basicResponse.Result.Add(dictionary);

            //return Ok($"File: {filename} has successfully uploaded");
            return Ok(basicResponse);
        }
    }
}
