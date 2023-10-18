using System.Text.Json.Serialization;

namespace Tesy.Content
{
    public record class UpdateUserPasswordSettingsContent (
        [property: JsonPropertyName("success")] bool Success
    );
}