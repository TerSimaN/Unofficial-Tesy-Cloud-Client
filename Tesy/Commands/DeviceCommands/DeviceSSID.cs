using Tesy.Classes;
using Tesy.Convectors;
using Tesy.Serializers;

namespace Tesy.Commands.DeviceCommands
{
    public class DeviceSSID
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly NoParamsPayload noParamsPayload = new();

        public DeviceSSID(DeviceSettings deviceSettings, Cn05uv convector)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
        }

        public void GetSSID()
        {
            string command = "getSSID";
            string payloadContent = noParamsPayload.SerializeParamsAsJsonPayload();
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }
    }
}