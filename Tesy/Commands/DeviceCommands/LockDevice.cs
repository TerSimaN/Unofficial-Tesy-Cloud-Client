using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class LockedDeviceParams
    {
        public string? Status { get; set; }
    }

    public class LockDevice
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public LockDevice(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void TurnLockDeviceOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setLockDevice";
            string lockedDeviceValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                lockedDeviceValue = ((deviceParam.Value.State.LockedDevice != null) && (deviceParam.Value.State.LockedDevice == "on")) ? "off" : "on";
            }
            string payloadContent = SerializeParamsAsJsonPayload(lockedDeviceValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }

        /// <summary>
        /// Serializes LockedDevice parameters as JSON string.
        /// </summary>
        /// <param name="lockedDevice">LockedDevice <c>lockedDevice</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(string lockedDevice)
        {
            var @params = new LockedDeviceParams
            {
                Status = lockedDevice
            };

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}