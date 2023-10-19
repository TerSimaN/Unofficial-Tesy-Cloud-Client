using Tesy.Classes;
using Tesy.Convectors;
using Tesy.Serializers;

namespace Tesy.Commands.DeviceCommands
{
    public class DeleteAllDevicePrograms
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly NoParamsPayload noParamsPayload = new();

        public DeleteAllDevicePrograms(DeviceSettings deviceSettings, Cn05uv convector)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
        }

        public void DeleteAllPrograms()
        {
            string command = "deleteAllPrograms";
            string payloadContent = noParamsPayload.SerializeParamsAsJsonPayload();
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }
    }
}