using System.Text.Json;

namespace Tesy.Commands
{
    public class DevicePowerStat
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public DevicePowerStat(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public async void GetDevicePowerStat(Dictionary<string, MyDevicesContent> myDevicesContent)
        {
            string activity = Input.ReadActivityFromConsole();

            foreach (var deviceParam in myDevicesContent)
            {
                inputQueryParams.TryAdd("model", $"{deviceParam.Value.Model_Id}");
                inputQueryParams.TryAdd("timezone", deviceParam.Value.Timezone);
                inputQueryParams.TryAdd("mac", deviceParam.Value.State.Mac);
            }

            if (!inputQueryParams.ContainsKey("activity"))
            {
                inputQueryParams.TryAdd("activity", activity);
            }
            else
            {
                inputQueryParams["activity"] = activity;
            }

            HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.DevicePowerStatUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else
            {
                var devicePowerStatContentResponse = JsonSerializer.Deserialize<DevicePowerStatContent[]>(stream) ?? new DevicePowerStatContent[] {};
                contentToWrite = ContentBuilder.BuildDevicePowerStatContentString(devicePowerStatContentResponse);
            }
            tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}