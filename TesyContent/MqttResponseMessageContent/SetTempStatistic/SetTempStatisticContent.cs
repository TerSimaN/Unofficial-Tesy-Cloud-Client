using System.Text.Json.Serialization;

public record class SetTempStatisticContent (
    [property: JsonPropertyName("code")] short Code,
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("app_id")] short AppId,
    [property: JsonPropertyName("command")] string Command,
    [property: JsonPropertyName("payload")] SetTempStatisticPayloadContent Payload
);