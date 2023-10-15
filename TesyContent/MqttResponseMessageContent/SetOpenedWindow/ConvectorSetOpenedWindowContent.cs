using System.Text.Json.Serialization;

public record class ConvectorSetOpenedWindowContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetOpenedWindowPayloadContent Payload
);

public record class ConvectorSetOpenedWindowPayloadContent (
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("app_id")] short AppId
);