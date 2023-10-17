using Tesy.Commands;
using Tesy.Convectors;

namespace Tesy.Classes
{
    public class DeviceCommands
    {
        private readonly MyDevices myDevices;
        private readonly UpdateDeviceSettings updateDeviceSettings;
        private readonly TesyHttpClass tesyHttpClass;
        private readonly Cn05uv convector;
        private readonly DeviceSettings deviceSettings;
        private readonly WorldClock worldClock = new();
        private readonly PayloadSerializer payloadSerializer = new();
        private readonly Dictionary<string, TimeZonesFileContent> timeZonesFileContent;
        private Dictionary<string, string> queryParams = new();
        private DeviceTime deviceTimeContent;

        public DeviceCommands(MyDevices myDevices, UpdateDeviceSettings updateDeviceSettings, TesyHttpClass tesyHttpClass, Cn05uv convector, DeviceSettings deviceSettings)
        {
            this.myDevices = myDevices;
            this.updateDeviceSettings = updateDeviceSettings;
            this.tesyHttpClass = tesyHttpClass;
            this.convector = convector;
            this.deviceSettings = deviceSettings;
            deviceTimeContent = tesyHttpClass.DeviceTimeContentResponse;    // TODO: Implement differently
            timeZonesFileContent = worldClock.ReadTimeZonesFileContent();
        }

