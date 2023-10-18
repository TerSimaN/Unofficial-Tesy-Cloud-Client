using System.Text.Json;

namespace Tesy.Serializers
{
    class ModeParams
    {
        public string? Name { get; set; }
    }
    
    public class ModePayload
    {
        /// <summary>
        /// Serializes Mode parameters as JSON string.
        /// </summary>
        /// <param name="name">Mode <c>name</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string name)
        {
            var @params = new ModeParams
            {
                Name = name
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}