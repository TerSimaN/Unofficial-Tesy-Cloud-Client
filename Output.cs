using System.Text;

public static class Output
{
    private static readonly Dictionary<string, string> languages = TesyConstants.Languages;
    private static StringBuilder? outputBuilder;

    public static void PrintListOfAllCommands()
    {
        outputBuilder = new();

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"commands\" to show a list of device commands;\n" +
            "Input \"settings\" to show a list of commands for available settings;\n" +
            "Input \"tesy_data\" to show a list of commands for available data to print;\n" +
            // "Input \"debug\" to show a list of commands for testing/debugging;\n" +
            "Input \"exit\" to exit."
        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintListOfDeviceCommands()
    {
        outputBuilder = new();

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"on_off\" to turn device heating On/Off;\n" +
            "Input \"temperature\" to set device Temperature;\n" +
            "Input \"mode\" to set device Mode;\n" +
            "Input \"week_program\" to show a list of commands for Week Program;\n" +
            "Input \"eco_temp\" to set device EcoMode data;\n" +
            "Input \"comfort_temp\" to set device ComfortMode data;\n" +
            "Input \"sleep_mode\" to set device SleepMode data;\n" +
            "Input \"delayed_start\" to set device DelayedStart data;\n" +
            "Input \"lock_device\" to Lock/Unlock device;\n" +
            "Input \"open_window\" to turn device OpenWindow On/Off;\n" +
            "Input \"anti_frost\" to turn device Anti-Frost On/Off;\n" +
            "Input \"adaptive_start\" to turn device AdaptiveStart On/Off;\n" +
            "Input \"UV\" to turn device UV (or AirSafe) On/Off;\n" +
            "Input \"more\" to show list of more device commands;\n" +
            "Input \"reload\" to re-get MyDevicesContent;\n" +
            "Input \"back\" to go back."

        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintListOfMoreDeviceCommands()
    {
        outputBuilder = new();

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"device_name\" to change device name;\n" +
            "Input \"device_wifi\" to set device Wifi info;\n" +
            "Input \"TCorrection\" to set device TCorrection;\n" +
            "Input \"time_zone\" to set device TimeZone;\n" +
            "Input \"reset\" to Reset device;\n" +
            "Input \"get_ssid\" to get device SSID;\n" +
            "Input \"get_status\" to get status;\n" +
            "Input \"delete_all_programs\" to Delete All device programs;\n" +
            "Input \"reload\" to re-get MyDevicesContent;\n" +
            "Input \"back\" to go back."
        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintListOfWeekProgramCommands()
    {
        outputBuilder = new();

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"view\" to view current programs;\n" +
            "Input \"add\" to Add a new program;\n" +
            "Input \"edit\" to Edit an existing program;\n" +
            "Input \"delete\" to Delete an existing program;\n" +
            "Input \"reload\" to re-get MyDevicesContent;\n" +
            "Input \"back\" to go back."
        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintListOfSettingsCommands()
    {
        outputBuilder = new();

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"account\" to view Account details;\n" +
            "Input \"password\" to view Password details;\n" +
            "Input \"back\" to go back."
        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintListOfAccountDetailsCommands()
    {
        outputBuilder = new();

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"change_email\" to Change your Email;\n" +
            "Input \"change_first_name\" to Change your First name;\n" +
            "Input \"change_last_name\" to Change your Last name;\n" +
            "Input \"change_lang\" to Change your Language;\n" +
            "Input \"confirm\" to Confirm changes;\n" +
            "Input \"back\" to go back."
        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintListOfPasswordDetailsCommands()
    {
        outputBuilder = new();

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"change_password\" to Change your Password;\n" +
            "Input \"confirm\" to Confirm changes;\n" +
            "Input \"back\" to go back."
        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintListOfTesyHttpClassCommands()
    {
        outputBuilder = new();
        int indexOfLastSlash = TesyConstants.PathToHttpResponseMessagesFile.LastIndexOf("\\") + 1;
        string fileName = TesyConstants.PathToHttpResponseMessagesFile.Substring(indexOfLastSlash);

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"login_data\" to print data for TesyLogin;\n" +
            "Input \"user_has_access_to_cloud\" to print data for TesyUserHasAccessToCloud;\n" +
            "Input \"user_info\" to print data for TesyUserInfo;\n" +
            "Input \"my_devices\" to print data for TesyMyDevices;\n" +
            "Input \"my_groups\" to print data for TesyMyGroups;\n" +
            "Input \"my_messages\" to print data for TesyMyMessages;\n" +
            "Input \"test_devices\" to print data for TesyTestDevices;\n" +
            "Input \"device_temp_stat\" to print data for TesyDeviceTempStat;\n" +
            "Input \"device_power_stat\" to print data for TesyDevicePowerStat;\n" +
            "Input \"documents\" to print data for TesyDocuments;\n" +
            $"Check {fileName} file for returned data;\n" +
            "Input \"back\" to go back."
        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintListOfDebugCommands()
    {
        outputBuilder = new();

        outputBuilder.AppendLine("------------------------------------------------------------");
        outputBuilder.AppendLine(
            "Input \"1\" to add new program parameters;\n" +
            "Input \"2\" to view program parameters;\n" +
            "Input \"3\" to view \"add program\" parameters in JSON format;\n" +
            "Input \"4\" to view \"world_clock\";\n" +
            "Input \"5\" to check if time parameters for new program are valid (is_time_valid);\n" +
            "Input \"6\" to re-get MyDevicesContent;\n" +
            "Input \"7\" to debug login and debug get LoginContent;\n" +
            "Input \"back\" to go back."
        );
        outputBuilder.AppendLine("------------------------------------------------------------");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintAvailableLanguages(Dictionary<string, string> languageDictionary)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("Available languages:");
        foreach (var language in languageDictionary)
        {
            outputBuilder.AppendLine($"{language.Key};");
        }

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintIanaTimeZoneIds(Dictionary<string, TimeZonesFileContent> timeZonesFileContent)
    {
        outputBuilder = new();
        int numberToCount = 1;

        foreach (var tzParam in timeZonesFileContent)
        {
            if (int.Parse(tzParam.Key) < 10)
            {
                outputBuilder.Append($"| {tzParam.Key}.   ");
            }
            else if (int.Parse(tzParam.Key) < 100)
            {
                outputBuilder.Append($"| {tzParam.Key}.  ");
            }
            else
            {
                outputBuilder.Append($"| {tzParam.Key}. ");
            }

            if (tzParam.Value.IanaId.Length <= 30)
            {
                outputBuilder.Append($"{tzParam.Value.UtcOffset} {tzParam.Value.IanaId}");
                for (int i = 0; i <= (30 - tzParam.Value.IanaId.Length); i++)
                {
                    outputBuilder.Append(" ");
                }
            }

            if ((numberToCount % 4) == 0)
            {
                outputBuilder.AppendLine("|");
            }

            ++numberToCount;
        }
        Console.WriteLine(outputBuilder.ToString());
    }

    public static void PrintCreateProgramValues(CreateProgram createProgram)
    {
        outputBuilder = new();

        outputBuilder.AppendLine($"Program day of week: {createProgram.DayOfWeek}");
        outputBuilder.AppendLine($"From time: {createProgram.FromTime}");
        outputBuilder.AppendLine($"To time: {createProgram.ToTime}");
        outputBuilder.AppendLine($"Program temperature: {createProgram.ProgramTemp}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintDeviceProgramDataContent(Dictionary<string, DeviceProgramDataContent> deviceProgramDataContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("DeviceProgramDataResponse: {");
        foreach (var programDataParam in deviceProgramDataContent)
        {
            outputBuilder.AppendLine($"  \"{programDataParam.Key}\": {{");
            outputBuilder.AppendLine($"    ProgramDay: {programDataParam.Value.ProgramDay},");
            outputBuilder.AppendLine($"    ProgramFrom: \"{programDataParam.Value.ProgramFrom}\"");
            outputBuilder.AppendLine("  }");
        }
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintDeviceProgramsContent(Dictionary<string, DeviceProgram> devicePrograms)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("Week Programs: {");
        foreach (var program in devicePrograms)
        {
            outputBuilder.AppendLine($"  \"{program.Key}\": {{");
            outputBuilder.AppendLine($"    Day: {program.Value.Day},");
            outputBuilder.AppendLine($"    From: {program.Value.From},");
            outputBuilder.AppendLine($"    To: {program.Value.To},");
            outputBuilder.AppendLine($"    Temp: {program.Value.Temp},");
            outputBuilder.AppendLine($"    Program_Number: {program.Value.Program_Number}");
            outputBuilder.AppendLine("  }");
        }
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintAllCreatedWeekPrograms(Dictionary<string, DeviceProgram> dictionary)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("All Created Week Programs: {");
        foreach (var program in dictionary)
        {
            outputBuilder.AppendLine($"  \"{program.Key}\": {{");
            outputBuilder.AppendLine($"    Day: {program.Value.Day},");
            outputBuilder.AppendLine($"    From: {program.Value.From},");
            outputBuilder.AppendLine($"    To: {program.Value.To},");
            outputBuilder.AppendLine($"    Temp: {program.Value.Temp},");
            outputBuilder.AppendLine($"    Program_Number: {program.Value.Program_Number}");
            outputBuilder.AppendLine("  }");
        }
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintEditWeekProgramByProgramIdContent(Dictionary<string, DeviceProgram> dictionary, string programId)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("Week Program being edited: {");
        foreach (var program in dictionary)
        {
            if (program.Key == programId)
            {
                outputBuilder.AppendLine($"  \"{program.Key}\": {{");
                outputBuilder.AppendLine($"    Day: {program.Value.Day},");
                outputBuilder.AppendLine($"    From: {program.Value.From},");
                outputBuilder.AppendLine($"    To: {program.Value.To},");
                outputBuilder.AppendLine($"    Temp: {program.Value.Temp},");
                outputBuilder.AppendLine($"    Program_Number: {program.Value.Program_Number}");
                outputBuilder.AppendLine("  }");
            }
        }
        outputBuilder.AppendLine("}");
        
        Console.Write(outputBuilder.ToString());
    }
    
    public static void PrintTimeZonesFileContent(Dictionary<string, TimeZonesFileContent> timeZonesFileContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TimeZonesFileContent:");
        foreach (var tzParam in timeZonesFileContent)
        {
            outputBuilder.AppendLine($"\"{tzParam.Key}\": {{");
            outputBuilder.AppendLine($"  CountryCode: \"{tzParam.Value.CountryCode}\",");
            outputBuilder.AppendLine($"  IanaId: \"{tzParam.Value.IanaId}\",");
            outputBuilder.AppendLine($"  WindowsId: \"{tzParam.Value.WindowsId ?? "Not Found"}\",");
            outputBuilder.AppendLine($"  UtcOffset: \"{tzParam.Value.UtcOffset ?? "Not found"}\",");
            outputBuilder.AppendLine($"  Comments: \"{tzParam.Value.Comments}\"");
            outputBuilder.AppendLine("},");
        }

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintCredentialsError(Dictionary<string, CredentialsError> credentialErrors)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyCredentialsError:");
        foreach (var error in credentialErrors)
        {
            outputBuilder.AppendLine($"Email: {error.Value.Email[0]},");
            outputBuilder.AppendLine($"Password: {error.Value.Password[0]}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintEmailError(Dictionary<string, EmailError> emailError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyEmailError:");
        foreach (var error in emailError)
        {
            outputBuilder.AppendLine($"Email: {error.Value.Email[0]}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintPasswordError(Dictionary<string, PasswordError> passwordError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyPasswordError:");
        foreach (var error in passwordError)
        {
            outputBuilder.AppendLine($"Password: {error.Value.Password[0]}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintGlobalError(Dictionary<string, GlobalError> globalError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyGlobalError:");
        foreach (var error in globalError)
        {
            outputBuilder.AppendLine($"Global: {error.Value.Global}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintNoMatchFoundInRecordsError(NoMatchFoundInRecordsError noMatchFoundInRecordsError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("NoMatchFoundInRecordsError:");
        outputBuilder.AppendLine($"Error: {noMatchFoundInRecordsError.Error}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintNameError(Dictionary<string, NameError> nameError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("NameError:");
        foreach (var error in nameError)
        {
            outputBuilder.AppendLine($"Name: {error.Value.Name[0]}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintLastNameError(Dictionary<string, LastNameError> lastNameError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("LastNameError:");
        foreach (var error in lastNameError)
        {
            outputBuilder.AppendLine($"LastName: {error.Value.LastName[0]}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintAccountDetailsError(Dictionary<string, AccountDetailsError> accountDetailsError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("AccountDetailsError:");
        foreach (var error in accountDetailsError)
        {
            outputBuilder.AppendLine($"Email: {error.Value.Email},");
            outputBuilder.AppendLine($"Name: {error.Value.Name},");
            outputBuilder.AppendLine($"LastName: {error.Value.LastName}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintConfirmPasswordError(Dictionary<string, ConfirmPasswordError> confirmPasswordError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("ConfirmPasswordError:");
        foreach (var error in confirmPasswordError)
        {
            outputBuilder.AppendLine($"ConfirmPassword: {error.Value.ConfirmPassword}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintPasswordDetailsError(Dictionary<string, PasswordDetailsError> passwordDetailsError)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("PasswordDetailsError:");
        foreach (var error in passwordDetailsError)
        {
            outputBuilder.AppendLine($"NewPassword: {error.Value.NewPassword},");
            outputBuilder.AppendLine($"ConfirmPassword: {error.Value.ConfirmPassword}");
        }
        Console.Write(outputBuilder.ToString());
    }

    public static void PrintLoginContent(LoginContent loginContent)
    {
        outputBuilder = new();
        
        outputBuilder.AppendLine("TesyLoginResponse:\n{");
        outputBuilder.AppendLine($"  UserID: {loginContent.UserID},");
        outputBuilder.AppendLine($"  Password: {loginContent.Password},");
        outputBuilder.AppendLine($"  Email: {loginContent.Email},");
        outputBuilder.AppendLine($"  FirstName: {loginContent.FirstName},");
        outputBuilder.AppendLine($"  LastName: {loginContent.LastName},");
        outputBuilder.AppendLine($"  Language: {loginContent.Language},");
        outputBuilder.AppendLine($"  DebugMenu: {loginContent.DebugMenu ?? "null"},");
        outputBuilder.AppendLine($"  Token: {loginContent.Token}");
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintUpdateDeviceSettingsContent(UpdateDeviceSettingsContent updateDeviceSettingsContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyUpdateDeviceSettingsResponse:\n{");
        outputBuilder.AppendLine($"  Success: {updateDeviceSettingsContent.Success},");
        outputBuilder.AppendLine($"  Message: \"{updateDeviceSettingsContent.Message}\"");
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintUpdateUserAccountSettingsContent(UpdateUserAccountSettingsContent updateUserAccountSettingsContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyUpdateUserAccountSettingsResponse:\n{");
        outputBuilder.AppendLine($"  Success: {updateUserAccountSettingsContent.Success}");
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintUpdateUserPasswordSettingsContent(UpdateUserPasswordSettingsContent updateUserPasswordSettingsContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyUpdateUserPasswordSettingsResponse:\n{");
        outputBuilder.AppendLine($"  Success: {updateUserPasswordSettingsContent.Success}");
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintUserAccountDetails(UserInfoContent userInfoContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("\nAccount details:");
        outputBuilder.AppendLine($"Email: {userInfoContent.Email}");
        outputBuilder.AppendLine($"First name: {userInfoContent.FirstName}");
        outputBuilder.AppendLine($"Last name: {userInfoContent.LastName}");
        foreach (var language in languages)
        {
            if (language.Value.Equals(userInfoContent.Language))
            {
                outputBuilder.AppendLine($"Language: {language.Key}");
            }
        }

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintUserInfoContent(UserInfoContent userInfoContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyUserInfoResponse:\n{");
        outputBuilder.AppendLine($"  Email: {userInfoContent.Email},");
        outputBuilder.AppendLine($"  FirstName: {userInfoContent.FirstName},");
        outputBuilder.AppendLine($"  LastName: {userInfoContent.LastName},");
        outputBuilder.AppendLine($"  Language: {userInfoContent.Language}");
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintMyDevicesContent(Dictionary<string, MyDevicesContent> myDevicesContent, DeviceTime deviceTimeContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyMyDevicesResponse:\n{");
        foreach (var deviceParam in myDevicesContent)
        {
            outputBuilder.AppendLine($"  {deviceParam.Key}: {{");
            outputBuilder.AppendLine($"    HasInternet: {deviceParam.Value.HasInternet},");
            outputBuilder.AppendLine($"    HttpAddr: \"{deviceParam.Value.HttpAddr}\",");
            outputBuilder.AppendLine($"    Token: {deviceParam.Value.Token},");
            outputBuilder.AppendLine("    State: {");
            outputBuilder.AppendLine($"      Id: {deviceParam.Value.State.Id},");
            outputBuilder.AppendLine($"      Created_At: {deviceParam.Value.State.Created_At ?? "null"},");
            outputBuilder.AppendLine($"      Updated_At: \"{deviceParam.Value.State.Updated_At}\",");
            outputBuilder.AppendLine($"      Mac: {deviceParam.Value.State.Mac},");
            outputBuilder.AppendLine($"      DeviceName: {deviceParam.Value.State.DeviceName ?? "null"},");
            outputBuilder.AppendLine($"      Status: \"{deviceParam.Value.State.Status}\",");
            outputBuilder.AppendLine($"      Temp: {deviceParam.Value.State.Temp ?? "null"},");
            outputBuilder.AppendLine($"      OpenedWindow: \"{deviceParam.Value.State.OpenedWindow}\",");
            outputBuilder.AppendLine("      DelayedStart: {");
            outputBuilder.AppendLine($"\tTime: {deviceParam.Value.State.DelayedStart.Time},");
            outputBuilder.AppendLine($"\tTemp: {deviceParam.Value.State.DelayedStart.Temp}");
            outputBuilder.AppendLine("      },");
            outputBuilder.AppendLine($"      DelayedStop: {deviceParam.Value.State.DelayedStop ?? "null"},");
            outputBuilder.AppendLine($"      TCorrection: {deviceParam.Value.State.TCorrection},");
            outputBuilder.AppendLine($"      AntiFrost: \"{deviceParam.Value.State.AntiFrost}\",");
            outputBuilder.AppendLine("      ComfortTemp: {");
            outputBuilder.AppendLine($"\tTemp: {deviceParam.Value.State.ComfortTemp.Temp}");
            outputBuilder.AppendLine("      },");
            outputBuilder.AppendLine("      EcoTemp: {");
            outputBuilder.AppendLine($"\tTemp: {deviceParam.Value.State.EcoTemp.Temp},");
            outputBuilder.AppendLine($"\tTime: {deviceParam.Value.State.EcoTemp.Time}");
            outputBuilder.AppendLine("      },");
            outputBuilder.AppendLine($"      UV: \"{deviceParam.Value.State.UV}\",");
            outputBuilder.AppendLine($"      LockedDevice: \"{deviceParam.Value.State.LockedDevice}\",");
            outputBuilder.AppendLine($"      Watt: {deviceParam.Value.State.Watt},");
            outputBuilder.AppendLine("      Program: {");
            foreach (var program in deviceParam.Value.State.DeviceProgram)
            {
                outputBuilder.AppendLine($"\t\"{program.Key}\": {{");
                outputBuilder.AppendLine($"\t  Day: {program.Value.Day},");
                outputBuilder.AppendLine($"\t  From: \"{program.Value.From}\",");
                outputBuilder.AppendLine($"\t  To: \"{program.Value.To}\",");
                outputBuilder.AppendLine($"\t  Temp: {program.Value.Temp},");
                outputBuilder.AppendLine($"\t  Program_Number: \"{program.Value.Program_Number}\"");
                outputBuilder.AppendLine("\t},");
            }
            outputBuilder.AppendLine("      },");
            outputBuilder.AppendLine($"      For_Test: {deviceParam.Value.State.For_Test ?? "null"},");
            outputBuilder.AppendLine($"      CurrentTemp: {deviceParam.Value.State.CurrentTemp},");
            outputBuilder.AppendLine($"      AdaptiveStart: \"{deviceParam.Value.State.AdaptiveStart}\",");
            outputBuilder.AppendLine($"      ProgramStatus: {deviceParam.Value.State.ProgramStatus ?? "null"},");
            outputBuilder.AppendLine($"      Mode: \"{deviceParam.Value.State.Mode}\",");
            outputBuilder.AppendLine($"      Heating: \"{deviceParam.Value.State.Heating}\",");
            outputBuilder.AppendLine("      SleepMode: {");
            outputBuilder.AppendLine($"\tTime: {deviceParam.Value.State.SleepMode.Time}");
            outputBuilder.AppendLine("      },");
            outputBuilder.AppendLine($"      Target: {deviceParam.Value.State.Target},");
            outputBuilder.AppendLine($"      TimeRemaining: {deviceParam.Value.State.TimeRemaining},");
            outputBuilder.AppendLine($"      ModeTime: {deviceParam.Value.State.ModeTime}");
            outputBuilder.AppendLine("    },");
            outputBuilder.AppendLine($"    Model: {deviceParam.Value.Model},");
            outputBuilder.AppendLine($"    Model_id: {deviceParam.Value.Model_Id},");
            outputBuilder.AppendLine($"    Model_Type: \"{deviceParam.Value.Model_Type}\",");
            outputBuilder.AppendLine($"    Model_Watt: \"{deviceParam.Value.Model_Watt}\",");
            outputBuilder.AppendLine($"    Model_Image: \"{deviceParam.Value.Model_Image}\",");
            outputBuilder.AppendLine($"    Model_Image_Main: \"{deviceParam.Value.Model_Image_Main}\",");
            outputBuilder.AppendLine($"    Ip: {deviceParam.Value.IP},");
            outputBuilder.AppendLine($"    City: {deviceParam.Value.City},");
            outputBuilder.AppendLine($"    Country: {deviceParam.Value.Country},");
            outputBuilder.AppendLine($"    Continent: {deviceParam.Value.Continent},");
            outputBuilder.AppendLine($"    Timezone: {deviceParam.Value.Timezone},");
            outputBuilder.AppendLine("    Time: {");
            outputBuilder.AppendLine($"      Date: \"{deviceTimeContent.Date}\",");
            outputBuilder.AppendLine($"      Time: \"{deviceTimeContent.Time}\"");
            outputBuilder.AppendLine("    },");
            outputBuilder.AppendLine($"    DeviceName: \"{deviceParam.Value.DeviceName}\",");
            outputBuilder.AppendLine($"    Wifi_SSID: {deviceParam.Value.Wifi_SSID},");
            outputBuilder.AppendLine($"    Wifi_Pass: {deviceParam.Value.Wifi_Pass},");
            outputBuilder.AppendLine($"    FirmwareVersion: {deviceParam.Value.FirmwareVersion},");
            outputBuilder.AppendLine($"    Ap_Pass: {deviceParam.Value.Ap_Pass},");
            outputBuilder.AppendLine($"    LocalUsage: {deviceParam.Value.LocalUsage},");
            outputBuilder.AppendLine($"    WaitingForConnection: {deviceParam.Value.WaitingForConnection}");
            outputBuilder.AppendLine("  }");
        }
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintDeviceTempStatContent(DeviceTempStatContent deviceTempStatContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("DeviceTempStat:\n{");
        outputBuilder.AppendLine($"    Data: [{deviceTempStatContent.Data}],");
        outputBuilder.AppendLine("    Period: [");
        foreach (var periodParam in deviceTempStatContent.Period)
        {
            outputBuilder.AppendLine($"\t\"{periodParam}\",");
        }
        outputBuilder.AppendLine("    ]");
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintDevicePowerStatContent(DevicePowerStatContent[] devicePowerStatContent)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("DevicePowerStat:\n[");
        foreach (var powerStatParam in devicePowerStatContent)
        {
            outputBuilder.AppendLine("    {");
            outputBuilder.AppendLine($"\tSubLabel: \"{powerStatParam.SubLabel}\",");
            outputBuilder.AppendLine($"\tMainLabel: \"{powerStatParam.MainLabel}\",");
            outputBuilder.AppendLine($"\tConsumption: {powerStatParam.Consumption},");
            outputBuilder.AppendLine($"\tWorkingTime: \"{powerStatParam.WorkingTime}\"");
            outputBuilder.AppendLine("    },");
        }
        outputBuilder.AppendLine("]");

        Console.Write(outputBuilder.ToString());
    }

    public static void PrintTesyDocuments(Dictionary<string, Documents> tesyDocuments)
    {
        outputBuilder = new();

        outputBuilder.AppendLine("TesyDocuments:\n{");
        foreach (var document in tesyDocuments)
        {
            outputBuilder.AppendLine($"  GroupName: {document.Value.GroupName},");
            outputBuilder.AppendLine($"  GroupImage: {document.Value.GroupImage},");
            outputBuilder.AppendLine("  Models: {");
            foreach (var model in document.Value.Models)
            {
                outputBuilder.AppendLine($"    ModelName: {model.Value.ModelName},");
                outputBuilder.AppendLine($"    ModelImage: {model.Value.ModelImage},");
                outputBuilder.AppendLine($"    ModelDocuments: {model.Value.Documents},");
                outputBuilder.AppendLine($"    DocumentLinks: {model.Value.Documents.Links},");
                outputBuilder.AppendLine("    Documents: {");
                outputBuilder.AppendLine("      Links: {");
                foreach (var modelDocumentLinks in model.Value.Documents.Links)
                {
                    outputBuilder.AppendLine("\t{");
                    outputBuilder.AppendLine($"\t  Name: {modelDocumentLinks.Value.Name},");
                    outputBuilder.AppendLine($"\t  Link: {modelDocumentLinks.Value.Link}");
                    outputBuilder.AppendLine("\t}");
                }
                outputBuilder.AppendLine("      }");
                outputBuilder.AppendLine("    }");
            }
            outputBuilder.AppendLine("  }");
        }
        outputBuilder.AppendLine("}");

        Console.Write(outputBuilder.ToString());
    }
}