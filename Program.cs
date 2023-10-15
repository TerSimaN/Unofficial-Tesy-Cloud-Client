// Connect client ConsoleApplication to MQTT Server
await TesyMqttClient.ConnectClient();

Generator.GenerateMqttResponseMessagesFile();
Generator.GenerateHttpResponseMessagesFile();
// Generator.GenerateFormatedResponseMessagesFile();

TesyHttpClass tesyHttpClass = new();
tesyHttpClass.Login();

if (!tesyHttpClass.HasLoginError)
{
    Cn05uvConvector cn05uvConvector = new(tesyHttpClass);
    CreateProgram createProgram = new(tesyHttpClass);

    TesyDebugClass tesyDebugClass = new();
    TesyUserClass tesyUserClass = new(tesyHttpClass);
    TesyDeviceSettingsClass tesyDeviceSettings = new();
    TesyWeekProgramClass tesyWeekProgram = new(tesyHttpClass, cn05uvConvector, tesyDeviceSettings);
    TesyDeviceCommandsClass tesyDeviceCommands = new(tesyHttpClass, cn05uvConvector, tesyDeviceSettings);

    ShowTesyCommands showTesyCommands = new(
        tesyHttpClass, 
        cn05uvConvector, 
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
}

await TesyMqttClient.DisconnectClient();
