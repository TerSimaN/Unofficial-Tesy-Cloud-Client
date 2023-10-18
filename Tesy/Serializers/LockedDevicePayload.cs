using System.Text.Json;

namespace Tesy.Serializers
{
    class LockedDeviceParams
    {
        public string? Status { get; set; }
    }

    public class LockedDevicePayload
    {
        /// <summary>
        /// Serializes LockedDevice parameters as JSON string.
        /// </summary>
        /// <param name="lockedDevice">LockedDevice <c>lockedDevice</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string lockedDevice)
        {
            var @params = new LockedDeviceParams
            {
                Status = lockedDevice
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}