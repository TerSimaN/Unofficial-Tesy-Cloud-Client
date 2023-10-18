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

            short newTCorrectionTemperatureValue = Input.ReadTCorrectionTemperatureFromConsole();
            short oldTCorrectionTemperatureValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldTCorrectionTemperatureValue = deviceParam.Value.State.TCorrection;
            }
            short temperatureValue = ((newTCorrectionTemperatureValue > -4) || (newTCorrectionTemperatureValue < 4)) ? newTCorrectionTemperatureValue : oldTCorrectionTemperatureValue;

            string payloadContent = SerializeParamsAsJsonPayload(temperatureValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
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

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}