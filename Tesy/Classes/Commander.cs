using Tesy.Commands;
using Tesy.Commands.DeviceCommands;
using Tesy.Programs;

namespace Tesy.Classes
{
    public class Commander
    {
        private readonly MyDevices myDevices;
        private readonly WeekProgram weekProgram;
        private readonly CreateWeekProgram createWeekProgram;

        private readonly Reset reset;
        private readonly DeleteAllDevicePrograms deleteAllDevicePrograms;
        private readonly DeviceSSID deviceSSID;
        private readonly DeviceStatus deviceStatus;
        private readonly OnOff onOff;
        private readonly UV uv;
        private readonly LockDevice lockDevice;
        private readonly OpenedWindow openedWindow;
        private readonly AntiFrost antiFrost;
        private readonly AdaptiveStart adaptiveStart;
        private readonly DeviceTemp deviceTemp;
        private readonly Mode mode;
        private readonly EcoTemp ecoTemp;
        private readonly ComfortTemp comfortTemp;
        private readonly SleepTemp sleepTemp;
        private readonly DelayedStart delayedStart;
        private readonly DeviceName deviceName;
        private readonly WifiData wifiData;
        private readonly TCorrection tCorrection;
        private readonly DeviceTimeZone deviceTimeZone;

        public Commander(
            MyDevices myDevices,
            WeekProgram weekProgram,
            CreateWeekProgram createWeekProgram,
            Reset reset,
            DeleteAllDevicePrograms deleteAllDevicePrograms,
            DeviceSSID deviceSSID,
            DeviceStatus deviceStatus,
            OnOff onOff,
            UV uv,
            LockDevice lockDevice,
            OpenedWindow openedWindow,
            AntiFrost antiFrost,
            AdaptiveStart adaptiveStart,
            DeviceTemp deviceTemp,
            Mode mode,
            EcoTemp ecoTemp,
            ComfortTemp comfortTemp,
            SleepTemp sleepTemp,
            DelayedStart delayedStart,
            DeviceName deviceName,
            WifiData wifiData,
            TCorrection tCorrection,
            DeviceTimeZone deviceTimeZone
        )
        {
            this.myDevices = myDevices;
            this.weekProgram = weekProgram;
            this.createWeekProgram = createWeekProgram;
            this.reset = reset;
            this.deleteAllDevicePrograms = deleteAllDevicePrograms;
            this.deviceSSID = deviceSSID;
            this.deviceStatus = deviceStatus;
            this.onOff = onOff;
            this.uv = uv;
            this.lockDevice = lockDevice;
            this.openedWindow = openedWindow;
            this.antiFrost = antiFrost;
            this.adaptiveStart = adaptiveStart;
            this.deviceTemp = deviceTemp;
            this.mode = mode;
            this.ecoTemp = ecoTemp;
            this.comfortTemp = comfortTemp;
            this.sleepTemp = sleepTemp;
            this.delayedStart = delayedStart;
            this.deviceName = deviceName;
            this.wifiData = wifiData;
            this.tCorrection = tCorrection;
            this.deviceTimeZone = deviceTimeZone;
        }

        public async void ShowDeviceCommands()
        {
            do
            {
                Output.PrintListOfDeviceCommands();

                Console.Write("Input: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    await myDevices.GetMyDevices();

                    inputValue = inputValue.Trim();
                    if (inputValue.Equals("back"))
                    {
                        break;
                    }

                    switch (inputValue)
                    {
                        case "on_off":
                            onOff.TurnOnOff();
                            continue;
                        case "temperature":
                            deviceTemp.SetDeviceTemp();
                            continue;
                        case "mode":
                            mode.SetMode();
                            continue;
                        case "week_program":
                            ShowWeekProgramCommands();
                            continue;
                        case "eco_temp":
                            ecoTemp.SetEcoTemp();
                            continue;
                        case "comfort_temp":
                            comfortTemp.SetComfortTemp();
                            continue;
                        case "sleep_mode":
                            sleepTemp.SetSleepMode();
                            continue;
                        case "delayed_start":
                            delayedStart.SetDelayedStart();
                            continue;
                        case "lock_device":
                            lockDevice.TurnLockDeviceOnOff();
                            continue;
                        case "open_window":
                            openedWindow.TurnOpenedWindowOnOff();
                            continue;
                        case "anti_frost":
                            antiFrost.TurnAntiFrostOnOff();
                            continue;
                        case "adaptive_start":
                            adaptiveStart.TurnAdaptiveStartOnOff();
                            continue;
                        case "UV":
                            uv.TurnUVOnOff();
                            continue;
                        case "more":
                            ShowMoreDeviceCommands();
                            continue;
                        case "reload":
                            continue;
                        default:
                            continue;
                    }
                }
            } while (true);
        }

        private async void ShowMoreDeviceCommands()
        {
            do
            {
                Output.PrintListOfMoreDeviceCommands();

                Console.Write("Input: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    await myDevices.GetMyDevices();
                    
                    inputValue = inputValue.Trim();
                    if (inputValue.Equals("back"))
                    {
                        break;
                    }

                    switch (inputValue)
                    {
                        case "device_name":
                            deviceName.SetDeviceName();
                            continue;
                        case "device_wifi":
                            wifiData.SetDeviceWifi();
                            continue;
                        case "TCorrection":
                            tCorrection.SetTCorrection();
                            continue;
                        case "time_zone":
                            deviceTimeZone.SetTimeZone();
                            continue;
                        case "reset":
                            reset.ResetDevice();
                            continue;
                        case "get_ssid":
                            deviceSSID.GetSSID();
                            continue;
                        case "get_status":
                            deviceStatus.GetStatus();
                            continue;
                        case "delete_all_programs":
                            deleteAllDevicePrograms.DeleteAllPrograms();
                            continue;
                        case "reload":
                            continue;
                        default:
                            continue;
                    }
                }
            } while (true);
        }

        private async void ShowWeekProgramCommands()
        {
            do
            {
                Output.PrintListOfWeekProgramCommands();

                Console.Write("Input: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    await myDevices.GetMyDevices();
                    var deviceProgramsDictionary = await myDevices.GetDevicePrograms();

                    inputValue = inputValue.Trim();
                    if (inputValue.Equals("back"))
                    {
                        break;
                    }

                    switch (inputValue)
                    {
                        case "view":
                            Output.PrintDeviceProgramsContent(deviceProgramsDictionary);
                            continue;
                        case "add":
                            Output.PrintDeviceProgramsContent(deviceProgramsDictionary);
                            weekProgram.AddWeekProgram(createWeekProgram);
                            continue;
                        case "edit":
                            Output.PrintDeviceProgramsContent(deviceProgramsDictionary);
                            weekProgram.EditWeekProgram(createWeekProgram);
                            continue;
                        case "delete":
                            Output.PrintDeviceProgramsContent(deviceProgramsDictionary);
                            weekProgram.DeleteWeekProgram();
                            continue;
                        case "reload":
                            continue;
                        default:
                            continue;
                    }
                }
            } while (true);
        }
    }
}