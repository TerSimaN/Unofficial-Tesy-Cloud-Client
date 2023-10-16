namespace Tesy.Commands
{
    public class MyDevices
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly StreamDeserializer deserializer = new();
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
                var noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
                tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
            }
            else
            {
                var myDevicesContentResponse = deserializer.GetMyDevicesContent(stream);
                foreach (var deviceParam in myDevicesContentResponse)
                {
                    var deviceTimeContentResponse = deserializer.GetDeviceTimeContent(deviceParam.Value.Time);
                    contentToWrite = ContentBuilder.BuildMyDevicesContentString(myDevicesContentResponse, deviceTimeContentResponse);
                }
                tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);

                return myDevicesContentResponse;
            }

            return new();
        }
    }
}