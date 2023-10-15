using System.Text.Json.Serialization;

public record class UpdateUserPasswordSettingsContent (
    [property: JsonPropertyName("success")] bool Success
);