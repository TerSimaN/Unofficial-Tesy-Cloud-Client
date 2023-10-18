using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class SleepModeParams
    {
        public int Time { get; set; }
    }

    public class SleepTemp
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public SleepTemp(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetSleepMode()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setSleepTemp";

            int newSleepModeTimeValue = Input.ReadSleepModeTimeInMinutesFromConsole();
            int oldSleepModeTimeValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldSleepModeTimeValue = deviceParam.Value.State.SleepMode.Time;
            }
            int timeValue = newSleepModeTimeValue != 0 ? newSleepModeTimeValue : oldSleepModeTimeValue;

            string payloadContent = SerializeParamsAsJsonPayload(timeValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes SleepMode parameters as JSON string.
        /// </summary>
        /// <param name="time">SleepMode <c>time</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(int time)
        {
            var @params = new SleepModeParams
            {
                Time = time
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}