        public void ResetDevice()
        {
            string command = "reset";
            string payloadContent = payloadSerializer.SerializeNoParamsAsJsonPayload();
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public void DeleteAllDevicePrograms()
        {
            string command = "deleteAllPrograms";
            string payloadContent = payloadSerializer.SerializeNoParamsAsJsonPayload();
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public void GetSSID()
        {
            string command = "getSSID";
            string payloadContent = payloadSerializer.SerializeNoParamsAsJsonPayload();
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public void GetStatus()
        {
            string command = "getStatus";
            string payloadContent = payloadSerializer.SerializeNoParamsAsJsonPayload();
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void TurnOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "onOff";
            string onOffValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                onOffValue = ((deviceParam.Value.State.Status != null) && (deviceParam.Value.State.Status == "on")) ? "off" : "on";
            }
            string payloadContent = payloadSerializer.SerializeOnOffParamsAsJsonPayload(onOffValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void TurnUVOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setUV";
            string UVValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                UVValue = ((deviceParam.Value.State.UV != null) && (deviceParam.Value.State.UV == "on")) ? "off" : "on";
            }
            string payloadContent = payloadSerializer.SerializeUVParamsAsJsonPayload(UVValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void TurnLockDeviceOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setLockDevice";
            string lockedDeviceValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                lockedDeviceValue = ((deviceParam.Value.State.LockedDevice != null) && (deviceParam.Value.State.LockedDevice == "on")) ? "off" : "on";
            }
            string payloadContent = payloadSerializer.SerializeLockedDeviceParamsAsJsonPayload(lockedDeviceValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void TurnOpenedWindowOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setOpenedWindow";
            string openedWindowValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                openedWindowValue = ((deviceParam.Value.State.OpenedWindow != null) && (deviceParam.Value.State.OpenedWindow == "on")) ? "off" : "on";
            }
            string payloadContent = payloadSerializer.SerializeOpenedWindowParamsAsJsonPayload(openedWindowValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void TurnAntiFrostOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setAntiFrost";
            string antiFrostValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                antiFrostValue = ((deviceParam.Value.State.AntiFrost != null) && (deviceParam.Value.State.AntiFrost == "on")) ? "off" : "on";
            }
            string payloadContent = payloadSerializer.SerializeAntiFrostParamsAsJsonPayload(antiFrostValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void TurnAdaptiveStartOnOff()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setAdaptiveStart";
            string adaptiveStartValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                adaptiveStartValue = ((deviceParam.Value.State.AdaptiveStart != null) && (deviceParam.Value.State.AdaptiveStart == "on")) ? "off" : "on";
            }
            string payloadContent = payloadSerializer.SerializeAdaptiveStartParamsAsJsonPayload(adaptiveStartValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetDeviceTemp()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setTemp";

            short newDeviceTempValue = Input.ReadTemperatureFromConsole();
            short oldDeviceTempValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldDeviceTempValue = deviceParam.Value.State.Temp != null ? short.Parse($"{deviceParam.Value.State.Temp}") : (short)10;
            }
            short temperatureValue = newDeviceTempValue != 0 ? newDeviceTempValue : oldDeviceTempValue;

            string payloadContent = payloadSerializer.SerializeDeviceTempParamsAsJsonPayload(temperatureValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetMode()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setMode";

            string newModeNameValue = Input.ReadModeNameFromConsole();
            string oldModeNameValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                oldModeNameValue = deviceParam.Value.State.Mode;
            }
            string nameValue = newModeNameValue != "" ? newModeNameValue : oldModeNameValue;

            string payloadContent = payloadSerializer.SerializeModeParamsAsJsonPayload(nameValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetEcoTemp()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setEcoTemp";

            short newEcoTempTemperatureValue = Input.ReadTemperatureFromConsole();
            int newEcoTempTimeValue = Input.ReadEcoTempTimeInMinutesFromConsole();
            short oldEcoTempTemperatureValue = 0;
            int oldEcoTempTimeValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldEcoTempTemperatureValue = deviceParam.Value.State.EcoTemp.Temp;
                oldEcoTempTimeValue = deviceParam.Value.State.EcoTemp.Time;
            }
            short temperatureValue = newEcoTempTemperatureValue != 0 ? newEcoTempTemperatureValue : oldEcoTempTemperatureValue;
            int timeValue = newEcoTempTimeValue != 0 ? newEcoTempTimeValue : oldEcoTempTimeValue;
            
            string payloadContent = payloadSerializer.SerializeEcoTempParamsAsJsonPayload(temperatureValue, timeValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetComfortTemp()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setComfortTemp";

            short newComfortTempTemperatureValue = Input.ReadTemperatureFromConsole();
            short oldComfortTempTemperatureValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldComfortTempTemperatureValue = deviceParam.Value.State.ComfortTemp.Temp;
            }
            short temperatureValue = newComfortTempTemperatureValue != 0 ? newComfortTempTemperatureValue : oldComfortTempTemperatureValue;

            string payloadContent = payloadSerializer.SerializeComfortTempParamsAsJsonPayload(temperatureValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetSleepMode()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setSleepTemp";

            int newSleepModeTimeValue = Input.ReadSleepModeTimeInMinutesFromConsole();
            int oldSleepModeTimeValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldSleepModeTimeValue = deviceParam.Value.State.SleepMode.Time;
            }
            int timeValue = newSleepModeTimeValue != 0 ? newSleepModeTimeValue : oldSleepModeTimeValue;

            string payloadContent = payloadSerializer.SerializeSleepModeParamsAsJsonPayload(timeValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetDelayedStart()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setDelayedStart";

            int newDelayedStartTimeValue = Input.ReadDelayedStartTimeInMinutesFromConsole();
            short newDelayedStartTempValue = Input.ReadTemperatureFromConsole();
            int oldDelayedStartTimeValue = 0;
            short oldDelayedStartTemperatureValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldDelayedStartTimeValue = deviceParam.Value.State.DelayedStart.Time;
                oldDelayedStartTemperatureValue = deviceParam.Value.State.DelayedStart.Temp;
            }
            int timeValue = newDelayedStartTimeValue >= 0 ? newDelayedStartTimeValue : oldDelayedStartTimeValue;
            short temperatureValue = newDelayedStartTempValue != 0 ? newDelayedStartTempValue : oldDelayedStartTemperatureValue;

            string payloadContent = payloadSerializer.SerializeDelayedStartParamsAsJsonPayload(timeValue, temperatureValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetDeviceName()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
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

        public async void SetDeviceWifi()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setWifiData";

            string newDeviceWifiSSIDValue = Input.ReadDeviceWifiSSIDFromConsole();
            string newDeviceWifiPassValue = Input.ReadDeviceWifiPassFromConsole();
            string oldDeviceWifiSSIDValue = "";
            string oldDeviceWifiPassValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                oldDeviceWifiSSIDValue = deviceParam.Value.Wifi_SSID;
                oldDeviceWifiPassValue = deviceParam.Value.Wifi_Pass;
            }
            string wifiSSID = newDeviceWifiSSIDValue != "" ? newDeviceWifiSSIDValue : oldDeviceWifiSSIDValue;
            string wifiPass = newDeviceWifiPassValue != "" ? newDeviceWifiPassValue : oldDeviceWifiPassValue;

            string payloadContent = payloadSerializer.SerializeDeviceWifiParamsAsJsonPayload(wifiSSID, wifiPass);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetTCorrection()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            string command = "setTCorrection";

            short newTCorrectionTemperatureValue = Input.ReadTCorrectionTemperatureFromConsole();
            short oldTCorrectionTemperatureValue = 0;
            foreach (var deviceParam in myDevicesContent)
            {
                oldTCorrectionTemperatureValue = deviceParam.Value.State.TCorrection;
            }
            short temperatureValue = ((newTCorrectionTemperatureValue > -4) || (newTCorrectionTemperatureValue < 4)) ? newTCorrectionTemperatureValue : oldTCorrectionTemperatureValue;

            string payloadContent = payloadSerializer.SerializeTCorrectionParamsAsJsonPayload(temperatureValue);
            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }

        public async void SetTimeZone()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            deviceTimeContent = tesyHttpClass.DeviceTimeContentResponse;    // TODO: Implement differently
            string macAddress = "";
            string command = "timeResponse";
            string requestType = "timeResponse";

            string newDateValue = "";
            string newTimeValue = "";
            short newWeekdayValue = -1;

            Output.PrintIanaTimeZoneIds(timeZonesFileContent);
            string newTimeZoneValue = Input.ReadIanaTimeZoneIdFromConsole(timeZonesFileContent);
            if (newTimeZoneValue != "")
            {
                newDateValue = worldClock.GetNewTimeZoneDate(newTimeZoneValue);
                newTimeValue = worldClock.GetNewTimeZoneTime(newTimeZoneValue);
                newWeekdayValue = worldClock.GetNewWeekday(newTimeZoneValue);
            }
            
            string oldTimeZoneValue = "";
            foreach (var deviceParam in myDevicesContent)
            {
                macAddress = deviceParam.Key;
                oldTimeZoneValue = deviceParam.Value.Timezone;
            }
            string oldDateValue = deviceTimeContent.Date;
            string oldTimeValue = deviceTimeContent.Time;
            short oldWeekdayValue = worldClock.GetNewWeekday(oldTimeZoneValue);
            
            string timeZoneValue = newTimeZoneValue != "" ? newTimeZoneValue : oldTimeZoneValue;
            string dateValue = newDateValue != "" ? newDateValue : oldDateValue;
            string timeValue = newTimeValue != "" ? newTimeValue : oldTimeValue;
            short weekdayValue = newWeekdayValue != -1 ? newWeekdayValue : oldWeekdayValue;

            if (newTimeZoneValue != "")
            {
                queryParams = new(
                    new[] {
                        KeyValuePair.Create("mac", macAddress),
                        KeyValuePair.Create("timezone", newTimeZoneValue)
                    }
                );
                updateDeviceSettings.PostUpdateDeviceSettings(queryParams);
            }

            string payloadContent = payloadSerializer.SerializeTimeZoneParamsAsJsonPayload(weekdayValue, timeValue, timeZoneValue, dateValue);
            deviceSettings.PublishMessage(convector, requestType, command, payloadContent);
        }
    }
}