using Tesy.Convectors;

namespace Tesy.Classes
{
    public class DeviceSettings
    {
        public DeviceSettings() { }
        
        public async void PublishMessage(Cn05uv convector, string requestType, string command, string payloadContent)
        {
            Task task;

            await TesyMqttClient.PublishMessage(
                convector.MacAddress,
                requestType,
                convector.Model,
                convector.Token,
                command,
                payloadContent
            );

            task = Task.Run(() => Thread.Sleep(1000));
            task.Wait();
        }
    }
}