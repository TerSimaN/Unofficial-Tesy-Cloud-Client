using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;

namespace Tesy.Commands
{
    public class TestDevices
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public TestDevices(Http httpClient)
        {
            this.httpClient = httpClient;
        }

        public async void GetTestDevices()
        {
            HttpResponseMessage responseMessage = httpClient.Get(TesyConstants.TestDevicesUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else
            {
                contentToWrite = $"TestDevicesResponse: {responseMessageContent}\n\n";
            }
            fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}