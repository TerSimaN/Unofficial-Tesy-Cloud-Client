using System.Text.Json;

namespace Tesy.Serializers
{
    class DeviceTempParams
    {
        public short Temp { get; set; }
    }

    public class DeviceTempPayload
    {
        /// <summary>
        /// Serializes DeviceTemp parameters as JSON string.
        /// </summary>
        /// <param name="temperature">DeviceTemp <c>temperature</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(short temperature)
        {
            var @params = new DeviceTempParams
            {
                Temp = temperature
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}