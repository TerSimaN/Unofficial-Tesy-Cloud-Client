using Tesy.Commands;

// Connect client ConsoleApplication to MQTT Server
await TesyMqttClient.ConnectClient();

Generator.GenerateMqttResponseMessagesFile();
Generator.GenerateHttpResponseMessagesFile();
// Generator.GenerateFormatedResponseMessagesFile();

TesyHttpClass tesyHttpClass = new();
tesyHttpClass.Login();

TesyUserClass tesyUserClass = new(tesyHttpClass);

TesyHttpClient tesyHttpClient = new();
LoginData loginData = new(tesyHttpClient);
var inputQueryParams = loginData.PostLoginData("", "");

DevicePowerStat devicePowerStat = new(tesyHttpClient);
DeviceTempStat deviceTempStat = new(tesyHttpClient);
TesyDocuments documents = new(tesyHttpClient);
MyDevices myDevices = new(tesyHttpClient);
MyGroups myGroups = new(tesyHttpClient);
MyMessages myMessages = new(tesyHttpClient);
TestDevices testDevices = new(tesyHttpClient);
UpdateDeviceSettings updateDeviceSettings = new(tesyHttpClient);
UpdateUserAccountSettings updateUserAccountSettings = new(tesyHttpClient, tesyUserClass);
UpdateUserPasswordSettings updateUserPasswordSettings = new(tesyHttpClient, tesyUserClass);
UserHasAccessToCloud userHasAccessToCloud = new(tesyHttpClient);
UserInfo userInfo = new(tesyHttpClient);

Cn05uvConvector cn05uvConvector = new(tesyHttpClass);
CreateProgram createProgram = new(tesyHttpClass);

TesyDebugClass tesyDebugClass = new();
TesyDeviceSettingsClass tesyDeviceSettings = new();
TesyWeekProgramClass tesyWeekProgram = new(tesyHttpClass, cn05uvConvector, tesyDeviceSettings);
TesyDeviceCommandsClass tesyDeviceCommands = new(tesyHttpClass, cn05uvConvector, tesyDeviceSettings);

ShowTesyCommands showTesyCommands = new(
    tesyHttpClass,
    createProgram,
    tesyWeekProgram,
    tesyDeviceCommands,
    tesyUserClass,
    tesyDebugClass
);

await TesyMqttClient.SubscribeForDevice(cn05uvConvector.MacAddress);
TesyMqttClient.HandleRecievedMessages();

showTesyCommands.ShowListOfAllCommands();

await TesyMqttClient.UnsubscribeForDevice(cn05uvConvector.MacAddress);
await TesyMqttClient.DisconnectClient();
