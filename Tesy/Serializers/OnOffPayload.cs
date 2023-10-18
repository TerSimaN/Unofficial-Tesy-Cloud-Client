using System.Text.Json;

namespace Tesy.Serializers
{
    class OnOffParams
    {
        public string? Status { get; set; }
    }

    public class OnOffPayload
    {
        /// <summary>
        /// Serializes OnOff parameters as JSON string.
        /// </summary>
        /// <param name="onOff">onOff <c>OnOff</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string onOff)
        {
            var @params = new OnOffParams
            {
                Status = onOff
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}