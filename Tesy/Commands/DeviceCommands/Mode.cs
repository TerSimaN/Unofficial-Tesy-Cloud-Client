using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class ModeParams
    {
        public string? Name { get; set; }
    }
    
    public class Mode
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public Mode(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetMode()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setMode";

            string newModeNameValue = ReadModeNameFromConsole();
            string oldModeNameValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                oldModeNameValue = deviceParam.Value.State.Mode;
            }
            string nameValue = newModeNameValue != "" ? newModeNameValue : oldModeNameValue;

            string payloadContent = SerializeParamsAsJsonPayload(nameValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes Mode parameters as JSON string.
        /// </summary>
        /// <param name="name">Mode <c>name</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(string name)
        {
            var @params = new ModeParams
            {
                Name = name
            };

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }

        /// <summary>
        /// Reads Mode <c>name</c> value from the Console.
        /// </summary>
        /// <returns>The read <c>modeName</c>.</returns>
        private string ReadModeNameFromConsole()
        {
            string modeName = "";
            string[] modes = {"off", "heating", "comfort", "eco", "sleep", "delay start", "program"};
            do
            {
                Console.Write("Enter mode name [off, heating, comfort, eco, sleep, delay start, program]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && modes.Contains(inputValue))
                {
                    modeName = inputValue.Trim();
                }
            } while (modeName.Length < 1);

            return modeName;
        }
    }
}