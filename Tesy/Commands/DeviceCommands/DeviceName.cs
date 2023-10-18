namespace Tesy.Commands.DeviceCommands
{
    public class DeviceName
    {
        private readonly MyDevices myDevices;
        private readonly UpdateDeviceSettings updateDeviceSettings;
        
        public DeviceName(MyDevices myDevices, UpdateDeviceSettings updateDeviceSettings)
        {
            this.myDevices = myDevices;
            this.updateDeviceSettings = updateDeviceSettings;
        }

        public async void SetDeviceName()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            Dictionary<string, string> queryParams;
            string macAddress = "";
            string newDeviceName = Input.ReadDeviceNameFromConsole();

            string oldDeviceName = "";
            foreach (var deviceParam in myDevicesContent)
            {
                macAddress = deviceParam.Key;
                oldDeviceName = deviceParam.Value.DeviceName;
            }

            string deviceNameValue = newDeviceName != "" ? newDeviceName : oldDeviceName;
            queryParams = new(
                new[] {
                    KeyValuePair.Create("mac", macAddress),
                    KeyValuePair.Create("deviceName", deviceNameValue)
                }
            );
            updateDeviceSettings.PostUpdateDeviceSettings(queryParams);
        }
    }
}