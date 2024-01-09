using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content.Documents;

namespace Tesy.Commands
{
    public class TesyDocuments
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private readonly Dictionary<string, string> inputQueryParams;

        public TesyDocuments(Http httpClient, Dictionary<string, string> inputQueryParams)
        {
            this.httpClient = httpClient;
            this.inputQueryParams = inputQueryParams;
        }

        public void GetTesyDocuments()
        {
            HttpResponseMessage responseMessage = httpClient.Get(Constants.DocumentsUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();

            try
            {
                var documentsResponse = JsonSerializer.Deserialize<Dictionary<string, Documents>>(stream) ?? new();
                contentToWrite = ContentBuilder.BuildTesyDocumentsContentString(documentsResponse);
            }
            catch (JsonException jsonErr)
            {
                contentToWrite = jsonErr.Message;
            }
            fileEditor.WriteContentToHttpResponseMessagesFile(contentToWrite);
        }
    }
}