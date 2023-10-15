using System.Text.Json.Serialization;

public record class ConvectorSetComfortTempContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetComfortTempPayloadContent Payload
);

public record class ConvectorSetComfortTempPayloadContent (
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("app_id")] short AppId
);