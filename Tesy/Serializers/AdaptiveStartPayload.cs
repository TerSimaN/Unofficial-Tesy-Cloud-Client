using System.Text.Json;

namespace Tesy.Serializers
{
    class AdaptiveStartParams
    {
        public string? Status { get; set; }
    }

    public class AdaptiveStartPayload
    {
        /// <summary>
        /// Serializes AdaptiveStart parameters as JSON string.
        /// </summary>
        /// <param name="adaptiveStart">AdaptiveStart <c>adaptiveStart</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string adaptiveStart)
        {
            var @params = new AdaptiveStartParams
            {
                Status = adaptiveStart
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}