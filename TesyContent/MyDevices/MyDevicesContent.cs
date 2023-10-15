using System.Text.Json.Serialization;

public record class MyDevicesContent (
    [property: JsonPropertyName("hasInternet")] bool HasInternet,
    [property: JsonPropertyName("httpAddr")] string HttpAddr,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("state")] DeviceState State,
    [property: JsonPropertyName("model")] string Model,
    [property: JsonPropertyName("model_id")] short Model_Id,
    [property: JsonPropertyName("model_type")] string Model_Type,
    [property: JsonPropertyName("model_watt")] string Model_Watt,
    [property: JsonPropertyName("model_image")] string Model_Image,
    [property: JsonPropertyName("model_image_main")] string Model_Image_Main,
    [property: JsonPropertyName("ip")] string IP,
    [property: JsonPropertyName("city")] string City,
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("continent")] string Continent,
    [property: JsonPropertyName("timezone")] string Timezone,
    [property: JsonPropertyName("time")] string Time,
    [property: JsonPropertyName("deviceName")] string DeviceName,
    [property: JsonPropertyName("wifi_ssid")] string Wifi_SSID,
    [property: JsonPropertyName("wifi_pass")] string Wifi_Pass,
    [property: JsonPropertyName("firmware_version")] string FirmwareVersion,
    [property: JsonPropertyName("ap_pass")] string Ap_Pass,
    [property: JsonPropertyName("localUsage")] bool LocalUsage,
    [property: JsonPropertyName("waitingForConnection")] bool WaitingForConnection
);