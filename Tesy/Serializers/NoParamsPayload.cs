using System.Text.Json;

namespace Tesy.Serializers
{
    public class NoParamsPayload
    {
        /// <summary>
        /// Serializes empty body parameters as JSON string.
        /// </summary>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload()
        {
            var @params = new{};
            
            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}