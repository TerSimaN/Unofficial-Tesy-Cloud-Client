using System.Text.Json;
using Tesy.Classes;
using Tesy.Content;

namespace Tesy.Commands
{
    public class MyGroups
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly FileEditor fileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public MyGroups(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public async void GetMyGroups()
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.MyGroupsUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else
            {
                contentToWrite = $"MyGroupsResponse: {responseMessageContent}\n\n";
            }
            fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}