using System.Text.Json;

namespace Tesy.Serializers
{
    class AntiFrostParams
    {
        public string? Status { get; set; }
    }

    public class AntiFrostPayload
    {
        /// <summary>
        /// Serializes AntiFrost parameters as JSON string.
        /// </summary>
        /// <param name="antiFrost">AntiFrost <c>antiFrost</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string antiFrost)
        {
            var @params = new AntiFrostParams
            {
                Status = antiFrost
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}