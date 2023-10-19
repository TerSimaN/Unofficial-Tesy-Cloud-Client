using System.Text.Json;
using Tesy.Classes;
using Tesy.Convectors;

namespace Tesy.Commands.DeviceCommands
{
    class DeviceWifiParams
    {
        public string? WifiSSID { get; set; }
        public string? WifiPass { get; set; }
    }

    public class WifiData
    {
        private readonly DeviceSettings deviceSettings;
        private readonly Cn05uv convector;
        private readonly MyDevices myDevices;

        public WifiData(DeviceSettings deviceSettings, Cn05uv convector, MyDevices myDevices)
        {
            this.deviceSettings = deviceSettings;
            this.convector = convector;
            this.myDevices = myDevices;
        }

        public async void SetDeviceWifi()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setWifiData";

            string newDeviceWifiSSIDValue = ReadDeviceWifiSSIDFromConsole();
            string newDeviceWifiPassValue = ReadDeviceWifiPassFromConsole();
            string oldDeviceWifiSSIDValue = "";
            string oldDeviceWifiPassValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                oldDeviceWifiSSIDValue = deviceParam.Value.Wifi_SSID;
                oldDeviceWifiPassValue = deviceParam.Value.Wifi_Pass;
            }
            string wifiSSID = newDeviceWifiSSIDValue != "" ? newDeviceWifiSSIDValue : oldDeviceWifiSSIDValue;
            string wifiPass = newDeviceWifiPassValue != "" ? newDeviceWifiPassValue : oldDeviceWifiPassValue;

            string payloadContent = SerializeParamsAsJsonPayload(wifiSSID, wifiPass);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        
        /// <summary>
        /// Serializes DeviceWifi parameters as JSON string.
        /// </summary>
        /// <param name="wifi_ssid">DeviceWifi <c>wifiSSID</c> parameter to serialize.</param>
        /// <param name="wifi_pass">DeviceWifi <c>wifiPass</c> parameters to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        private string SerializeParamsAsJsonPayload(string wifi_ssid, string wifi_pass)
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

        private string ReadDeviceWifiSSIDFromConsole()
        {
            string selectedWifiSSID = "";
            do
            {
                Console.Write("Entet Wifi Network Name: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    selectedWifiSSID = inputValue.Trim();
                }
            } while (selectedWifiSSID.Length < 1);

            return selectedWifiSSID;
        }

        private string ReadDeviceWifiPassFromConsole()
        {
            string selectedWifiPass = "";
            do
            {
                Console.Write("Enter Wifi Network Password: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    selectedWifiPass = inputValue.Trim();
                }
            } while (selectedWifiPass.Length < 1);

            return selectedWifiPass;
        }
    }
}