using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class AntiFrostParams
    {
        public string? Status { get; set; }
    }

    public class AntiFrost
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public AntiFrost(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void TurnAntiFrostOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setAntiFrost";
            string antiFrostValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                antiFrostValue = ((deviceParam.Value.State.AntiFrost != null) && (deviceParam.Value.State.AntiFrost == "on")) ? "off" : "on";
            }
            string payloadContent = SerializeParamsAsJsonPayload(antiFrostValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes AntiFrost parameters as JSON string.
        /// </summary>
        /// <param name="antiFrost">AntiFrost <c>antiFrost</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(string antiFrost)
        {
            var @params = new AntiFrostParams
            {
                Status = antiFrost
            };

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}