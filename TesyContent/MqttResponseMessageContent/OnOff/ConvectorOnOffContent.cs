using System.Text.Json.Serialization;

public record class ConvectorOnOffContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorOnOffPayloadContent Paload
);

public record class ConvectorOnOffPayloadContent (
    [property: JsonPropertyName("status")] string Status,
	[property: JsonPropertyName("app_id")] short AppId
);