using System.Text.Json;

namespace Tesy.Classes
{
    public static class Constants
    {
        private static readonly DateTime currentDateAndTime = DateTime.Now;
        private static readonly DateOnly currentDateOnly = DateOnly.FromDateTime(currentDateAndTime);
        private static readonly TimeOnly currentTimeOnly = TimeOnly.FromDateTime(currentDateAndTime);
        private static readonly string currentDate = $"{currentDateOnly.Day}-{currentDateOnly.Month}-{currentDateOnly.Year}";
        private static readonly string currentTime = $"{currentTimeOnly.Hour}:{currentTimeOnly.Minute}:{currentTimeOnly.Second}.{currentTimeOnly.Millisecond}";
        private static readonly string MqttResponseMessagesFilePath = @$".\Tesy\ResponseMessages\MqttResponseMessages\Mqtt-Response-Messages-{currentDate}.txt";
        private static readonly string HttpResponseMessagesFilePath = @$".\Tesy\ResponseMessages\HttpResponseMessages\Http-Response-Messages-{currentDate}.txt";
        private const string TesyLoginUrl = "app-user-login";
        private const string TesyUpdateDeviceSettingsUrl = "update-device-settings";
        private const string TesyAppUserAccountSettingsUrl = "app-user-account-settings";
        private const string TesyAppUserPasswordSettingsUrl = "app-user-password-settings";
        private const string TesyUserHasAccessToCloud = "has-access-to-cloud";
        private const string TesyUserInfoUrl = "get-user-info";
        private const string TesyMyDevicesUrl = "get-my-devices";
        private const string TesyMyGroupsUrl = "get-my-groups";
        private const string TesyMyMessagesUrl = "get-my-messages";
        private const string TesyTestDevicesUrl = "get-test-devices";
        private const string TesyDeviceTempStatUrl = "get-device-temp-stat";
        private const string TesyDevicePowerStatUrl = "get-device-power-stat";
        private const string TesyDocumentsUrl = "documents";
        private const string RequestType = "request";
        private const string CredentialsJsonFilePath = @".\Tesy\JsonFiles\CredentialsFile.json";
        private const string CorrectDeviceProgramDataJsonFilePath = @".\Tesy\JsonFiles\DeviceProgramDataCorrect.json";
        private const string BrokenDeviceProgramDataJsonFilePath = @".\Tesy\JsonFiles\DeviceProgramDataBroken.json";
        private const string MoreBrokenDeviceProgramDataJsonFilePath = @".\Tesy\JsonFiles\DeviceProgramDataMoreBroken.json";
        private const string TimeZonesFilePath = @".\Tesy\JsonFiles\TimeZonesFile.json";
        private static readonly Dictionary<string, string> LanguageDictionary = new(
            new[] {
                KeyValuePair.Create("Bulgarian", "bg"),
                KeyValuePair.Create("Czech", "cs"),
                KeyValuePair.Create("German", "de"),
                KeyValuePair.Create("English", "en"),
                KeyValuePair.Create("Spanish", "es"),
                KeyValuePair.Create("Estonian", "et"),
                KeyValuePair.Create("French", "fr"),
                KeyValuePair.Create("Greek", "el"),
                KeyValuePair.Create("Croatian", "hr"),
                KeyValuePair.Create("Hungarian", "hu"),
                KeyValuePair.Create("Lithuanian", "lt"),
                KeyValuePair.Create("Latvian", "lv"),
                KeyValuePair.Create("Macedonian", "mk"),
                KeyValuePair.Create("Dutch", "nl"),
                KeyValuePair.Create("Polish", "pl"),
                KeyValuePair.Create("Romanian", "ro"),
                KeyValuePair.Create("Serbian", "sr"),
                KeyValuePair.Create("Russian", "ru"),
                KeyValuePair.Create("Slovak", "sk"),
                KeyValuePair.Create("Ukrainian", "uk"),
                KeyValuePair.Create("Slovenian", "sl"),
                KeyValuePair.Create("Italian", "it"),
                KeyValuePair.Create("Hebrew", "he")
            }
        );

        private static readonly JsonSerializerOptions JsonSerializerOptions = new() {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public static string CurrentTime
        {
            get { return currentTime; }
        }

        public static string PathToMqttResponseMessagesFile
        {
            get { return MqttResponseMessagesFilePath; }
        }

        public static string PathToHttpResponseMessagesFile
        {
            get { return HttpResponseMessagesFilePath; }
        }

        public static string LoginUrl
        {
            get { return TesyLoginUrl; }
        }

        public static string UpdateDeviceSettingsUrl
        {
            get { return TesyUpdateDeviceSettingsUrl; }
        }

        public static string AppUserAccountSettingsUrl
        {
            get { return TesyAppUserAccountSettingsUrl; }
        }

        public static string AppUserPasswordSettingsUrl
        {
            get { return TesyAppUserPasswordSettingsUrl; }
        }

        public static string UserHasAccessToCloud
        {
            get { return TesyUserHasAccessToCloud; }
        }

        public static string UserInfoUrl
        {
            get { return TesyUserInfoUrl; }
        }

        public static string MyDevicesUrl
        {
            get { return TesyMyDevicesUrl; }
        }

        public static string MyGroupsUrl
        {
            get { return TesyMyGroupsUrl; }
        }

        public static string MyMessagesUrl
        {
            get { return TesyMyMessagesUrl; }
        }

        public static string TestDevicesUrl
        {
            get { return TesyTestDevicesUrl; }
        }

        public static string DeviceTempStatUrl
        {
            get { return TesyDeviceTempStatUrl; }
        }

        public static string DevicePowerStatUrl
        {
            get { return TesyDevicePowerStatUrl; }
        }

        public static string DocumentsUrl
        {
            get { return TesyDocumentsUrl; }
        }

        public static string MessageRequestType
        {
            get { return RequestType; }
        }

        public static string PathToCredentialsJsonFile
        {
            get { return CredentialsJsonFilePath; }
        }

        public static string PathToCorrectDeviceProgramDataJsonFile
        {
            get { return CorrectDeviceProgramDataJsonFilePath; }
        }

        public static string PathToBrokenDeviceProgramDataJsonFile
        {
            get { return BrokenDeviceProgramDataJsonFilePath; }
        }

        public static string PathToMoreBrokenDeviceProgramDataJsonFile
        {
            get { return MoreBrokenDeviceProgramDataJsonFilePath; }
        }

        public static string PathToTimeZonesFile
        {
            get { return TimeZonesFilePath; }
        }

        public static Dictionary<string, string> Languages
        {
            get { return LanguageDictionary; }
        }

        public static JsonSerializerOptions SerializerOptions
        {
            get { return JsonSerializerOptions; }
        }
    }
}