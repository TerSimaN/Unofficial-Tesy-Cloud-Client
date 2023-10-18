using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class OpenedWindowParams
    {
        public string? Status { get; set; }
    }

    public class OpenedWindow
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public OpenedWindow(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void TurnOpenedWindowOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setOpenedWindow";
            string openedWindowValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                openedWindowValue = ((deviceParam.Value.State.OpenedWindow != null) && (deviceParam.Value.State.OpenedWindow == "on")) ? "off" : "on";
            }
            string payloadContent = SerializeParamsAsJsonPayload(openedWindowValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes OpenedWindow parameters as JSON string.
        /// </summary>
        /// <param name="openedWindow">OpenedWindow <c>openedWindow</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(string openedWindow)
        {
            var @params = new OpenedWindowParams
            {
                Status = openedWindow
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}