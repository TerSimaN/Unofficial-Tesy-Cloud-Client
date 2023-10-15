using System.Text.Json.Serialization;

public record class AppSetLockDeviceContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetLockDevicePayloadContent Payload
);

public record class AppSetLockDevicePayloadContent (
	[property: JsonPropertyName("status")] string Status
);