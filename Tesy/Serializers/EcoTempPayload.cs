using System.Text.Json;

namespace Tesy.Serializers
{
    class EcoTempParams
    {
        public short Temp { get; set; }
        public int Time { get; set; }
    }

    public class EcoTempPayload
    {
        /// <summary>
        /// Serializes EcoTemp parameters as JSON string.
        /// </summary>
        /// <param name="temperature">EcoTemp <c>temp</c> parameter to serialize.</param>
        /// <param name="time">EcoTemp <c>time</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(short temperature, int time)
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
    }
}