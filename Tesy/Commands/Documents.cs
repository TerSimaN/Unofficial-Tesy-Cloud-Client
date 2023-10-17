using System.Text.Json;

namespace Tesy.Commands
{
    public class TesyDocuments
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public TesyDocuments(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public void GetTesyDocuments()
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.DocumentsUrl, inputQueryParams);
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
            tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}