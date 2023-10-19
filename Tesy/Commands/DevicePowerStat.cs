using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;
using Tesy.Content.MyDevices;

namespace Tesy.Commands
{
    public class DevicePowerStat
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private readonly Dictionary<string, string> inputQueryParams;

        public DevicePowerStat(Http httpClient, Dictionary<string, string> inputQueryParams)
        {
            this.httpClient = httpClient;
            this.inputQueryParams = inputQueryParams;
        }

        public async void GetDevicePowerStat(Dictionary<string, MyDevicesContent> myDevicesContent)
        {
            string activity = ReadActivityFromConsole();

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

            HttpResponseMessage responseMessage = httpClient.Get(TesyConstants.DevicePowerStatUrl, inputQueryParams);
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
            fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }

        private string ReadActivityFromConsole()
        {
            string activity = "";
            string[] activities = {"daily", "monthly", "annual"};
            do
            {
                Console.Write("Enter activity [daily, monthly, annual]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && activities.Contains(inputValue))
                {
                    activity = inputValue.Trim();
                }
            } while (activity.Length < 1);

            return activity;
        }
    }
}