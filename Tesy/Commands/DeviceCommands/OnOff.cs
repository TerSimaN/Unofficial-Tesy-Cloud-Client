using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class OnOffParams
    {
        public string? Status { get; set; }
    }

    public class OnOff
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public OnOff(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void TurnOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "onOff";
            string onOffValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                onOffValue = ((deviceParam.Value.State.Status != null) && (deviceParam.Value.State.Status == "on")) ? "off" : "on";
            }
            string payloadContent = SerializeParamsAsJsonPayload(onOffValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }

        /// <summary>
        /// Serializes OnOff parameters as JSON string.
        /// </summary>
        /// <param name="onOff">onOff <c>OnOff</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(string onOff)
        {
            var @params = new OnOffParams
            {
                Status = onOff
            };

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}