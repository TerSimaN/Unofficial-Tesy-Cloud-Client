using System.Text.Json.Serialization;

public record class UpdateUserAccountSettingsContent (
    [property: JsonPropertyName("success")] bool Success
);