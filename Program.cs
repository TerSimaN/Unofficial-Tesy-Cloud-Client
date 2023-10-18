using Tesy.Classes;
using Tesy.Commands;
using Tesy.Commands.DeviceCommands;
using Tesy.Convectors;
using Tesy.Programs;

// Connect client ConsoleApplication to MQTT Server
await TesyMqttClient.ConnectClient();

Generator.GenerateMqttResponseMessagesFile();
Generator.GenerateHttpResponseMessagesFile();

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

DeviceSettings deviceSettings = new();
Cn05uv convector = new(myDevices);
WeekProgram weekProgram = new(myDevices, convector, deviceSettings);
CreateWeekProgram createWeekProgram = new(myDevices);
Reset reset = new(deviceSettings, convector);
DeleteAllDevicePrograms deleteAllDevicePrograms = new(deviceSettings, convector);
DeviceSSID deviceSSID = new(deviceSettings, convector);
DeviceStatus deviceStatus = new(deviceSettings, convector);
OnOff onOff = new(deviceSettings, convector, myDevices);
UV uv = new(deviceSettings, convector, myDevices);
LockDevice lockDevice = new(deviceSettings, convector, myDevices);
OpenedWindow openedWindow = new(deviceSettings, convector, myDevices);
AntiFrost antiFrost = new(deviceSettings, convector, myDevices);
AdaptiveStart adaptiveStart = new(deviceSettings, convector, myDevices);
DeviceTemp deviceTemp = new(deviceSettings, convector, myDevices);
Mode mode = new(deviceSettings, convector, myDevices);
EcoTemp ecoTemp = new(deviceSettings, convector, myDevices);
ComfortTemp comfortTemp = new(deviceSettings, convector, myDevices);
SleepTemp sleepTemp = new(deviceSettings, convector, myDevices);
DelayedStart delayedStart = new(deviceSettings, convector, myDevices);
DeviceName deviceName = new(myDevices, updateDeviceSettings);
WifiData wifiData = new(deviceSettings, convector, myDevices);
TCorrection tCorrection = new(deviceSettings, convector, myDevices);
DeviceTimeZone deviceTimeZone = new(deviceSettings, convector, myDevices, updateDeviceSettings, tesyHttpClass);

Commander commander = new(
    myDevices, weekProgram, createWeekProgram,
    reset, deleteAllDevicePrograms, deviceSSID, deviceStatus,
    onOff, uv, lockDevice, openedWindow, antiFrost,
    adaptiveStart, deviceTemp, mode, ecoTemp,
    comfortTemp, sleepTemp, delayedStart,
    deviceName, wifiData, tCorrection, deviceTimeZone
);

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
