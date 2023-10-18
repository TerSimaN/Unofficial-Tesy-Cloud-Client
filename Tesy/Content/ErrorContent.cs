using System.Text.Json.Serialization;

namespace Tesy.Content
{
    public record class CredentialsError (
        [property: JsonPropertyName("email")] string[] Email,
        [property: JsonPropertyName("password")] string[] Password
    );

    public record class EmailError (
        [property: JsonPropertyName("email")] string[] Email
    );

    public record class PasswordError (
        [property: JsonPropertyName("password")] string[] Password
    );

    public record class GlobalError (
        [property: JsonPropertyName("global")] string Global
    );

    public record class NoMatchFoundInRecordsError (
        [property: JsonPropertyName("error")] string Error
    );

    public record class AccountDetailsError (
        [property: JsonPropertyName("email")] string[] Email,
        [property: JsonPropertyName("name")] string[] Name,
        [property: JsonPropertyName("lastName")] string[] LastName
    );

    public record class NameError (
        [property: JsonPropertyName("name")] string[] Name
    );

    public record class LastNameError (
        [property: JsonPropertyName("lastName")] string[] LastName
    );

    public record class PasswordDetailsError (
        [property: JsonPropertyName("newPassword")] string[] NewPassword,
        [property: JsonPropertyName("confirmPassword")] string[] ConfirmPassword
    );

    public record class ConfirmPasswordError (
        [property: JsonPropertyName("confirmPassword")] string[] ConfirmPassword
    );
}