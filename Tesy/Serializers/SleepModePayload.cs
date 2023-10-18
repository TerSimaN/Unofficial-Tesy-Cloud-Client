using System.Text.Json;

namespace Tesy.Serializers
{
    class SleepModeParams
    {
        public int Time { get; set; }
    }

    public class SleepModePayload
    {
        /// <summary>
        /// Serializes SleepMode parameters as JSON string.
        /// </summary>
        /// <param name="time">SleepMode <c>time</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(int time)
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