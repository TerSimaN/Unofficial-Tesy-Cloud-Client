using System.Text.Json.Serialization;

public record class GetStatusContent (
    [property: JsonPropertyName("code")] short Code,
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("app_id")] string AppId,
    [property: JsonPropertyName("command")] string Command,
    [property: JsonPropertyName("payload")] GetStatusPayloadContent Payload
);