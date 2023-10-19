using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class ComfortTempParams
    {
        public short Temp { get; set; }
    }

    public class ComfortTemp
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public ComfortTemp(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetComfortTemp()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setComfortTemp";

            short newComfortTempTemperatureValue = ReadTemperatureFromConsole();
            short oldComfortTempTemperatureValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldComfortTempTemperatureValue = deviceParam.Value.State.ComfortTemp.Temp;
            }
            short temperatureValue = newComfortTempTemperatureValue != 0 ? newComfortTempTemperatureValue : oldComfortTempTemperatureValue;

            string payloadContent = SerializeParamsAsJsonPayload(temperatureValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes ComfortTemp parameters as JSON string.
        /// </summary>
        /// <param name="temperature">ComfortTemp <c>temp</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(short temperature)
        {
            var @params = new ComfortTempParams
            {
                Temp = temperature
            };

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }

        /// <summary>
        /// Reads <c>newTemperature</c> value from the Console.
        /// </summary>
        /// <returns>The read <c>temperature</c>.</returns>
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