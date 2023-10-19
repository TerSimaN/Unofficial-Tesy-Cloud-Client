using Tesy.Classes;
using Tesy.Clients;
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


// Refactored project using namespaces
await Mqtt.ConnectClient();

Generator.GenerateMqttResponseMessagesFile();
Generator.GenerateHttpResponseMessagesFile();

string[] userCredentials = Credentials.GetCredentials();
Http httpClient = Login.SignIn(userCredentials[0], userCredentials[1]);

LoginData loginData = new(httpClient);
var inputQueryParams = await loginData.PostLoginData(userCredentials[0], userCredentials[1]);

DevicePowerStat devicePowerStat = new(httpClient, inputQueryParams);
DeviceTempStat deviceTempStat = new(httpClient, inputQueryParams);
TesyDocuments documents = new(httpClient, inputQueryParams);
MyDevices myDevices = new(httpClient, inputQueryParams);
MyGroups myGroups = new(httpClient, inputQueryParams);
MyMessages myMessages = new(httpClient, inputQueryParams);
TestDevices testDevices = new(httpClient, inputQueryParams);
UpdateDeviceSettings updateDeviceSettings = new(httpClient, inputQueryParams);
UpdateUserAccountSettings updateUserAccountSettings = new(httpClient, inputQueryParams);
UpdateUserPasswordSettings updateUserPasswordSettings = new(httpClient, inputQueryParams);
UserHasAccessToCloud userHasAccessToCloud = new(httpClient, inputQueryParams);
UserInfo userInfo = new(httpClient, inputQueryParams);

User user = new(userInfo);
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
    devicePowerStat, deviceTempStat, documents, loginData,
    myDevices, myGroups, myMessages, testDevices,
    updateUserAccountSettings, updateUserPasswordSettings,
    userHasAccessToCloud, userInfo, user, weekProgram,
    createWeekProgram, reset, deleteAllDevicePrograms,
    deviceSSID, deviceStatus, onOff, uv, lockDevice,
    openedWindow, antiFrost, adaptiveStart, deviceTemp,
    mode, ecoTemp, comfortTemp, sleepTemp, delayedStart,
    deviceName, wifiData, tCorrection, deviceTimeZone
);

await Mqtt.SubscribeForDevice(convector.MacAddress);
Mqtt.HandleRecievedMessages();

commander.ShowAllCommands();

await Mqtt.UnsubscribeForDevice(convector.MacAddress);
await Mqtt.DisconnectClient();
// Refactored project using namespaces

