using System.Text.Json.Serialization;

public record class ConvectorSetTCorrectionContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetTCorrectionPayloadContent Payload
);

public record class ConvectorSetTCorrectionPayloadContent (
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("app_id")] short AppId 
);