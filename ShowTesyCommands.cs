public class ShowTesyCommands
{
    private readonly TesyHttpClass tesyHttpClass;
    private readonly CreateProgram createProgram;
    private readonly TesyWeekProgramClass tesyWeekProgram;
    private readonly TesyDeviceCommandsClass tesyDeviceCommands;
    private readonly TesyUserClass tesyUserClass;
    private readonly TesyDebugClass tesyDebugClass;

    public ShowTesyCommands(
        TesyHttpClass tesyHttpClass,
        CreateProgram createProgram,
        TesyWeekProgramClass tesyWeekProgram,
        TesyDeviceCommandsClass tesyDeviceCommands,
        TesyUserClass tesyUserClass,
        TesyDebugClass tesyDebugClass
    )
    {
        this.tesyHttpClass = tesyHttpClass;
        this.createProgram = createProgram;
        this.tesyWeekProgram = tesyWeekProgram;
        this.tesyDeviceCommands = tesyDeviceCommands;
        this.tesyUserClass = tesyUserClass;
        this.tesyDebugClass = tesyDebugClass;
    }

    public void ShowListOfAllCommands()
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
                        ShowListOfDeviceCommands();
                        continue;
                    case "settings":
                        ShowListOfCommandsForAvailableSettings();
                        continue;
                    case "tesy_data":
                        ShowListOfCommandsForAvailableData();
                        continue;
                    case "debug":
                        ShowListOfDebugCommands();
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }

    private void ShowListOfDeviceCommands()
    {
        do
        {
            Output.PrintListOfDeviceCommands();

            Console.Write("Input: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                tesyHttpClass.GetTesyMyDevices();

                inputValue = inputValue.Trim();
                if (inputValue.Equals("back"))
                {
                    break;
                }

                switch (inputValue)
                {
                    case "on_off":
                        tesyDeviceCommands.TurnOnOff();
                        continue;
                    case "temperature":
                        tesyDeviceCommands.SetDeviceTemp();
                        continue;
                    case "mode":
                        tesyDeviceCommands.SetMode();
                        continue;
                    case "week_program":
                        ShowListOfWeekProgramCommands();
                        continue;
                    case "eco_temp":
                        tesyDeviceCommands.SetEcoTemp();
                        continue;
                    case "comfort_temp":
                        tesyDeviceCommands.SetComfortTemp();
                        continue;
                    case "sleep_mode":
                        tesyDeviceCommands.SetSleepMode();
                        continue;
                    case "delayed_start":
                        tesyDeviceCommands.SetDelayedStart();
                        continue;
                    case "lock_device":
                        tesyDeviceCommands.TurnLockDeviceOnOff();
                        continue;
                    case "open_window":
                        tesyDeviceCommands.TurnOpenedWindowOnOff();
                        continue;
                    case "anti_frost":
                        tesyDeviceCommands.TurnAntiFrostOnOff();
                        continue;
                    case "adaptive_start":
                        tesyDeviceCommands.TurnAdaptiveStartOnOff();
                        continue;
                    case "UV":
                        tesyDeviceCommands.TurnUVOnOff();
                        continue;
                    case "more":
                        ShowListOfMoreDeviceCommands();
                        continue;
                    case "reload":
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }

    private void ShowListOfMoreDeviceCommands()
    {
        do
        {
            Output.PrintListOfMoreDeviceCommands();

            Console.Write("Input: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                tesyHttpClass.GetTesyMyDevices();
                
                inputValue = inputValue.Trim();
                if (inputValue.Equals("back"))
                {
                    break;
                }

                switch (inputValue)
                {
                    case "device_name":
                        tesyDeviceCommands.SetDeviceName();
                        continue;
                    case "device_wifi":
                        tesyDeviceCommands.SetDeviceWifi();
                        continue;
                    case "TCorrection":
                        tesyDeviceCommands.SetTCorrection();
                        continue;
                    case "time_zone":
                        tesyDeviceCommands.SetTimeZone();
                        continue;
                    case "reset":
                        tesyDeviceCommands.ResetDevice();
                        continue;
                    case "get_ssid":
                        tesyDeviceCommands.GetSSID();
                        continue;
                    case "get_status":
                        tesyDeviceCommands.GetStatus();
                        continue;
                    case "delete_all_programs":
                        tesyDeviceCommands.DeleteAllDevicePrograms();
                        continue;
                    case "reload":
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }

    private void ShowListOfWeekProgramCommands()
    {
        do
        {
            Output.PrintListOfWeekProgramCommands();

            Console.Write("Input: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                tesyHttpClass.GetTesyMyDevices();

                inputValue = inputValue.Trim();
                if (inputValue.Equals("back"))
                {
                    break;
                }

                switch (inputValue)
                {
                    case "view":
                        Output.PrintDeviceProgramsContent(tesyHttpClass.DeviceProgramsDictionary);
                        continue;
                    case "add":
                        Output.PrintDeviceProgramsContent(tesyHttpClass.DeviceProgramsDictionary);
                        tesyWeekProgram.AddWeekProgram(createProgram);
                        continue;
                    case "edit":
                        Output.PrintDeviceProgramsContent(tesyHttpClass.DeviceProgramsDictionary);
                        tesyWeekProgram.EditWeekProgram(createProgram);
                        continue;
                    case "delete":
                        Output.PrintDeviceProgramsContent(tesyHttpClass.DeviceProgramsDictionary);
                        tesyWeekProgram.DeleteWeekProgram();
                        continue;
                    case "reload":
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }

    private void ShowListOfCommandsForAvailableSettings()
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
                        tesyHttpClass.GetTesyUserInfo();
                        Output.PrintUserAccountDetails(tesyHttpClass.UserInfoContent);
                        ShowListOfAccountDetailsCommands();
                        continue;
                    case "password":
                        ShowListOfPasswordDetailsCommands();
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }

    private void ShowListOfAccountDetailsCommands()
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
                        tesyUserClass.ChangeUserEmail();
                        continue;
                    case "change_first_name":
                        tesyUserClass.ChangeUserFirstName();
                        continue;
                    case "change_last_name":
                        tesyUserClass.ChangeUserLastName();
                        continue;
                    case "change_lang":
                        tesyUserClass.ChangeUserLang();
                        continue;
                    case "confirm":
                        tesyHttpClass.PostUpdateUserAccountSettings(tesyUserClass);
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }

    private void ShowListOfPasswordDetailsCommands()
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
                        tesyUserClass.ChangeUserPassword();
                        continue;
                    case "confirm":
                        tesyHttpClass.PostUpdateUserPasswordSettings(tesyUserClass);
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }

    private void ShowListOfCommandsForAvailableData()
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
                        tesyHttpClass.PostTesyLoginData();
                        continue;
                    case "user_has_access_to_cloud":
                        tesyHttpClass.GetTesyUserHasAccessToCloud();
                        continue;
                    case "user_info":
                        tesyHttpClass.GetTesyUserInfo();
                        continue;
                    case "my_devices":
                        tesyHttpClass.GetTesyMyDevices();
                        continue;
                    case "my_groups":
                        tesyHttpClass.GetTesyMyGroups();
                        continue;
                    case "my_messages":
                        tesyHttpClass.GetTesyMyMessages();
                        continue;
                    case "test_devices":
                        tesyHttpClass.GetTesyTestDevices();
                        continue;
                    case "device_temp_stat":
                        tesyHttpClass.GetTesyDeviceTempStat();
                        continue;
                    case "device_power_stat":
                        tesyHttpClass.GetTesyDevicePowerStat();
                        continue;
                    case "documents":
                        tesyHttpClass.GetTesyDocuments();
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }

    private void ShowListOfDebugCommands()
    {
        do
        {
            Output.PrintListOfDebugCommands();

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
                    case "1":
                        tesyHttpClass.GetTesyMyDevices();
                        continue;
                    case "2":
                        tesyDebugClass.DebugLogin();
                        continue;
                    default:
                        continue;
                }
            }
        } while (true);
    }
}