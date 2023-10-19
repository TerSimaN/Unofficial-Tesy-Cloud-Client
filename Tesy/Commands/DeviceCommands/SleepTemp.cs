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

            int newSleepModeTimeValue = ReadSleepModeTimeInMinutesFromConsole();
            int oldSleepModeTimeValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldSleepModeTimeValue = deviceParam.Value.State.SleepMode.Time;
            }
            int timeValue = newSleepModeTimeValue != 0 ? newSleepModeTimeValue : oldSleepModeTimeValue;

            string payloadContent = SerializeParamsAsJsonPayload(timeValue);
            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
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

            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }

        /// <summary>
        /// Reads SleepMode <c>newTime</c> value from the Console.
        /// </summary>
        /// <returns>The read <c>timeInMinutes</c>.</returns>
        private int ReadSleepModeTimeInMinutesFromConsole()
        {
            int timeInMinutes;
            do
            {
                int hours = 0;
                do
                {
                    Console.Write("Enter SleepMode hours [0, 23]: ");
                    var inputValue = Console.ReadLine();

                    if ((inputValue != null) && (inputValue != ""))
                    {
                        hours = int.Parse(inputValue) * 60;
                    }
                } while ((hours < 0) || (hours > 1380));

                int minutes = 0;
                do
                {
                    Console.Write("Enter SleepMode minutes [0, 59]: ");
                    var inputValue = Console.ReadLine();

                    if ((inputValue != null) && (inputValue != ""))
                    {
                        minutes = int.Parse(inputValue);
                    }
                } while ((minutes < 0) || (minutes > 59));

                timeInMinutes = hours + minutes;

            } while ((timeInMinutes < 0) || (timeInMinutes > 1439));

            return timeInMinutes;
        }
    }
}