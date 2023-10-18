using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class DeviceTempParams
    {
        public short Temp { get; set; }
    }

    public class DeviceTemp
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public DeviceTemp(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetDeviceTemp()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setTemp";

            short newDeviceTempValue = Input.ReadTemperatureFromConsole();
            short oldDeviceTempValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldDeviceTempValue = deviceParam.Value.State.Temp != null ? short.Parse($"{deviceParam.Value.State.Temp}") : (short)10;
            }
            short temperatureValue = newDeviceTempValue != 0 ? newDeviceTempValue : oldDeviceTempValue;

            string payloadContent = SerializeParamsAsJsonPayload(temperatureValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes DeviceTemp parameters as JSON string.
        /// </summary>
        /// <param name="temperature">DeviceTemp <c>temperature</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(short temperature)
        {
            var @params = new DeviceTempParams
            {
                Temp = temperature
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}