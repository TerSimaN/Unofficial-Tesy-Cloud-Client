using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;
using Tesy.Content.MyDevices;

namespace Tesy.Commands
{
    public class MyDevices
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private readonly Dictionary<string, string> inputQueryParams;

        public MyDevices(Http httpClient, Dictionary<string, string> inputQueryParams)
        {
            this.httpClient = httpClient;
            this.inputQueryParams = inputQueryParams;
        }

        public async Task<Dictionary<string, MyDevicesContent>> GetMyDevices()
        {
            HttpResponseMessage responseMessage = httpClient.Get(Constants.MyDevicesUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
                fileEditor.WriteToFile(Constants.PathToHttpResponseMessagesFile, contentToWrite);
            }
            else
            {
                var myDevicesContentResponse = JsonSerializer.Deserialize<Dictionary<string, MyDevicesContent>>(stream) ?? new();
                foreach (var deviceParam in myDevicesContentResponse)
                {
                    var deviceTimeContentResponse = JsonSerializer.Deserialize<DeviceTime>(deviceParam.Value.Time) ?? new("Date not found", "Time not found");
                    contentToWrite = ContentBuilder.BuildMyDevicesContentString(myDevicesContentResponse, deviceTimeContentResponse);
                }
                fileEditor.WriteToFile(Constants.PathToHttpResponseMessagesFile, contentToWrite);

                return myDevicesContentResponse;
            }

            return new();
        }

        public async Task<DeviceTime> GetDeviceTime()
        {
            DeviceTime deviceTime = new("", "");
            var myDevicesContent = await GetMyDevices();
            foreach (var deviceParam in myDevicesContent)
            {
                deviceTime = JsonSerializer.Deserialize<DeviceTime>(deviceParam.Value.Time) ?? new("Date not found", "Time not found");
            }

            return deviceTime;
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