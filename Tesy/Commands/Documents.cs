using System.Text.Json;

namespace Tesy.Commands
{
    public class Documents
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly StreamDeserializer deserializer = new();
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public Documents(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public void GetDocuments()
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.DocumentsUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();

            try
            {
                var documentsResponse = deserializer.GetTesyDocumentsContent(stream);
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