using System.Text.Json;

public class PayloadSerializer
{
    private readonly JsonSerializerOptions serializerOptions = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    /// <summary>
    /// Serializes credentials as JSON string.
    /// </summary>
    /// <param name="email">The <c>email</c> to serialize.</param>
    /// <param name="password">The <c>password</c> to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeCredentialsAsJsonString(string email, string password)
    {
        var credentialsParams = new CredentialsParams
        {
            Email = email,
            Password = password
        };

        string jsonString = JsonSerializer.Serialize(credentialsParams, serializerOptions);
        // Console.WriteLine(jsonString);

        return jsonString;
    }
    
    /// <summary>
    /// Serializes Add and Edit Week Program parameters as JSON string.
    /// </summary>
    /// <param name="createProgram">Week Program parameters to serialize.</param>
    /// <param name="programKey">Week Program <c>program_number</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeProgramParamsAsJsonPayload(CreateProgram createProgram, string programKey)
    {
        var programParamsPayload = new ProgramParams
        {
            Day = createProgram.DayOfWeek,
            From = createProgram.FromTime,
            To = createProgram.ToTime,
            Temp = createProgram.ProgramTemp,
            Program_number = programKey
        };

        string payload = JsonSerializer.Serialize(programParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }
    
    /// <summary>
    /// Serializes Delete Week Program <c>program_number</c> parameter as JSON string.
    /// </summary>
    /// <param name="programKey">Delete Week Program <c>program_number</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeProgramKeyAsJsonPayload(string programKey)
    {
        var programNumberPayload = new ProgramNumberParams
        {
            Program_number = programKey
        };

        string payload = JsonSerializer.Serialize(programNumberPayload, serializerOptions);
        Console.WriteLine(payload);
        
        return payload;
    }

    /// <summary>
    /// Serializes empty body parameters as JSON string.
    /// </summary>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeNoParamsAsJsonPayload()
    {
        var noParamsPayload = new{};

        string payload = JsonSerializer.Serialize(noParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes OnOff parameters as JSON string.
    /// </summary>
    /// <param name="onOff">onOff <c>OnOff</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeOnOffParamsAsJsonPayload(string onOff)
    {
        var onOffParamsPayload = new OnOffParams
        {
            Status = onOff
        };

        string payload = JsonSerializer.Serialize(onOffParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes UV parameters as JSON string.
    /// </summary>
    /// <param name="uv">UV <c>uv</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeUVParamsAsJsonPayload(string uv)
    {
        var uvParamsPayload = new UVParams
        {
            Status = uv
        };

        string payload = JsonSerializer.Serialize(uvParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes LockedDevice parameters as JSON string.
    /// </summary>
    /// <param name="lockedDevice">LockedDevice <c>lockedDevice</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeLockedDeviceParamsAsJsonPayload(string lockedDevice)
    {
        var lockedDeviceParamsPayload = new LockedDeviceParams
        {
            Status = lockedDevice
        };

        string payload = JsonSerializer.Serialize(lockedDeviceParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes OpenedWindow parameters as JSON string.
    /// </summary>
    /// <param name="openedWindow">OpenedWindow <c>openedWindow</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeOpenedWindowParamsAsJsonPayload(string openedWindow)
    {
        var openedWindowParamsPayload = new OpenedWindowParams
        {
            Status = openedWindow
        };

        string payload = JsonSerializer.Serialize(openedWindowParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes AntiFrost parameters as JSON string.
    /// </summary>
    /// <param name="antiFrost">AntiFrost <c>antiFrost</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeAntiFrostParamsAsJsonPayload(string antiFrost)
    {
        var antiFrostParamsPayload = new AntiFrostParams
        {
            Status = antiFrost
        };

        string payload = JsonSerializer.Serialize(antiFrostParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes AdaptiveStart parameters as JSON string.
    /// </summary>
    /// <param name="adaptiveStart">AdaptiveStart <c>adaptiveStart</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeAdaptiveStartParamsAsJsonPayload(string adaptiveStart)
    {
        var adaptiveStartParamsPayload = new AdaptiveStartParams
        {
            Status = adaptiveStart
        };

        string payload = JsonSerializer.Serialize(adaptiveStartParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes DeviceTemp parameters as JSON string.
    /// </summary>
    /// <param name="temperature">DeviceTemp <c>temperature</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeDeviceTempParamsAsJsonPayload(short temperature)
    {
        var deviceTempParamsPayload = new DeviceTempParams
        {
            Temp = temperature
        };

        string payload = JsonSerializer.Serialize(deviceTempParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes Mode parameters as JSON string.
    /// </summary>
    /// <param name="name">Mode <c>name</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeModeParamsAsJsonPayload(string name)
    {
        var modeParamsPayload = new ModeParams
        {
            Name = name
        };

        string payload = JsonSerializer.Serialize(modeParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes EcoTemp parameters as JSON string.
    /// </summary>
    /// <param name="temperature">EcoTemp <c>temp</c> parameter to serialize.</param>
    /// <param name="time">EcoTemp <c>time</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeEcoTempParamsAsJsonPayload(short temperature, int time)
    {
        var ecoTempParamsPayload = new EcoTempParams
        {
            Temp = temperature,
            Time = time
        };

        string payload = JsonSerializer.Serialize(ecoTempParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes ComfortTemp parameters as JSON string.
    /// </summary>
    /// <param name="temperature">ComfortTemp <c>temp</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeComfortTempParamsAsJsonPayload(short temperature)
    {
        var comfortTempParamsPayload = new ComfortTempParams
        {
            Temp = temperature
        };

        string payload = JsonSerializer.Serialize(comfortTempParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes SleepMode parameters as JSON string.
    /// </summary>
    /// <param name="time">SleepMode <c>time</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeSleepModeParamsAsJsonPayload(int time)
    {
        var sleepModeParamsPayload = new SleepModeParams
        {
            Time = time
        };

        string payload = JsonSerializer.Serialize(sleepModeParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes DelayedStart parameters as JSON string.
    /// </summary>
    /// <param name="time">DelayedStart <c>time</c> parameter to serialize.</param>
    /// <param name="temperature">DelayedStart <c>temp</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeDelayedStartParamsAsJsonPayload(int time, short temperature)
    {
        var delayedStartParamsPayload = new DelayedStartParams
        {
            Time = time,
            Temp = temperature
        };

        string payload = JsonSerializer.Serialize(delayedStartParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes DeviceWifi parameters as JSON string.
    /// </summary>
    /// <param name="wifi_ssid">DeviceWifi <c>wifiSSID</c> parameter to serialize.</param>
    /// <param name="wifi_pass">DeviceWifi <c>wifiPass</c> parameters to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeDeviceWifiParamsAsJsonPayload(string wifi_ssid, string wifi_pass)
    {
        var deviceWifiParamsPayload = new DeviceWifiParams
        {
            WifiSSID = wifi_ssid,
            WifiPass = wifi_pass
        };

        string payload = JsonSerializer.Serialize(deviceWifiParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes TCorrection parameters as JSON string.
    /// </summary>
    /// <param name="temperature">TCorrection <c>temp</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeTCorrectionParamsAsJsonPayload(short temperature)
    {
        var TCorrectionParamsPayload = new TCorrectionParams
        {
            Temp = temperature
        };

        string payload = JsonSerializer.Serialize(TCorrectionParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }

    /// <summary>
    /// Serializes TimeZone parameters as JSON string.
    /// </summary>
    /// <param name="day">TimeZone <c>day</c> parameter to serialize.</param>
    /// <param name="time">TimeZone <c>time</c> parameter to serialize.</param>
    /// <returns>Serialized JSON string.</returns>
    public string SerializeTimeZoneParamsAsJsonPayload(short day, string time, string timeZone, string date)
    {
        var timeZoneParamsPayload = new TimeZoneParams
        {
            Day = day,
            Time = time
        };

        string payload = JsonSerializer.Serialize(timeZoneParamsPayload, serializerOptions);
        Console.WriteLine(payload);

        return payload;
    }
}