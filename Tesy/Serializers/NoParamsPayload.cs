using System.Text.Json;
using Tesy.Classes;

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
            
            string payload = JsonSerializer.Serialize(@params, Constants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}