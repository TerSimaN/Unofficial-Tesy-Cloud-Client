namespace Tesy.Content
{
    public record class TimeZoneContent (
        string CountryCode,
        string IanaId,
        string? WindowsId,
        string UtcOffset,
        string Comments
    );
}