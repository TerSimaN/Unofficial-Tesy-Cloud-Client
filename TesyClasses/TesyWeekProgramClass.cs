public class TesyWeekProgramClass
{
    private readonly string deviceProgramDataJsonFilePath = TesyConstants.PathToCorrectDeviceProgramDataJsonFile;
    private string textToShow = "";
    
    private readonly TesyHttpClass tesyHttpClass;
    private readonly Cn05uvConvector convector;
    private readonly TesyDeviceSettingsClass tesyDeviceSettings;
    private readonly StreamDeserializer deserializer = new();
    private readonly PayloadSerializer payloadSerializer = new();
    private readonly TesyFileEditorClass tesyFileEditor = new();
    private Dictionary<string, DeviceProgramDataContent> deviceProgramDataContentResponse = new();

    public TesyWeekProgramClass(TesyHttpClass tesyHttpClass, Cn05uvConvector convector, TesyDeviceSettingsClass tesyDeviceSettings)
    {
        this.tesyHttpClass = tesyHttpClass;
        this.convector = convector;
        this.tesyDeviceSettings = tesyDeviceSettings;
    }

    public string FindProgramKey(int day, string from)
    {
        string programKey = "1";
        string readContent = tesyFileEditor.ReadFromFile(deviceProgramDataJsonFilePath);

        deviceProgramDataContentResponse = deserializer.GetDeviceProgramDataContent(readContent);
        foreach (var programData in deviceProgramDataContentResponse)
        {
            int programDay = programData.Value.ProgramDay;
            string programFrom = programData.Value.ProgramFrom;
            if ((programDay == day) && (programFrom == from))
            {
                programKey = programData.Key;
                break;
            }
        }

        /*
        The following command prints in the Console A LOT of text
        if JSON file "DeviceProgramDataBroken.json" or
        "DeviceProgramDataMoreBroken.json" is selected!
        */
        // Output.PrintDeviceProgramDataContent(deviceProgramDataContentResponse);

        return programKey;
    }

    public void AddWeekProgram(CreateProgram createProgram)
    {
        string command = "setProgram";
        Console.WriteLine("Enter values for new week program:");
        Input.ReadCreateProgramValuesFromConsole(createProgram);
        
        bool isValid = createProgram.IsTimeValid();
        if (isValid)
        {
            string programKey = FindProgramKey(createProgram.DayOfWeek, createProgram.FromTime);
            string payloadContent = payloadSerializer.SerializeProgramParamsAsJsonPayload(createProgram, programKey);

            tesyDeviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        else
        {
            Console.WriteLine("Invalid program!");
        }
    }

    public void EditWeekProgram(CreateProgram createProgram)
    {
        textToShow = "edit";
        string command = "setProgram";
        string programId = Input.ReadProgramIdFromConsole(textToShow);
        Dictionary<string, DeviceProgram> programToEdit = new();
        foreach (var programKey in tesyHttpClass.DeviceProgramsDictionary)
        {
            if (programId == programKey.Key)
            {
                createProgram.DayOfWeek = programKey.Value.Day;
                programToEdit.Add(programKey.Key, programKey.Value);
            }
        }
        DeleteWeekProgram(programId);
        
        Output.PrintEditWeekProgramByProgramIdContent(programToEdit, programId);
        Console.WriteLine("Enter new values for selected week program:");
        Input.ReadEditProgramValuesFromConsole(createProgram);
        
        bool isValid = createProgram.IsTimeValid();
        if (isValid)
        {
            string programKey = FindProgramKey(createProgram.DayOfWeek, createProgram.FromTime);
            string payloadContent = payloadSerializer.SerializeProgramParamsAsJsonPayload(createProgram, programKey);

            tesyDeviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
        else
        {
            Console.WriteLine("Invalid program!");
        }
    }
    
    public void DeleteWeekProgram(string? programId = default)
    {
        textToShow = "delete";
        string command = "deleteProgram";
        string payloadContent = "";
        if (programId == default)
        {
            programId = Input.ReadProgramIdFromConsole(textToShow);
        }
        
        foreach (var programKey in tesyHttpClass.DeviceProgramsDictionary)
        {
            if (programId == programKey.Key)
            {
                payloadContent = payloadSerializer.SerializeProgramKeyAsJsonPayload(programKey.Key);
                break;
            }
        }

        tesyDeviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
    }
}