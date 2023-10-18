using System.Text.Json;

namespace Tesy.Serializers
{
    class ComfortTempParams
    {
        public short Temp { get; set; }
    }

    public class ComfortTempPayload
    {
        /// <summary>
        /// Serializes ComfortTemp parameters as JSON string.
        /// </summary>
        /// <param name="temperature">ComfortTemp <c>temp</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(short temperature)
        {
            var @params = new ComfortTempParams
            {
                Temp = temperature
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}