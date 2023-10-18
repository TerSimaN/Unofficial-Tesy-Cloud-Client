using System.Text.Json;

namespace Tesy.Serializers
{
    class UVParams
    {
        public string? Status { get; set; }
    }

    public class UVPayload
    {
        /// <summary>
        /// Serializes UV parameters as JSON string.
        /// </summary>
        /// <param name="uv">UV <c>uv</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string uv)
        {
            var @params = new UVParams
            {
                Status = uv
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}