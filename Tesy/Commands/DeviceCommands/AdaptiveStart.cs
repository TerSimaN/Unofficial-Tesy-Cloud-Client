using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class AdaptiveStartParams
    {
        public string? Status { get; set; }
    }

    public class AdaptiveStart
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public AdaptiveStart(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void TurnAdaptiveStartOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setAdaptiveStart";
            string adaptiveStartValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                adaptiveStartValue = ((deviceParam.Value.State.AdaptiveStart != null) && (deviceParam.Value.State.AdaptiveStart == "on")) ? "off" : "on";
            }
            string payloadContent = SerializeParamsAsJsonPayload(adaptiveStartValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes AdaptiveStart parameters as JSON string.
        /// </summary>
        /// <param name="adaptiveStart">AdaptiveStart <c>adaptiveStart</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(string adaptiveStart)
        {
            var @params = new AdaptiveStartParams
            {
                Status = adaptiveStart
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}