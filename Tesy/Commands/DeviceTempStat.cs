namespace Tesy.Commands
{
    public class DeviceTempStat
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly StreamDeserializer deserializer = new();
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public DeviceTempStat(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public async void GetDeviceTempStat(Dictionary<string, MyDevicesContent> myDevicesContent)
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

            HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.DeviceTempStatUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else
            {
                var deviceTempStatContentResponse = deserializer.GetDeviceTempStatContent(stream);
                contentToWrite = ContentBuilder.BuildDeviceTempStatContentString(deviceTempStatContentResponse);
            }
            tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}