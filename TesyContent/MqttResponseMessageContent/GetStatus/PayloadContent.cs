using System.Text.Json.Serialization;

public record class GetStatusOnOffPayload (
    [property: JsonPropertyName("payload")] GetStatusOnOffPayloadContent Payload
);

public record class GetStatusOnOffPayloadContent (
    [property: JsonPropertyName("status")] string Status
);

public record class GetStatusSetModePayload (
    [property: JsonPropertyName("payload")] GetStatusSetModePayloadContent Payload
);

public record class GetStatusSetModePayloadContent (
    [property: JsonPropertyName("name")] string Name
);

public record class GetStatusSetTempPayload (
    [property: JsonPropertyName("payload")] GetStatusSetTempPayloadContent Payload
);

public record class GetStatusSetTempPayloadContent (
    [property: JsonPropertyName("temp")] short Temp
);

public record class GetStatusSetAdaptiveStartPayload (
    [property: JsonPropertyName("payload")] GetStatusSetAdaptiveStartPayloadContent Payload
);

public record class GetStatusSetAdaptiveStartPayloadContent (
    [property: JsonPropertyName("status")] string Status
);

public record class GetStatusSetOpenedWindowPayload (
    [property: JsonPropertyName("payload")] GetStatusSetOpenedWindowPayloadContent Payload
);

public record class GetStatusSetOpenedWindowPayloadContent (
    [property: JsonPropertyName("status")] string Status
);

public record class GetStatusSetDelayedStartPayload (
    [property: JsonPropertyName("payload")] GetStatusSetDelayedStartPayloadContent Payload
);

public record class GetStatusSetDelayedStartPayloadContent (
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("time")] int Time,
    [property: JsonPropertyName("temp")] short Temp
);

public record class GetStatusSetTCorrectionPayload (
    [property: JsonPropertyName("payload")] GetStatusSetTCorrectionPayloadContent Payload
);

public record class GetStatusSetTCorrectionPayloadContent (
    [property: JsonPropertyName("temp")] short Temp
);

public record class GetStatusSetAntiFrostPayload (
    [property: JsonPropertyName("payload")] GetStatusSetAntiFrostPayloadContent Payload
);

public record class GetStatusSetAntiFrostPayloadContent (
    [property: JsonPropertyName("status")] string Status
);

public record class GetStatusSetComfortTempPayload (
    [property: JsonPropertyName("payload")] GetStatusSetComfortTempPayloadContent Payload
);

public record class GetStatusSetComfortTempPayloadContent (
    [property: JsonPropertyName("temp")] short Temp
);

public record class GetStatusSetEcoTempPayload (
    [property: JsonPropertyName("payload")] GetStatusSetEcoTempPayloadContent Payload
);

public record class GetStatusSetEcoTempPayloadContent (
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("time")] int Time
);

public record class GetStatusSetSleepTempPayload (
    [property: JsonPropertyName("payload")] GetStatusSetSleepTempPayloadContent Payload
);

public record class GetStatusSetSleepTempPayloadContent (
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("time")] int Time
);

public record class GetStatusSetUVPayload (
    [property: JsonPropertyName("payload")] GetStatusSetUVPayloadContent Payload
);

public record class GetStatusSetUVPayloadContent (
    [property: JsonPropertyName("status")] string Status
);

public record class GetStatusSetLockDevicePayload (
    [property: JsonPropertyName("payload")] GetStatusSetLockDevicePayloadContent Payload
);

public record class GetStatusSetLockDevicePayloadContent (
    [property: JsonPropertyName("status")] string Status
);