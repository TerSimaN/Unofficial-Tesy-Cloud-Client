using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class TCorrectionParams
    {
        public short Temp { get; set; }
    }

    public class TCorrection
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public TCorrection(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetTCorrection()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setTCorrection";

            short newTCorrectionTemperatureValue = ReadTCorrectionTemperatureFromConsole();
            short oldTCorrectionTemperatureValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldTCorrectionTemperatureValue = deviceParam.Value.State.TCorrection;
            }
            short temperatureValue = ((newTCorrectionTemperatureValue > -4) || (newTCorrectionTemperatureValue < 4)) ? newTCorrectionTemperatureValue : oldTCorrectionTemperatureValue;

            string payloadContent = SerializeParamsAsJsonPayload(temperatureValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes TCorrection parameters as JSON string.
        /// </summary>
        /// <param name="temperature">TCorrection <c>temp</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(short temperature)
        {
            var @params = new TCorrectionParams
            {
                Temp = temperature
            };

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }

        /// <summary>
        /// Reads TCorrection <c>newTemperature</c> value from the Console.
        /// </summary>
        /// <returns>The read <c>temperature</c>.</returns>
        private short ReadTCorrectionTemperatureFromConsole()
        {
            short temperature = 0;
            do
            {
                Console.Write("Enter TCorrection temperature [-4, 4]: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    temperature = short.Parse(inputValue);
                }
            } while ((temperature < -4) || (temperature > 4));

            return temperature;
        }
    }
}