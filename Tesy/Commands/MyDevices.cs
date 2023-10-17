using System.Text.Json;
using Tesy.Classes;

namespace Tesy.Commands
{
    public class MyDevices
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly FileEditor fileEditor = new();
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
                fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
            }
            else
            {
                var myDevicesContentResponse = JsonSerializer.Deserialize<Dictionary<string, MyDevicesContent>>(stream) ?? new();
                foreach (var deviceParam in myDevicesContentResponse)
                {
                    var deviceTimeContentResponse = JsonSerializer.Deserialize<DeviceTime>(deviceParam.Value.Time) ?? new("Date not found", "Time not found");
                    contentToWrite = ContentBuilder.BuildMyDevicesContentString(myDevicesContentResponse, deviceTimeContentResponse);
                }
                fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);

                return myDevicesContentResponse;
            }

            return new();
        }

        public async Task<Dictionary<string, DeviceProgram>> GetDevicePrograms()
        {
            Dictionary<string, DeviceProgram> deviceProgramsDictionary = new();
            var myDevicesContent = await GetMyDevices();
            foreach (var deviceParam in myDevicesContent)
            {
                deviceProgramsDictionary = deviceParam.Value.State.DeviceProgram;
            }

            return deviceProgramsDictionary;
        }
    }
}