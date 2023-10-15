using System.Text;

public static class ContentBuilder
{
    private static StringBuilder? builder;

    public static string BuildCredentialsErrorString(Dictionary<string, CredentialsError> credentialsError)
    {
        builder = new();

        builder.AppendLine("CredentialsError:");
        foreach (var error in credentialsError)
        {
            builder.AppendLine($"Email: {error.Value.Email[0]},");
            builder.AppendLine($"Password: {error.Value.Password[0]}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildEmailErrorString(Dictionary<string, EmailError> emailError)
    {
        builder = new();

        builder.AppendLine("EmailError:");
        foreach (var error in emailError)
        {
            builder.AppendLine($"Email: {error.Value.Email[0]}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildPasswordErrorString(Dictionary<string, PasswordError> passwordError)
    {
        builder = new();

        builder.AppendLine("PasswordError:");
        foreach (var error in passwordError)
        {
            builder.AppendLine($"Password: {error.Value.Password[0]}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildGlobalErrorString(Dictionary<string, GlobalError> globalError)
    {
        builder = new();

        builder.AppendLine("GlobalError:");
        foreach (var error in globalError)
        {
            builder.AppendLine($"Global: {error.Value.Global}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildNoMatchFoundInRecordsErrorString(NoMatchFoundInRecordsError noMatchFoundInRecordsError)
    {
        builder = new();

        builder.AppendLine("NoMatchFoundInRecordsError:");
        builder.AppendLine($"Error: {noMatchFoundInRecordsError.Error}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildNameErrorString(Dictionary<string, NameError> nameError)
    {
        builder = new();

        builder.AppendLine("NameError:");
        foreach (var error in nameError)
        {
            builder.AppendLine($"Name: {error.Value.Name[0]}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildLastNameErrorString(Dictionary<string, LastNameError> lastNameError)
    {
        builder = new();

        builder.AppendLine("LastNameError:");
        foreach (var error in lastNameError)
        {
            builder.AppendLine($"LastName: {error.Value.LastName[0]}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAccountDetailsErrorString(Dictionary<string, AccountDetailsError> accountDetailsError)
    {
        builder = new();

        builder.AppendLine("AccountDetailsError:");
        foreach (var error in accountDetailsError)
        {
            builder.AppendLine($"Email: {error.Value.Email},");
            builder.AppendLine($"Name: {error.Value.Name},");
            builder.AppendLine($"LastName: {error.Value.LastName}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConfirmPasswordErrorString(Dictionary<string, ConfirmPasswordError> confirmPasswordError)
    {
        builder = new();

        builder.AppendLine("ConfirmPasswordError:");
        foreach (var error in confirmPasswordError)
        {
            builder.AppendLine($"ConfirmPassword: {error.Value.ConfirmPassword}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildPasswordDetailsErrorString(Dictionary<string, PasswordDetailsError> passwordDetailsError)
    {
        builder = new();

        builder.AppendLine("PasswordDetailsError:");
        foreach (var error in passwordDetailsError)
        {
            builder.AppendLine($"NewPassword: {error.Value.NewPassword},");
            builder.AppendLine($"ConfirmPassword: {error.Value.ConfirmPassword}");
        }
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildLoginContentString(LoginContent loginContent)
    {
        builder = new();

        builder.AppendLine("TesyLoginResponse:\n{");
        builder.AppendLine($"  UserID: {loginContent.UserID},");
        builder.AppendLine($"  Password: {loginContent.Password},");
        builder.AppendLine($"  Email: {loginContent.Email},");
        builder.AppendLine($"  FirstName: {loginContent.FirstName},");
        builder.AppendLine($"  LastName: {loginContent.LastName},");
        builder.AppendLine($"  Language: {loginContent.Language},");
        builder.AppendLine($"  DebugMenu: {loginContent.DebugMenu ?? "null"},");
        builder.AppendLine($"  Token: {loginContent.Token}");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildUpdateDeviceSettingsContentString(UpdateDeviceSettingsContent updateDeviceSettingsContent)
    {
        builder = new();

        builder.AppendLine("TesyUpdateDeviceSettingsResponse:\n{");
        builder.AppendLine($"  Success: {updateDeviceSettingsContent.Success},");
        builder.AppendLine($"  Message: \"{updateDeviceSettingsContent.Message}\"");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildUpdateUserAccountSettingsContentString(UpdateUserAccountSettingsContent updateUserAccountSettingsContent)
    {
        builder = new();

        builder.AppendLine("TesyUpdateUserAccountSettingsResponse:\n{");
        builder.AppendLine($"  Success: {updateUserAccountSettingsContent.Success}");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildUpdateUserPasswordSettingsContentString(UpdateUserPasswordSettingsContent updateUserPasswordSettingsContent)
    {
        builder = new();

        builder.AppendLine("TesyUpdateUserPasswordSettingsResponse:\n{");
        builder.AppendLine($"  Success: {updateUserPasswordSettingsContent.Success}");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildUserInfoContentString(UserInfoContent userInfoContent)
    {
        builder = new();

        builder.AppendLine("TesyUserInfoResponse:\n{");
        builder.AppendLine($"  Email: {userInfoContent.Email},");
        builder.AppendLine($"  FirstName: {userInfoContent.FirstName},");
        builder.AppendLine($"  LastName: {userInfoContent.LastName},");
        builder.AppendLine($"  Language: {userInfoContent.Language}");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    /// <summary>
    /// Builds a string containing TesyMyDevicesContentResponse.
    /// </summary>
    /// <param name="myDevicesContent">The <c>myDevicesContentResponse</c> to append.</param>
    /// <param name="deviceTimeContent">The <c>deviceTimeContentResponse</c> to append.</param>
    /// <returns>The string containing TesyMyDevicesContentResponse.</returns>
    public static string BuildMyDevicesContentString(Dictionary<string, MyDevicesContent> myDevicesContent, DeviceTime deviceTimeContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("TesyMyDevicesResponse:\n{");
        foreach (var deviceParam in myDevicesContent)
        {
            builder.AppendLine($"  {deviceParam.Key}: {{");
            builder.AppendLine($"    HasInternet: {deviceParam.Value.HasInternet},");
            builder.AppendLine($"    HttpAddr: \"{deviceParam.Value.HttpAddr}\",");
            builder.AppendLine($"    Token: {deviceParam.Value.Token},");
            builder.AppendLine("    State: {");
            builder.AppendLine($"      Id: {deviceParam.Value.State.Id},");
            builder.AppendLine($"      Created_At: {deviceParam.Value.State.Created_At ?? "null"},");
            builder.AppendLine($"      Updated_At: \"{deviceParam.Value.State.Updated_At}\",");
            builder.AppendLine($"      Mac: {deviceParam.Value.State.Mac},");
            builder.AppendLine($"      DeviceName: {deviceParam.Value.State.DeviceName ?? "null"},");
            builder.AppendLine($"      Status: \"{deviceParam.Value.State.Status}\",");
            builder.AppendLine($"      Temp: {deviceParam.Value.State.Temp ?? "null"},");
            builder.AppendLine($"      OpenedWindow: \"{deviceParam.Value.State.OpenedWindow}\",");
            builder.AppendLine("      DelayedStart: {");
            builder.AppendLine($"        Time: {deviceParam.Value.State.DelayedStart.Time},");
            builder.AppendLine($"        Temp: {deviceParam.Value.State.DelayedStart.Temp}");
            builder.AppendLine("      },");
            builder.AppendLine($"      DelayedStop: {deviceParam.Value.State.DelayedStop ?? "null"},");
            builder.AppendLine($"      TCorrection: {deviceParam.Value.State.TCorrection},");
            builder.AppendLine($"      AntiFrost: \"{deviceParam.Value.State.AntiFrost}\",");
            builder.AppendLine("      ComfortTemp: {");
            builder.AppendLine($"        Temp: {deviceParam.Value.State.ComfortTemp.Temp}");
            builder.AppendLine("      },");
            builder.AppendLine("      EcoTemp: {");
            builder.AppendLine($"        Temp: {deviceParam.Value.State.EcoTemp.Temp},");
            builder.AppendLine($"        Time: {deviceParam.Value.State.EcoTemp.Time}");
            builder.AppendLine("      },");
            builder.AppendLine($"      UV: \"{deviceParam.Value.State.UV}\",");
            builder.AppendLine($"      LockedDevice: \"{deviceParam.Value.State.LockedDevice}\",");
            builder.AppendLine($"      Watt: {deviceParam.Value.State.Watt},");
            builder.AppendLine("      Program: {");
            if (deviceParam.Value.State.DeviceProgram != null)
            {
                foreach (var program in deviceParam.Value.State.DeviceProgram)
                {
                    builder.AppendLine($"        \"{program.Key}\": {{");
                    builder.AppendLine($"          Day: {program.Value.Day},");
                    builder.AppendLine($"          From: \"{program.Value.From}\",");
                    builder.AppendLine($"          To: \"{program.Value.To}\",");
                    builder.AppendLine($"          Temp: {program.Value.Temp},");
                    builder.AppendLine($"          Program_Number: \"{program.Value.Program_Number}\"");
                    builder.AppendLine("        },");
                }
            }
            builder.AppendLine("      },");
            builder.AppendLine($"      For_Test: {deviceParam.Value.State.For_Test ?? "null"},");
            builder.AppendLine($"      CurrentTemp: {deviceParam.Value.State.CurrentTemp},");
            builder.AppendLine($"      AdaptiveStart: \"{deviceParam.Value.State.AdaptiveStart}\",");
            builder.AppendLine($"      ProgramStatus: {deviceParam.Value.State.ProgramStatus ?? "null"},");
            builder.AppendLine($"      Mode: \"{deviceParam.Value.State.Mode}\",");
            builder.AppendLine($"      Heating: \"{deviceParam.Value.State.Heating}\",");
            builder.AppendLine("      SleepMode: {");
            builder.AppendLine($"        Time: {deviceParam.Value.State.SleepMode.Time}");
            builder.AppendLine("      },");
            builder.AppendLine($"      Target: {deviceParam.Value.State.Target},");
            builder.AppendLine($"      TimeRemaining: {deviceParam.Value.State.TimeRemaining},");
            builder.AppendLine($"      ModeTime: {deviceParam.Value.State.ModeTime}");
            builder.AppendLine("    },");
            builder.AppendLine($"    Model: {deviceParam.Value.Model},");
            builder.AppendLine($"    Model_id: {deviceParam.Value.Model_Id},");
            builder.AppendLine($"    Model_Type: \"{deviceParam.Value.Model_Type}\",");
            builder.AppendLine($"    Model_Watt: \"{deviceParam.Value.Model_Watt}\",");
            builder.AppendLine($"    Model_Image: \"{deviceParam.Value.Model_Image}\",");
            builder.AppendLine($"    Model_Image_Main: \"{deviceParam.Value.Model_Image_Main}\",");
            builder.AppendLine($"    Ip: {deviceParam.Value.IP},");
            builder.AppendLine($"    City: {deviceParam.Value.City},");
            builder.AppendLine($"    Country: {deviceParam.Value.Country},");
            builder.AppendLine($"    Continent: {deviceParam.Value.Continent},");
            builder.AppendLine($"    Timezone: {deviceParam.Value.Timezone},");
            builder.AppendLine("    Time: {");
            builder.AppendLine($"      Date: \"{deviceTimeContent.Date}\",");
            builder.AppendLine($"      Time: \"{deviceTimeContent.Time}\"");
            builder.AppendLine("    },");
            builder.AppendLine($"    DeviceName: \"{deviceParam.Value.DeviceName}\",");
            builder.AppendLine($"    Wifi_SSID: {deviceParam.Value.Wifi_SSID},");
            builder.AppendLine($"    Wifi_Pass: {deviceParam.Value.Wifi_Pass},");
            builder.AppendLine($"    FirmwareVersion: {deviceParam.Value.FirmwareVersion},");
            builder.AppendLine($"    Ap_Pass: {deviceParam.Value.Ap_Pass},");
            builder.AppendLine($"    LocalUsage: {deviceParam.Value.LocalUsage},");
            builder.AppendLine($"    WaitingForConnection: {deviceParam.Value.WaitingForConnection}");
            builder.AppendLine("  }");
        }
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildDeviceTempStatContentString(DeviceTempStatContent deviceTempStatContent)
    {
        builder = new();

        builder.AppendLine("DeviceTempStat:\n{");
        builder.AppendLine("    Data: [");
        foreach (var dataParam in deviceTempStatContent.Data)
        {
            builder.AppendLine("      {");
            builder.AppendLine($"        Time: {dataParam.Time},");
            builder.AppendLine($"        Real: {dataParam.Real},");
            builder.AppendLine($"        Target: {dataParam.Target}");
            builder.AppendLine("      },");
        }
        builder.AppendLine("    ],");
        builder.AppendLine("    Period: [");
        foreach (var periodParam in deviceTempStatContent.Period)
        {
            builder.AppendLine($"        {periodParam},");
        }
        builder.AppendLine("    ]");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildDevicePowerStatContentString(DevicePowerStatContent[] devicePowerStatContent)
    {
        builder = new();

        builder.AppendLine("DevicePowerStat:\n[");
        foreach (var powerStatParam in devicePowerStatContent)
        {
            builder.AppendLine("    {");
            builder.AppendLine($"        SubLabel: \"{powerStatParam.SubLabel}\",");
            builder.AppendLine($"        MainLabel: \"{powerStatParam.MainLabel}\",");
            builder.AppendLine($"        Consumption: {powerStatParam.Consumption},");
            builder.AppendLine($"        WorkingTime: \"{powerStatParam.WorkingTime}\"");
            builder.AppendLine("    },");
        }
        builder.AppendLine("]");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildTesyDocumentsContentString(Dictionary<string, Documents> tesyDocuments)
    {
        builder = new();

        builder.AppendLine("TesyDocuments:\n{");
        foreach (var document in tesyDocuments)
        {
            builder.AppendLine($"  GroupName: {document.Value.GroupName},");
            builder.AppendLine($"  GroupImage: {document.Value.GroupImage},");
            builder.AppendLine("  Models: {");
            foreach (var model in document.Value.Models)
            {
                builder.AppendLine($"    ModelName: {model.Value.ModelName},");
                builder.AppendLine($"    ModelImage: {model.Value.ModelImage},");
                builder.AppendLine($"    ModelDocuments: {model.Value.Documents},");
                builder.AppendLine($"    DocumentLinks: {model.Value.Documents.Links},");
                builder.AppendLine("    Documents: {");
                builder.AppendLine("      Links: {");
                foreach (var modelDocumentLinks in model.Value.Documents.Links)
                {
                    builder.AppendLine("        {");
                    builder.AppendLine($"          Name: {modelDocumentLinks.Value.Name},");
                    builder.AppendLine($"          Link: {modelDocumentLinks.Value.Link}");
                    builder.AppendLine("        }");
                }
                builder.AppendLine("      }");
                builder.AppendLine("    }");
            }
            builder.AppendLine("  }");
        }
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");
        
        return builder.ToString();
    }
}