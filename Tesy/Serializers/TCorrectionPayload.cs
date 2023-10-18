using System.Text.Json;

namespace Tesy.Serializers
{
    class TCorrectionParams
    {
        public short Temp { get; set; }
    }

    public class TCorrectionPayload
    {
        /// <summary>
        /// Serializes TCorrection parameters as JSON string.
        /// </summary>
        /// <param name="temperature">TCorrection <c>temp</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(short temperature)
        {
            var @params = new TCorrectionParams
            {
                Temp = temperature
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}