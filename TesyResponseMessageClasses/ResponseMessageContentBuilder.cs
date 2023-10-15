using System.Text;

public static class ResponseMessageContentBuilder
{
    private static StringBuilder? builder;

    public static string BuildGetStatusContentString(GetStatusContent getStatusContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App GetStatus:\n{");
        builder.AppendLine($"  Code: {getStatusContent.Code},");
        builder.AppendLine($"  Message: \"{getStatusContent.Message}\",");
        builder.AppendLine($"  AppId: \"{getStatusContent.AppId}\",");
        builder.AppendLine($"  Command: \"{getStatusContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine("    OnOff: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Status: \"{getStatusContent.Payload.OnOff.Payload.Status}\"");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetMode: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Name: \"{getStatusContent.Payload.SetMode.Payload.Name}\"");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetTemp: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Temp: {getStatusContent.Payload.SetTemp.Payload.Temp}");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetAdaptiveStart: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Status: \"{getStatusContent.Payload.SetAdaptiveStart.Payload.Status}\"");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetOpenedWindow: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Status: \"{getStatusContent.Payload.SetOpenedWindow.Payload.Status}\"");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetDelayedStart: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Status: \"{getStatusContent.Payload.SetDelayedStart.Payload.Status}\",");
        builder.AppendLine($"        Time: {getStatusContent.Payload.SetDelayedStart.Payload.Time},");
        builder.AppendLine($"        Temp: {getStatusContent.Payload.SetDelayedStart.Payload.Temp},");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetTCorrection: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Temp: {getStatusContent.Payload.SetTCorrection.Payload.Temp}");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetAntiFrost: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Status: \"{getStatusContent.Payload.SetAntiFrost.Payload.Status}\"");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetComfortTemp: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Temp: {getStatusContent.Payload.SetComfortTemp.Payload.Temp}");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetEcoTemp: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Temp: {getStatusContent.Payload.SetEcoTemp.Payload.Temp},");
        builder.AppendLine($"        Time: {getStatusContent.Payload.SetEcoTemp.Payload.Time}");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetSleepTemp: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Temp: {getStatusContent.Payload.SetSleepTemp.Payload.Temp},");
        builder.AppendLine($"        Time: {getStatusContent.Payload.SetSleepTemp.Payload.Time}");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetUV: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Status: \"{getStatusContent.Payload.SetUV.Payload.Status}\"");
        builder.AppendLine("      }");
        builder.AppendLine("    },");
        builder.AppendLine("    SetLockDevice: {");
        builder.AppendLine("      Payload: {");
        builder.AppendLine($"        Status: \"{getStatusContent.Payload.SetLockDevice.Payload.Status}\"");
        builder.AppendLine("      }");
        builder.AppendLine("    }");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildSetTempStatisticContentString(SetTempStatisticContent setTempStatisticContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetTempStatistic:\n{");
        builder.AppendLine($"  Code: {setTempStatisticContent.Code},");
        builder.AppendLine($"  Message: \"{setTempStatisticContent.Message}\",");
        builder.AppendLine($"  AppId: \"{setTempStatisticContent.AppId}\",");
        builder.AppendLine($"  Command: \"{setTempStatisticContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    AppId: {setTempStatisticContent.Payload.AppId},");
        builder.AppendLine($"    Target: {setTempStatisticContent.Payload.Target},");
        builder.AppendLine($"    TimeRemaining: {setTempStatisticContent.Payload.TimeRemaining},");
        builder.AppendLine($"    CurrentTemp: {setTempStatisticContent.Payload.CurrentTemp},");
        builder.AppendLine($"    Command: \"{setTempStatisticContent.Payload.Command}\",");
        builder.AppendLine($"    Heating: \"{setTempStatisticContent.Payload.Heating}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppOnOffContentString(AppOnOffContent appOnOffContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App OnOff:\n{");
        builder.AppendLine($"  Code: {appOnOffContent.Code},");
        builder.AppendLine($"  Message: \"{appOnOffContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appOnOffContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appOnOffContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{appOnOffContent.Paload.Status}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorOnOffContentString(ConvectorOnOffContent convectorOnOffContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector OnOff:\n{");
        builder.AppendLine($"  Code: {convectorOnOffContent.Code},");
        builder.AppendLine($"  Message: \"{convectorOnOffContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorOnOffContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorOnOffContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{convectorOnOffContent.Paload.Status}\",");
        builder.AppendLine($"    AppId: {convectorOnOffContent.Paload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetAntiFrostContentString(AppSetAntiFrostContent appSetAntiFrostContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetAntiFrost:\n{");
        builder.AppendLine($"  Code: {appSetAntiFrostContent.Code},");
        builder.AppendLine($"  Message: \"{appSetAntiFrostContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetAntiFrostContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetAntiFrostContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{appSetAntiFrostContent.Payload.Status}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetAntiFrostContentString(ConvectorSetAntiFrostContent convectorSetAntiFrostContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetAntiFrost:\n{");
        builder.AppendLine($"  Code: {convectorSetAntiFrostContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetAntiFrostContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetAntiFrostContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetAntiFrostContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{convectorSetAntiFrostContent.Payload.Status}\",");
        builder.AppendLine($"    AppId: {convectorSetAntiFrostContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetDelayedStartContentString(AppSetDelayedStartContent appSetDelayedStartContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetDelayedStart:\n{");
        builder.AppendLine($"  Code: {appSetDelayedStartContent.Code},");
        builder.AppendLine($"  Message: \"{appSetDelayedStartContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetDelayedStartContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetDelayedStartContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Time: {appSetDelayedStartContent.Payload.Time},");
        builder.AppendLine($"    Temp: {appSetDelayedStartContent.Payload.Temp}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetDelayedStartContentString(ConvectorSetDelayedStartContent convectorSetDelayedStartContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetDelayedStart:\n{");
        builder.AppendLine($"  Code: {convectorSetDelayedStartContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetDelayedStartContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetDelayedStartContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetDelayedStartContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{convectorSetDelayedStartContent.Payload.Status}\",");
        builder.AppendLine($"    Time: {convectorSetDelayedStartContent.Payload.Time},");
        builder.AppendLine($"    AppId: {convectorSetDelayedStartContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetSleepTempContentString(AppSetSleepTempContent appSetSleepTempContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetSleepTemp:\n{");
        builder.AppendLine($"  Code: {appSetSleepTempContent.Code},");
        builder.AppendLine($"  Message: \"{appSetSleepTempContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetSleepTempContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetSleepTempContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Time: {appSetSleepTempContent.Payload.Time}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetSleepTempContentString(ConvectorSetSleepTempContent convectorSetSleepTempContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetSleepTemp:\n{");
        builder.AppendLine($"  Code: {convectorSetSleepTempContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetSleepTempContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetSleepTempContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetSleepTempContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Name: \"{convectorSetSleepTempContent.Payload.Name}\",");
        builder.AppendLine($"    AppId: {convectorSetSleepTempContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetComfortTempContentString(AppSetComfortTempContent appSetComfortTempContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetComfortTemp:\n{");
        builder.AppendLine($"  Code: {appSetComfortTempContent.Code},");
        builder.AppendLine($"  Message: \"{appSetComfortTempContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetComfortTempContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetComfortTempContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Temp: {appSetComfortTempContent.Payload.Temp}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetComfortTempContentString(ConvectorSetComfortTempContent convectorSetComfortTempContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetComfortTemp:\n{");
        builder.AppendLine($"  Code: {convectorSetComfortTempContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetComfortTempContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetComfortTempContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetComfortTempContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Temp: {convectorSetComfortTempContent.Payload.Temp},");
        builder.AppendLine($"    AppId: {convectorSetComfortTempContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetEcoTempContentString(AppSetEcoTempContent appSetEcoTempContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetEcoTemp:\n{");
        builder.AppendLine($"  Code: {appSetEcoTempContent.Code},");
        builder.AppendLine($"  Message: \"{appSetEcoTempContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetEcoTempContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetEcoTempContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Temp: {appSetEcoTempContent.Payload.Temp},");
        builder.AppendLine($"    Time: {appSetEcoTempContent.Payload.Time}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetEcoTempContentString(ConvectorSetEcoTempContent convectorSetEcoTempContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetEcoTemp:\n{");
        builder.AppendLine($"  Code: {convectorSetEcoTempContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetEcoTempContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetEcoTempContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetEcoTempContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Temp: {convectorSetEcoTempContent.Payload.Temp},");
        builder.AppendLine($"    Time: {convectorSetEcoTempContent.Payload.Time},");
        builder.AppendLine($"    AppId: {convectorSetEcoTempContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetModeContentString(AppSetModeContent appSetModeContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetMode:\n{");
        builder.AppendLine($"  Code: {appSetModeContent.Code},");
        builder.AppendLine($"  Message: \"{appSetModeContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetModeContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetModeContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Name: \"{appSetModeContent.Payload.Name}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetModeContentString(ConvectorSetModeContent convectorSetModeContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetMode:\n{");
        builder.AppendLine($"  Code: {convectorSetModeContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetModeContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetModeContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetModeContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Name: \"{convectorSetModeContent.Payload.Name}\",");
        builder.AppendLine($"    AppId: {convectorSetModeContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetTCorrectionContentString(AppSetTCorrectionContent appSetTCorrectionContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetTCorrection:\n{");
        builder.AppendLine($"  Code: {appSetTCorrectionContent.Code},");
        builder.AppendLine($"  Message: \"{appSetTCorrectionContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetTCorrectionContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetTCorrectionContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Temp: {appSetTCorrectionContent.Payload.Temp}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetTCorrectionContentString(ConvectorSetTCorrectionContent convectorSetTCorrectionContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetTCorrection:\n{");
        builder.AppendLine($"  Code: {convectorSetTCorrectionContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetTCorrectionContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetTCorrectionContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetTCorrectionContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Temp: {convectorSetTCorrectionContent.Payload.Temp},");
        builder.AppendLine($"    AppId: {convectorSetTCorrectionContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppPingContentString(AppPingContent appPingContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App Ping:\n{");
        builder.AppendLine($"  Code: {appPingContent.Code},");
        builder.AppendLine($"  Message: \"{appPingContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appPingContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appPingContent.Command}\",");
        builder.AppendLine($"  Payload: {appPingContent.Payload}");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetLockDeviceContentString(AppSetLockDeviceContent appSetLockDeviceContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetLockDevice:\n{");
        builder.AppendLine($"  Code: {appSetLockDeviceContent.Code},");
        builder.AppendLine($"  Message: \"{appSetLockDeviceContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetLockDeviceContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetLockDeviceContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{appSetLockDeviceContent.Payload.Status}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetLockDeviceContentString(ConvectorSetLockDeviceContent convectorSetLockDeviceContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetLockDevice:\n{");
        builder.AppendLine($"  Code: {convectorSetLockDeviceContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetLockDeviceContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetLockDeviceContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetLockDeviceContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{convectorSetLockDeviceContent.Payload.Status}\",");
        builder.AppendLine($"    AppId: {convectorSetLockDeviceContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetOpenedWindowContentString(AppSetOpenedWindowContent appSetOpenedWindowContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetOpenedWindow:\n{");
        builder.AppendLine($"  Code: {appSetOpenedWindowContent.Code},");
        builder.AppendLine($"  Message: \"{appSetOpenedWindowContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetOpenedWindowContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetOpenedWindowContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{appSetOpenedWindowContent.Payload.Status}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetOpenedWindowContentString(ConvectorSetOpenedWindowContent convectorSetOpenedWindowContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetOpenedWindow:\n{");
        builder.AppendLine($"  Code: {convectorSetOpenedWindowContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetOpenedWindowContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetOpenedWindowContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetOpenedWindowContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{convectorSetOpenedWindowContent.Payload.Status}\",");
        builder.AppendLine($"    AppId: {convectorSetOpenedWindowContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetAdaptiveStartContentString(AppSetAdaptiveStartContent appSetAdaptiveStartContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetAdaptiveStart:\n{");
        builder.AppendLine($"  Code: {appSetAdaptiveStartContent.Code},");
        builder.AppendLine($"  Message: \"{appSetAdaptiveStartContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetAdaptiveStartContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetAdaptiveStartContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{appSetAdaptiveStartContent.Payload.Status}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetAdaptiveStartContentString(ConvectorSetAdaptiveStartContent convectorSetAdaptiveStartContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetAdaptiveStart:\n{");
        builder.AppendLine($"  Code: {convectorSetAdaptiveStartContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetAdaptiveStartContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetAdaptiveStartContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetAdaptiveStartContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{convectorSetAdaptiveStartContent.Payload.Status}\",");
        builder.AppendLine($"    AppId: {convectorSetAdaptiveStartContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorWifiInfoContentString(ConvectorWifiInfoContent convectorWifiInfoContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector WifiInfo:\n{");
        builder.AppendLine($"  Code: {convectorWifiInfoContent.Code},");
        builder.AppendLine($"  Message: \"{convectorWifiInfoContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorWifiInfoContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorWifiInfoContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Wifiinfo: \"{convectorWifiInfoContent.Payload.WifiInfo}\",");
        builder.AppendLine($"    AppId: {convectorWifiInfoContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppGetSSIDContentString(AppGetSSIDContent appGetSSIDContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App GetSSID:\n{");
        builder.AppendLine($"  Code: {appGetSSIDContent.Code},");
        builder.AppendLine($"  Message: \"{appGetSSIDContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appGetSSIDContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appGetSSIDContent.Command}\",");
        builder.AppendLine($"  Payload: {appGetSSIDContent.Payload}");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetUVContentString(AppSetUVContent appSetUVContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetUV:\n{");
        builder.AppendLine($"  Code: {appSetUVContent.Code},");
        builder.AppendLine($"  Message: \"{appSetUVContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetUVContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetUVContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{appSetUVContent.Payload.Status}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetUVContentString(ConvectorSetUVContent convectorSetUVContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetUV:\n{");
        builder.AppendLine($"  Code: {convectorSetUVContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetUVContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetUVContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetUVContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Status: \"{convectorSetUVContent.Payload.Status}\",");
        builder.AppendLine($"    AppId: {convectorSetUVContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppSetProgramContentString(AppSetProgramContent appSetProgramContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App SetProgram:\n{");
        builder.AppendLine($"  Code: {appSetProgramContent.Code},");
        builder.AppendLine($"  Message: \"{appSetProgramContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appSetProgramContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appSetProgramContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Day: {appSetProgramContent.Payload.Day},");
        builder.AppendLine($"    From: \"{appSetProgramContent.Payload.From}\",");
        builder.AppendLine($"    To: \"{appSetProgramContent.Payload.To}\",");
        builder.AppendLine($"    Temp: {appSetProgramContent.Payload.Temp},");
        builder.AppendLine($"    ProgramNumber: \"{appSetProgramContent.Payload.ProgramNumber}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetProgramContentString(ConvectorSetProgramContent convectorSetProgramContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetProgram:\n{");
        builder.AppendLine($"  Code: {convectorSetProgramContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetProgramContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetProgramContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetProgramContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Day: {convectorSetProgramContent.Payload.Day},");
        builder.AppendLine($"    From: \"{convectorSetProgramContent.Payload.From}\",");
        builder.AppendLine($"    To: \"{convectorSetProgramContent.Payload.To}\",");
        builder.AppendLine($"    Temp: {convectorSetProgramContent.Payload.Temp},");
        builder.AppendLine($"    ProgramNumber: {convectorSetProgramContent.Payload.ProgramNumber},");
        builder.AppendLine($"    AppId: {convectorSetProgramContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorSetStatisticContentString(ConvectorSetStatisticContent convectorSetStatisticContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector SetStatistic:\n{");
        builder.AppendLine($"  Code: {convectorSetStatisticContent.Code},");
        builder.AppendLine($"  Message: \"{convectorSetStatisticContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorSetStatisticContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorSetStatisticContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    AppId: {convectorSetStatisticContent.Payload.AppId},");
        builder.AppendLine($"    Target: {convectorSetStatisticContent.Payload.Target},");
        builder.AppendLine($"    TimeRemaining: {convectorSetStatisticContent.Payload.TimeRemaining},");
        builder.AppendLine($"    CurrentTemp: {convectorSetStatisticContent.Payload.CurrentTemp},");
        builder.AppendLine($"    From: \"{convectorSetStatisticContent.Payload.From}\",");
        builder.AppendLine($"    To: \"{convectorSetStatisticContent.Payload.To}\",");
        builder.AppendLine($"    Time: {convectorSetStatisticContent.Payload.Time},");
        builder.AppendLine($"    Command: \"{convectorSetStatisticContent.Payload.Command}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppDeleteProgramContentString(AppDeleteProgramContent appDeleteProgramContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App DeleteProgram:\n{");
        builder.AppendLine($"  Code: {appDeleteProgramContent.Code},");
        builder.AppendLine($"  Message: \"{appDeleteProgramContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appDeleteProgramContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appDeleteProgramContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    ProgramNumber: \"{appDeleteProgramContent.Payload.ProgramNumber}\",");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildConvectorDeleteProgramContentString(ConvectorDeleteProgramContent convectorDeleteProgramContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("Convector DeleteProgram:\n{");
        builder.AppendLine($"  Code: {convectorDeleteProgramContent.Code},");
        builder.AppendLine($"  Message: \"{convectorDeleteProgramContent.Message}\",");
        builder.AppendLine($"  AppId: {convectorDeleteProgramContent.AppId},");
        builder.AppendLine($"  Command: \"{convectorDeleteProgramContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    ProgramNumber: {convectorDeleteProgramContent.Payload.ProgramNumber},");
        builder.AppendLine($"    AppId: {convectorDeleteProgramContent.Payload.AppId}");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppTimeResponseContentString(AppTimeResponseContent appTimeResponseContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine("App TimeResponse:\n{");
        builder.AppendLine($"  Code: {appTimeResponseContent.Code},");
        builder.AppendLine($"  Message: \"{appTimeResponseContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appTimeResponseContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appTimeResponseContent.Command}\",");
        builder.AppendLine("  Payload: {");
        builder.AppendLine($"    Day: {appTimeResponseContent.Payload.Day},");
        builder.AppendLine($"    Time: \"{appTimeResponseContent.Payload.Time}\"");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }

    public static string BuildAppDeleteAllProgramsContentString(AppDeleteAllProgramsContent appDeleteAllProgramsContent)
    {
        builder = new();
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
        string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
        string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
        
        builder.AppendLine($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond}");
        builder.AppendLine(":\n{");
        builder.AppendLine($"  Code: {appDeleteAllProgramsContent.Code},");
        builder.AppendLine($"  Message: \"{appDeleteAllProgramsContent.Message}\",");
        builder.AppendLine($"  AppId: \"{appDeleteAllProgramsContent.AppId}\",");
        builder.AppendLine($"  Command: \"{appDeleteAllProgramsContent.Command}\",");
        builder.AppendLine($"  Payload: {appDeleteAllProgramsContent.Payload}");
        builder.AppendLine("}");
        builder.AppendLine("------------------------------------------------------------");

        return builder.ToString();
    }
}