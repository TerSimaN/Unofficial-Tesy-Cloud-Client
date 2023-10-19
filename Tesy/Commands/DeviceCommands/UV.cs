using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class UVParams
    {
        public string? Status { get; set; }
    }

    public class UV
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public UV(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void TurnUVOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setUV";
            string UVValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                UVValue = ((deviceParam.Value.State.UV != null) && (deviceParam.Value.State.UV == "on")) ? "off" : "on";
            }
            string payloadContent = SerializeParamsAsJsonPayload(UVValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }

        /// <summary>
        /// Serializes UV parameters as JSON string.
        /// </summary>
        /// <param name="uv">UV <c>uv</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(string uv)
        {
            var @params = new UVParams
            {
                Status = uv
            };

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}