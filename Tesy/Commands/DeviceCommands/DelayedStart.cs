using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class DelayedStartParams
    {
        public int Time { get; set; }
        public short Temp { get; set; }
    }

    public class DelayedStart
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public DelayedStart(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetDelayedStart()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setDelayedStart";

            int newDelayedStartTimeValue = ReadDelayedStartTimeInMinutesFromConsole();
            short newDelayedStartTempValue = ReadTemperatureFromConsole();
            int oldDelayedStartTimeValue = 0;
            short oldDelayedStartTemperatureValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldDelayedStartTimeValue = deviceParam.Value.State.DelayedStart.Time;
                oldDelayedStartTemperatureValue = deviceParam.Value.State.DelayedStart.Temp;
            }
            int timeValue = newDelayedStartTimeValue >= 0 ? newDelayedStartTimeValue : oldDelayedStartTimeValue;
            short temperatureValue = newDelayedStartTempValue != 0 ? newDelayedStartTempValue : oldDelayedStartTemperatureValue;

            string payloadContent = SerializeParamsAsJsonPayload(timeValue, temperatureValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes DelayedStart parameters as JSON string.
        /// </summary>
        /// <param name="time">DelayedStart <c>time</c> parameter to serialize.</param>
        /// <param name="temperature">DelayedStart <c>temp</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(int time, short temperature)
        {
            var @params = new DelayedStartParams
            {
                Time = time,
                Temp = temperature
            };

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }

        private int ReadDelayedStartTimeInMinutesFromConsole()
        {
            int hoursInMinutes = 0;
            do
            {
                Console.Write("Enter DelayedStart hours [0, 96] (if \"0\" is entered, uses default settings): ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    hoursInMinutes = int.Parse(inputValue) * 60;
                }
            } while ((hoursInMinutes < 0) || (hoursInMinutes > 5760));

            return hoursInMinutes;
        }

        private short ReadTemperatureFromConsole()
        {
            short temperature = 0;
            do
            {
                Console.Write("Enter temperature [10, 30]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    temperature = short.Parse(inputValue);
                }
            } while ((temperature < 10) || (temperature > 30));

            return temperature;
        }
    }
}