using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;
using Tesy.Content.MyDevices;

namespace Tesy.Commands
{
    public class DeviceTempStat
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private readonly Dictionary<string, string> inputQueryParams;

        public DeviceTempStat(Http httpClient, Dictionary<string, string> inputQueryParams)
        {
            this.httpClient = httpClient;
            this.inputQueryParams = inputQueryParams;
        }

        public async void GetDeviceTempStat(Dictionary<string, MyDevicesContent> myDevicesContent)
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

            HttpResponseMessage responseMessage = httpClient.Get(Constants.DeviceTempStatUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else
            {
                var deviceTempStatContentResponse = JsonSerializer.Deserialize<DeviceTempStatContent>(stream) ?? new(new DataContent[] {}, new string[] {});
                contentToWrite = ContentBuilder.BuildDeviceTempStatContentString(deviceTempStatContentResponse);
            }
            fileEditor.WriteContentToHttpResponseMessagesFile(contentToWrite);
        }

        /// <summary>
        /// Reads DeviceTempStat <c>activity</c> value from Console.
        /// </summary>
        /// <returns>The read <c>activity</c>.</returns>
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