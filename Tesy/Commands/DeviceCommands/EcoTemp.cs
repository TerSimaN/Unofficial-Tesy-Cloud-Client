using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class EcoTempParams
    {
        public short Temp { get; set; }
        public int Time { get; set; }
    }

    public class EcoTemp
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public EcoTemp(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetEcoTemp()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setEcoTemp";

            short newEcoTempTemperatureValue = ReadTemperatureFromConsole();
            int newEcoTempTimeValue = ReadEcoTempTimeInMinutesFromConsole();
            short oldEcoTempTemperatureValue = 0;
            int oldEcoTempTimeValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldEcoTempTemperatureValue = deviceParam.Value.State.EcoTemp.Temp;
                oldEcoTempTimeValue = deviceParam.Value.State.EcoTemp.Time;
            }
            short temperatureValue = newEcoTempTemperatureValue != 0 ? newEcoTempTemperatureValue : oldEcoTempTemperatureValue;
            int timeValue = newEcoTempTimeValue != 0 ? newEcoTempTimeValue : oldEcoTempTimeValue;
            
            string payloadContent = SerializeParamsAsJsonPayload(temperatureValue, timeValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes EcoTemp parameters as JSON string.
        /// </summary>
        /// <param name="temperature">EcoTemp <c>temp</c> parameter to serialize.</param>
        /// <param name="time">EcoTemp <c>time</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(short temperature, int time)
        {
            var @params = new EcoTempParams
            {
                Temp = temperature,
                Time = time
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }

        private short ReadTemperatureFromConsole()
        {
            short temperature = 0;
            do
            {
                Console.Write("Enter temperature [10, 30]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    temperature = short.Parse(inputValue);
                }
            } while ((temperature < 10) || (temperature > 30));

            return temperature;
        }

        private int ReadEcoTempTimeInMinutesFromConsole()
        {
            int timeInMinutes;
            do
            {
                int hours = 0;
                do
                {
                    Console.Write("Enter EcoTemp hours [0, 23]: ");
                    var inputValue = Console.ReadLine();

                    if ((inputValue != null) && (inputValue != ""))
                    {
                        hours = int.Parse(inputValue) * 60;
                    }
                } while ((hours < 0) || (hours > 1380));

                int minutes = 0;
                do
                {
                    Console.Write("Enter EcoTemp minutes [0, 59]: ");
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