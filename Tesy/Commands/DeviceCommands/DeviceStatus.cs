using Tesy.Classes;
using Tesy.Convectors;
using Tesy.Serializers;

namespace Tesy.Commands.DeviceCommands
{
    public class DeviceStatus
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly NoParamsPayload noParamsPayload = new();

        public DeviceStatus(DeviceSettings deviceSettings, Cn05uv convector)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
        }

        public void GetStatus()
        {
            string command = "getStatus";
            string payloadContent = noParamsPayload.SerializeParamsAsJsonPayload();
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
    }
}