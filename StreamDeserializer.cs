using System.Text.Json;
using Tesy.Content;
using Tesy.Content.Documents;
using Tesy.Content.MyDevices;

public class StreamDeserializer
{
    private readonly JsonSerializerOptions options = new() { AllowTrailingCommas = true };

    public CredentialsContent GetUserCredentialsContent(string content)
    {
        var response = JsonSerializer.Deserialize<CredentialsContent>(content, options);
        return response ?? new("Email not found", "Password not found");
    }

    public Dictionary<string, CredentialsContent> GetCredentialsDictionaryContent(string content)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, CredentialsContent>>(content, options);
        return response ?? new();
    }

    public LoginContent GetTesyLoginContent(Stream stream)
    {
        var response = JsonSerializer.Deserialize<LoginContent>(stream);
        return response ?? new(
            -1, "Password not found", "Email not found", "FirstName not found", 
            "LastName not found", "Lang not found", "DebugMenu not found", "Token not found"
        );
    }

    public UpdateDeviceSettingsContent GetUpdateDeviceSettingsContent(Stream stream)
    {
        var response = JsonSerializer.Deserialize<UpdateDeviceSettingsContent>(stream);
        return response ?? new(false, "Message not found");
    }

    public UpdateUserAccountSettingsContent GetUpdateUserAccountSettingsContent(Stream stream)
    {
        var response = JsonSerializer.Deserialize<UpdateUserAccountSettingsContent>(stream);
        return response ?? new(false);
    }

    public UpdateUserPasswordSettingsContent GetUpdateUserPasswordSettingsContent(Stream stream)
    {
        var response = JsonSerializer.Deserialize<UpdateUserPasswordSettingsContent>(stream);
        return response ?? new(false);
    }

    public UserInfoContent GetUserInfoContent(Stream stream)
    {
        var response = JsonSerializer.Deserialize<UserInfoContent>(stream);
        return response ?? new("Email not found", "FirstName not found", "LastName not found", "Lang not found");
    }

    public Dictionary<string, MyDevicesContent> GetMyDevicesContent(Stream stream)
    {
        try
        {
            var response = JsonSerializer.Deserialize<Dictionary<string, MyDevicesContent>>(stream);
            return response ?? new();
        }
        catch (JsonException jsonErr)
        {
            Console.WriteLine(jsonErr.Message);
        }

        return new();
    }

    public Dictionary<string, Documents> GetTesyDocumentsContent(Stream stream)
    {
        try
        {
            var response = JsonSerializer.Deserialize<Dictionary<string, Documents>>(stream);
            return response ?? new();
        }
        catch (JsonException jsonErr)
        {
            Console.WriteLine(jsonErr.Message);
        }

        return new();
    }

    public DeviceTempStatContent GetDeviceTempStatContent(Stream stream)
    {
        var response = JsonSerializer.Deserialize<DeviceTempStatContent>(stream);
        return response ?? new(new DataContent[] { }, new string[] { });
    }

    public DevicePowerStatContent[] GetDevicePowerStatContent(Stream stream)
    {
        var response = JsonSerializer.Deserialize<DevicePowerStatContent[]>(stream);
        return response ?? new DevicePowerStatContent[] {};
    }

    public Dictionary<string, CredentialsError> GetCredentialsError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, CredentialsError>>(stream);
        return response ?? new();
    }

    public Dictionary<string, EmailError> GetEmailError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, EmailError>>(stream);
        return response ?? new();
    }

    public Dictionary<string, PasswordError> GetPasswordError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, PasswordError>>(stream);
        return response ?? new();
    }

    public Dictionary<string, GlobalError> GetGlobalError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, GlobalError>>(stream);
        return response ?? new();
    }

    public NoMatchFoundInRecordsError GetNoMatchFoundInRecordsError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream);
        return response ?? new("Error not found");
    }

    public Dictionary<string, NameError> GetNameError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, NameError>>(stream);
        return response ?? new();
    }

    public Dictionary<string, LastNameError> GetLastNameError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, LastNameError>>(stream);
        return response ?? new();
    }

    public Dictionary<string, AccountDetailsError> GetAccountDetailsError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, AccountDetailsError>>(stream);
        return response ?? new();
    }

    public Dictionary<string, ConfirmPasswordError> GetConfirmPasswordError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, ConfirmPasswordError>>(stream);
        return response ?? new();
    }

    public Dictionary<string, PasswordDetailsError> GetPasswordDetailsError(Stream stream)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, PasswordDetailsError>>(stream);
        return response ?? new();
    }

    public Dictionary<string, DeviceProgramDataContent> GetDeviceProgramDataContent(string content)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, DeviceProgramDataContent>>(content);
        return response ?? new();
    }

    public DeviceTime GetDeviceTimeContent(string content)
    {
        var response = JsonSerializer.Deserialize<DeviceTime>(content);
        return response ?? new("Date not found", "Time not found");
    }

    public Dictionary<string, TimeZonesFileContent> GetTimeZonesFileContent(string content)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, TimeZonesFileContent>>(content);
        return response ?? new();
    }
}