using System.Text.Json;

namespace Tesy.Commands
{
    public class UpdateDeviceSettings
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> updateDeviceSettingsQueryParams = new();

        public UpdateDeviceSettings(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
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

            HttpResponseMessage responseMessage = tesyHttpClient.Post(
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
            tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}