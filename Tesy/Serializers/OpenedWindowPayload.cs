using System.Text.Json;

namespace Tesy.Serializers
{
    class OpenedWindowParams
    {
        public string? Status { get; set; }
    }

    public class OpenedWindowPayload
    {
        /// <summary>
        /// Serializes OpenedWindow parameters as JSON string.
        /// </summary>
        /// <param name="openedWindow">OpenedWindow <c>openedWindow</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string openedWindow)
        {
            var @params = new OpenedWindowParams
            {
                Status = openedWindow
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}