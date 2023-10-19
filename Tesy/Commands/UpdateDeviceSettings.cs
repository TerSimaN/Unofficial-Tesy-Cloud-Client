using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;

namespace Tesy.Commands
{
    public class UpdateDeviceSettings
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private Dictionary<string, string> updateDeviceSettingsQueryParams = new();

        public UpdateDeviceSettings(Http httpClient, Dictionary<string, string> inputQueryParams)
        {
            this.httpClient = httpClient;
            updateDeviceSettingsQueryParams.TryAdd("userID", inputQueryParams["userID"]);
        }

        public async void PostUpdateDeviceSettings(Dictionary<string, string> queryParams)
        {
            foreach (var queryParam in queryParams)
            {
                if (updateDeviceSettingsQueryParams.ContainsKey(queryParam.Key))
                {
                    updateDeviceSettingsQueryParams[queryParam.Key] = queryParam.Value;
                }
                else
                {
                    updateDeviceSettingsQueryParams.TryAdd(queryParam.Key, queryParam.Value);
                }
            }

            HttpResponseMessage responseMessage = httpClient.Post(
                TesyConstants.UpdateDeviceSettingsUrl,
                updateDeviceSettingsQueryParams
            );

            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else
            {
                var updateDeviceSettingsContentResponse = JsonSerializer.Deserialize<UpdateDeviceSettingsContent>(stream) ?? new(false, "Message not found");
                contentToWrite = ContentBuilder.BuildUpdateDeviceSettingsContentString(updateDeviceSettingsContentResponse);
            }
            fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}