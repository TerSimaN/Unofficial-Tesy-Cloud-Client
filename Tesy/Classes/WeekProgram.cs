using System.Text.Json;
using Tesy.Convectors;

namespace Tesy.Classes
{
    public class WeekProgram
    {
        private readonly string deviceProgramDataJsonFilePath = TesyConstants.PathToCorrectDeviceProgramDataJsonFile;
        private string textToShow = "";
        
        private readonly TesyHttpClass tesyHttpClass;
        private readonly Cn05uv convector;
        private readonly DeviceSettings deviceSettings;
        private readonly PayloadSerializer payloadSerializer = new();
        private readonly FileEditor fileEditor = new();

        public WeekProgram(TesyHttpClass tesyHttpClass, Cn05uv convector, DeviceSettings deviceSettings)
        {
            this.tesyHttpClass = tesyHttpClass;
            this.convector = convector;
            this.deviceSettings = deviceSettings;
        }

        public string FindProgramKey(int day, string from)
        {
            string programKey = "1";
            string readContent = fileEditor.ReadFromFile(deviceProgramDataJsonFilePath);

            var deviceProgramDataContentResponse = JsonSerializer.Deserialize<Dictionary<string, DeviceProgramDataContent>>(readContent) ?? new();
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

                deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
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

                deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
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

            deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
        }
    }
}