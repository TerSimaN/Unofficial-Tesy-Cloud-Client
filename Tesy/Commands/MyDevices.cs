using System.Text.Json;

namespace Tesy.Commands
{
    public class MyDevices
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public MyDevices(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public async Task<Dictionary<string, MyDevicesContent>> GetMyDevices()
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.MyDevicesUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
                tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
            }
            else
            {
                var myDevicesContentResponse = JsonSerializer.Deserialize<Dictionary<string, MyDevicesContent>>(stream) ?? new();
                foreach (var deviceParam in myDevicesContentResponse)
                {
                    var deviceTimeContentResponse = JsonSerializer.Deserialize<DeviceTime>(deviceParam.Value.Time) ?? new("Date not found", "Time not found");
                    contentToWrite = ContentBuilder.BuildMyDevicesContentString(myDevicesContentResponse, deviceTimeContentResponse);
                }
                tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);

                return myDevicesContentResponse;
            }

            return new();
        }
    }
}