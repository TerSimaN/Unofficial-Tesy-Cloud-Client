using System.Text.Json.Serialization;

public record class ConvectorSetLockDeviceContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetLockDevicePayloadContent Payload
);

public record class ConvectorSetLockDevicePayloadContent (
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("app_id")] short AppId
);