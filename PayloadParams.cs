class ProgramParams
{
    public int Day { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
    public int Temp { get; set; }
    public string? Program_number { get; set; }
}

class ProgramNumberParams
{
    public string? Program_number { get; set; }
}

class OnOffParams
{
    public string? Status { get; set; }
}

class UVParams
{
    public string? Status { get; set; }
}

class LockedDeviceParams
{
    public string? Status { get; set; }
}

class OpenedWindowParams
{
    public string? Status { get; set; }
}

class AntiFrostParams
{
    public string? Status { get; set; }
}

class AdaptiveStartParams
{
    public string? Status { get; set; }
}

class DeviceTempParams
{
    public short Temp { get; set; }
}

class ModeParams
{
    public string? Name { get; set; }
}

class EcoTempParams
{
    public short Temp { get; set; }
    public int Time { get; set; }
}

class ComfortTempParams
{
    public short Temp { get; set; }
}

class SleepModeParams
{
    public int Time { get; set; }
}

class DelayedStartParams
{
    public int Time { get; set; }
    public short Temp { get; set; }
}

class DeviceWifiParams
{
    public string? WifiSSID { get; set; }
    public string? WifiPass { get; set; }
}

class TCorrectionParams
{
    public short Temp { get; set; }
}

class TimeZoneParams
{
    public short Day { get; set; }
    public string? Time { get; set; }
}

class CredentialsParams
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}