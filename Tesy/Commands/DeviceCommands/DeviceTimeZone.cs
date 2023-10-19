using System.Text.Json;
using Tesy.Classes;
using Tesy.Content;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class TimeZoneParams
    {
        public short Day { get; set; }
        public string? Time { get; set; }
    }

    public class DeviceTimeZone
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;
        private readonly UpdateDeviceSettings updateDeviceSettings;
        private readonly WorldClock worldClock = new();

        public DeviceTimeZone(
            DeviceSettings deviceSettings,
            Cn05uv convector,
            MyDevices myDevices,
            UpdateDeviceSettings updateDeviceSettings
        )
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
            this.updateDeviceSettings = updateDeviceSettings;
        }

        public async void SetTimeZone()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            var deviceTimeContent = await myDevices.GetDeviceTime();
            var timeZonesFileContent = worldClock.ReadTimeZonesFileContent();
            
            Dictionary<string, string> queryParams;
            string macAddress = "";
            string command = "timeResponse";
            string requestType = "timeResponse";

            string newTimeValue = "";
            short newWeekdayValue = -1;

            Output.PrintIanaTimeZoneIds(timeZonesFileContent);
            string newTimeZoneValue = ReadIanaTimeZoneIdFromConsole(timeZonesFileContent);
            if (newTimeZoneValue != "")
            {
                newTimeValue = worldClock.GetNewTimeZoneTime(newTimeZoneValue);
                newWeekdayValue = worldClock.GetNewWeekday(newTimeZoneValue);
            }
            
            string oldTimeZoneValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                macAddress = deviceParam.Key;
                oldTimeZoneValue = deviceParam.Value.Timezone;
            }
            string oldTimeValue = deviceTimeContent.Time;
            short oldWeekdayValue = worldClock.GetNewWeekday(oldTimeZoneValue);
            
            string timeValue = newTimeValue != "" ? newTimeValue : oldTimeValue;
            short weekdayValue = newWeekdayValue != -1 ? newWeekdayValue : oldWeekdayValue;

            if (newTimeZoneValue != "")
            {
                queryParams = new(
                    new[] {
                        KeyValuePair.Create("mac", macAddress),
                        KeyValuePair.Create("timezone", newTimeZoneValue)
                    }
                );
                updateDeviceSettings.PostUpdateDeviceSettings(queryParams);
            }

            string payloadContent = SerializeParamsAsJsonPayload(weekdayValue, timeValue);
            deviceSettings.PublishMessage(convector, requestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes TimeZone parameters as JSON string.
        /// </summary>
        /// <param name="day">TimeZone <c>day</c> parameter to serialize.</param>
        /// <param name="time">TimeZone <c>time</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(short day, string time)
        {
            var @params = new TimeZoneParams
            {
                Day = day,
                Time = time
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }

        private string ReadIanaTimeZoneIdFromConsole(Dictionary<string, TimeZonesFileContent> timeZonesFileContent)
        {
            string ianaId = "";
            do
            {
                Console.Write("Enter IANA ID number for new TimeZone (or leave empty for default TimeZone): ");
                var inputValue = Console.ReadLine();

                if (inputValue == "")
                {
                    break;
                }

                if ((inputValue != null) && timeZonesFileContent.ContainsKey(inputValue))
                {
                    ianaId = timeZonesFileContent[inputValue.Trim()].IanaId;
                }
            } while (ianaId.Length < 1);

            return ianaId;
        }
    }
}