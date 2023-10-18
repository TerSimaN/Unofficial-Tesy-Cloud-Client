using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class EcoTempParams
    {
        public short Temp { get; set; }
        public int Time { get; set; }
    }

    public class EcoTemp
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public EcoTemp(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetEcoTemp()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setEcoTemp";

            short newEcoTempTemperatureValue = Input.ReadTemperatureFromConsole();
            int newEcoTempTimeValue = Input.ReadEcoTempTimeInMinutesFromConsole();
            short oldEcoTempTemperatureValue = 0;
            int oldEcoTempTimeValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldEcoTempTemperatureValue = deviceParam.Value.State.EcoTemp.Temp;
                oldEcoTempTimeValue = deviceParam.Value.State.EcoTemp.Time;
            }
            short temperatureValue = newEcoTempTemperatureValue != 0 ? newEcoTempTemperatureValue : oldEcoTempTemperatureValue;
            int timeValue = newEcoTempTimeValue != 0 ? newEcoTempTimeValue : oldEcoTempTimeValue;
            
            string payloadContent = SerializeParamsAsJsonPayload(temperatureValue, timeValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes EcoTemp parameters as JSON string.
        /// </summary>
        /// <param name="temperature">EcoTemp <c>temp</c> parameter to serialize.</param>
        /// <param name="time">EcoTemp <c>time</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(short temperature, int time)
        {
            var @params = new EcoTempParams
            {
                Temp = temperature,
                Time = time
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}