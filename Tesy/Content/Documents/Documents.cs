using System.Text.Json.Serialization;

namespace Tesy.Content.Documents
{
    public record class Documents (
        [property: JsonPropertyName("groupName")] string GroupName,
        [property: JsonPropertyName("groupImage")] string GroupImage,
        [property: JsonPropertyName("models")] Dictionary<string, Models> Models
    );
}