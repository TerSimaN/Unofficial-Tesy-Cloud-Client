using System.Text.Json.Serialization;

namespace Tesy.Content
{
    public record class UpdateUserAccountSettingsContent (
        [property: JsonPropertyName("success")] bool Success
    );
}