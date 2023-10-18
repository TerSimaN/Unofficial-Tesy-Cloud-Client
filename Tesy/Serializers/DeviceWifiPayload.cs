using System.Text.Json;

namespace Tesy.Serializers
{
    class DeviceWifiParams
    {
        public string? WifiSSID { get; set; }
        public string? WifiPass { get; set; }
    }

    public class DeviceWifiPayload
    {
        /// <summary>
        /// Serializes DeviceWifi parameters as JSON string.
        /// </summary>
        /// <param name="wifi_ssid">DeviceWifi <c>wifiSSID</c> parameter to serialize.</param>
        /// <param name="wifi_pass">DeviceWifi <c>wifiPass</c> parameters to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(string wifi_ssid, string wifi_pass)
        {
            var @params = new DeviceWifiParams
            {
                WifiSSID = wifi_ssid,
                WifiPass = wifi_pass
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}