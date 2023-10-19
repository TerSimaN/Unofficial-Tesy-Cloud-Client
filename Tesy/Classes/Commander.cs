using Tesy.Commands;
using Tesy.Commands.DeviceCommands;
using Tesy.Programs;

namespace Tesy.Classes
{
    public class Commander
    {
        private readonly DevicePowerStat devicePowerStat;
        private readonly DeviceTempStat deviceTempStat;
        private readonly TesyDocuments tesyDocuments;
        private readonly LoginData loginData;
        private readonly MyDevices myDevices;
        private readonly MyGroups myGroups;
        private readonly MyMessages myMessages;
        private readonly TestDevices testDevices;
        private readonly UpdateUserAccountSettings updateUserAccountSettings;
        private readonly UpdateUserPasswordSettings updateUserPasswordSettings;
        private readonly UserHasAccessToCloud userHasAccessToCloud;
        private readonly UserInfo userInfo;

        private readonly User user;
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
            DevicePowerStat devicePowerStat, DeviceTempStat deviceTempStat,
            TesyDocuments tesyDocuments, LoginData loginData, MyDevices myDevices,
            MyGroups myGroups, MyMessages myMessages, TestDevices testDevices,
            UpdateUserAccountSettings updateUserAccountSettings,
            UpdateUserPasswordSettings updateUserPasswordSettings,
            UserHasAccessToCloud userHasAccessToCloud, UserInfo userInfo,
            User user, WeekProgram weekProgram, CreateWeekProgram createWeekProgram,
            Reset reset, DeleteAllDevicePrograms deleteAllDevicePrograms,
            DeviceSSID deviceSSID, DeviceStatus deviceStatus, OnOff onOff,
            UV uv, LockDevice lockDevice, OpenedWindow openedWindow,
            AntiFrost antiFrost, AdaptiveStart adaptiveStart, DeviceTemp deviceTemp,
            Mode mode, EcoTemp ecoTemp, ComfortTemp comfortTemp, SleepTemp sleepTemp,
            DelayedStart delayedStart, DeviceName deviceName, WifiData wifiData,
            TCorrection tCorrection, DeviceTimeZone deviceTimeZone
        )
        {
            this.devicePowerStat = devicePowerStat;
            this.deviceTempStat = deviceTempStat;
            this.tesyDocuments = tesyDocuments;
            this.loginData = loginData;
            this.myDevices = myDevices;
            this.myGroups = myGroups;
            this.myMessages = myMessages;
            this.testDevices = testDevices;
            this.updateUserAccountSettings = updateUserAccountSettings;
            this.updateUserPasswordSettings = updateUserPasswordSettings;
            this.userHasAccessToCloud = userHasAccessToCloud;
            this.userInfo = userInfo;

            this.user = user;
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

        public void ShowAllCommands()
        {
            do
            {
                Output.PrintListOfAllCommands();

                Console.Write("Input: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    inputValue = inputValue.Trim();
                    if (inputValue.Equals("exit"))
                    {
                        break;
                    }

                    switch (inputValue)
                    {
                        case "commands":
                            ShowDeviceCommands();
                            continue;
                        case "settings":
                            ShowCommandsForAvailableSettings();
                            continue;
                        case "tesy_data":
                            ShowCommandsForAvailableData();
                            continue;
                        default:
                            continue;
                    }
                }
            } while (true);
        }

        private async void ShowDeviceCommands()
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

        private async void ShowCommandsForAvailableSettings()
        {
            do
            {
                Output.PrintListOfSettingsCommands();

                Console.Write("Input: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    inputValue = inputValue.Trim();
                    if (inputValue.Equals("back"))
                    {
                        break;
                    }
                    
                    switch (inputValue)
                    {
                        case "account":
                            var userInfoContent = await userInfo.GetUserInfo();
                            Output.PrintUserAccountDetails(userInfoContent);
                            ShowAccountDetailsCommands();
                            continue;
                        case "password":
                            ShowPasswordDetailsCommands();
                            continue;
                        default:
                            continue;
                    }
                }
            } while (true);
        }

        private void ShowAccountDetailsCommands()
        {
            do
            {
                Output.PrintListOfAccountDetailsCommands();

                Console.Write("Input: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    inputValue = inputValue.Trim();
                    if (inputValue.Equals("back"))
                    {
                        break;
                    }

                    switch (inputValue)
                    {
                        case "change_email":
                            user.ChangeUserEmail();
                            continue;
                        case "change_first_name":
                            user.ChangeUserFirstName();
                            continue;
                        case "change_last_name":
                            user.ChangeUserLastName();
                            continue;
                        case "change_lang":
                            user.ChangeUserLang();
                            continue;
                        case "confirm":
                            updateUserAccountSettings.PostUpdateUserAccountSettings(user);
                            continue;
                        default:
                            continue;
                    }
                }
            } while (true);
        }

        private void ShowPasswordDetailsCommands()
        {
            do
            {
                Output.PrintListOfPasswordDetailsCommands();

                Console.Write("Input: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    inputValue = inputValue.Trim();
                    if (inputValue.Equals("back"))
                    {
                        break;
                    }

                    switch (inputValue)
                    {
                        case "change_password":
                            user.ChangeUserPassword();
                            continue;
                        case "confirm":
                            updateUserPasswordSettings.PostUpdateUserPasswordSettings(user);
                            continue;
                        default:
                            continue;
                    }
                }
            } while (true);
        }

        private async void ShowCommandsForAvailableData()
        {
            do
            {
                Output.PrintListOfTesyHttpClassCommands();

                Console.Write("Input: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    inputValue = inputValue.Trim();
                    if (inputValue.Equals("back"))
                    {
                        break;
                    }

                    switch (inputValue)
                    {
                        case "login_data":
                            await loginData.PostLoginData();
                            continue;
                        case "user_has_access_to_cloud":
                            userHasAccessToCloud.GetUserHasAccessToCloud();
                            continue;
                        case "user_info":
                            await userInfo.GetUserInfo();
                            continue;
                        case "my_devices":
                            await myDevices.GetMyDevices();
                            continue;
                        case "my_groups":
                            myGroups.GetMyGroups();
                            continue;
                        case "my_messages":
                            myMessages.GetMyMessages();
                            continue;
                        case "test_devices":
                            testDevices.GetTestDevices();
                            continue;
                        case "device_temp_stat":
                            var myDevicesTempStatContent = await myDevices.GetMyDevices();
                            deviceTempStat.GetDeviceTempStat(myDevicesTempStatContent);
                            continue;
                        case "device_power_stat":
                            var myDevicesPowerStatContent = await myDevices.GetMyDevices();
                            devicePowerStat.GetDevicePowerStat(myDevicesPowerStatContent);
                            continue;
                        case "documents":
                            tesyDocuments.GetTesyDocuments();
                            continue;
                        default:
                            continue;
                    }
                }
            } while (true);
        }
    }
}