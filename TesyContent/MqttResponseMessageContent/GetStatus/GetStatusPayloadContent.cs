using System.Text.Json.Serialization;

public record class GetStatusPayloadContent (
    [property: JsonPropertyName("onOff")] GetStatusOnOffPayload OnOff,
    [property: JsonPropertyName("setMode")] GetStatusSetModePayload SetMode,
    [property: JsonPropertyName("setTemp")] GetStatusSetTempPayload SetTemp,
    [property: JsonPropertyName("setAdaptiveStart")] GetStatusSetAdaptiveStartPayload SetAdaptiveStart,
    [property: JsonPropertyName("setOpenedWindow")] GetStatusSetOpenedWindowPayload SetOpenedWindow,
    [property: JsonPropertyName("setDelayedStart")] GetStatusSetDelayedStartPayload SetDelayedStart,
    [property: JsonPropertyName("setTCorrection")] GetStatusSetTCorrectionPayload SetTCorrection,
    [property: JsonPropertyName("setAntiFrost")] GetStatusSetAntiFrostPayload SetAntiFrost,
    [property: JsonPropertyName("setComfortTemp")] GetStatusSetComfortTempPayload SetComfortTemp,
    [property: JsonPropertyName("setEcoTemp")] GetStatusSetEcoTempPayload SetEcoTemp,
    [property: JsonPropertyName("setSleepTemp")] GetStatusSetSleepTempPayload SetSleepTemp,
    [property: JsonPropertyName("setUV")] GetStatusSetUVPayload SetUV,
    [property: JsonPropertyName("setLockDevice")] GetStatusSetLockDevicePayload SetLockDevice
);