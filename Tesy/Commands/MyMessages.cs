using System.Text.Json;
using Tesy.Classes;
using Tesy.Content;

namespace Tesy.Commands
{
    public class MyMessages
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly FileEditor fileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public MyMessages(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public async void GetMyMessages()
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.MyMessagesUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else
            {
                contentToWrite = $"MyMessagesResponse: {responseMessageContent}\n\n";
            }
            fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}