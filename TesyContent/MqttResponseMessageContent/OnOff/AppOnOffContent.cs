using System.Text.Json.Serialization;

public record class AppOnOffContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppOnOffPayloadContent Paload
);

public record class AppOnOffPayloadContent (
    [property: JsonPropertyName("status")] string Status 
);