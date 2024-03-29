using System.Text.Json.Serialization;

namespace Tesy.Content.MyDevices
{
    public record class DeviceState (
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("created_at")] string Created_At,
        [property: JsonPropertyName("updated_at")] string Updated_At,
        [property: JsonPropertyName("mac")] string Mac,
        [property: JsonPropertyName("deviceName")] string DeviceName,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("temp")] object Temp,
        [property: JsonPropertyName("openedWindow")] string OpenedWindow,
        [property: JsonPropertyName("delayedStart")] DelayedStart DelayedStart,
        [property: JsonPropertyName("delayedStop")] string DelayedStop,
        [property: JsonPropertyName("TCorrection")] short TCorrection,
        [property: JsonPropertyName("antiFrost")] string AntiFrost,
        [property: JsonPropertyName("comfortTemp")] ComfortTemp ComfortTemp,
        [property: JsonPropertyName("ecoTemp")] EcoTemp EcoTemp,
        [property: JsonPropertyName("uv")] string UV,
        [property: JsonPropertyName("lockedDevice")] string LockedDevice,
        [property: JsonPropertyName("watt")] int Watt,
        [property: JsonPropertyName("program")] Dictionary<string, DeviceProgram> DeviceProgram,
        [property: JsonPropertyName("for_test")] string For_Test,
        [property: JsonPropertyName("current_temp")] float CurrentTemp,
        [property: JsonPropertyName("adaptiveStart")] string AdaptiveStart,
        [property: JsonPropertyName("programStatus")] string ProgramStatus,
        [property: JsonPropertyName("mode")] string Mode,
        [property: JsonPropertyName("heating")] string Heating,
        [property: JsonPropertyName("sleepMode")] SleepMode SleepMode,
        [property: JsonPropertyName("target")] int Target,
        [property: JsonPropertyName("timeRemaining")] int TimeRemaining,
        [property: JsonPropertyName("modeTime")] int ModeTime
    );
}