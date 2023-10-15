using System.Text.Json.Serialization;

public record class ConvectorSetModeContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetModePayloadContent Payload
);

public record class ConvectorSetModePayloadContent (
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("app_id")] short AppId 
);