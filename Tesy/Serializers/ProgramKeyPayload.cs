using System.Text.Json;

namespace Tesy.Serializers
{
    class ProgramNumberParams
    {
        public string? Program_number { get; set; }
    }

    public class ProgramKeyPayload
    {
        /// <summary>
        /// Serializes Delete Week Program <c>program_number</c> parameter as JSON string.
        /// </summary>
        /// <param name="programKey">Delete Week Program <c>program_number</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string programKey)
        {
            var @params = new ProgramNumberParams
            {
                Program_number = programKey
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}