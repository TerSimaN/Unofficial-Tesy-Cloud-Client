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

            int newDelayedStartTimeValue = Input.ReadDelayedStartTimeInMinutesFromConsole();
            short newDelayedStartTempValue = Input.ReadTemperatureFromConsole();
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
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
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

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}