using System.Text.Json;
using Tesy.Commands;
using Tesy.Convectors;
using Tesy.Programs;
using Tesy.Serializers;

namespace Tesy.Classes
{
    public class WeekProgram
    {
        private readonly string deviceProgramDataJsonFilePath = TesyConstants.PathToCorrectDeviceProgramDataJsonFile;
        private string textToShow = "";
        
        private readonly MyDevices myDevices;
        private readonly Cn05uv convector;
        private readonly DeviceSettings deviceSettings;
        private readonly PayloadSerializer payloadSerializer = new();
        private readonly WeekProgramPayload weekProgramPayload = new();
        private readonly FileEditor fileEditor = new();

        public WeekProgram(MyDevices myDevices, Cn05uv convector, DeviceSettings deviceSettings)
        {
            this.myDevices = myDevices;
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

        public async void AddWeekProgram(CreateWeekProgram weekProgram)
        {
            string command = "setProgram";
            Console.WriteLine("Enter values for new week program:");
            weekProgram.ReadCreateProgramValues();
            
            bool isValid = await weekProgram.IsTimeValid();
            if (isValid)
            {
                string programKey = FindProgramKey(weekProgram.DayOfWeek, weekProgram.FromTime);
                string payloadContent = weekProgramPayload.SerializeWeekProgramParamsAsJsonPayload(weekProgram, programKey);

                deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
            }
            else
            {
                Console.WriteLine("Invalid program!");
            }
        }

        public async void EditWeekProgram(CreateWeekProgram weekProgram)
        {
            textToShow = "edit";
            string command = "setProgram";
            string programId = Input.ReadProgramIdFromConsole(textToShow);
            Dictionary<string, DeviceProgram> programToEdit = new();
            var devicePrograms = await myDevices.GetDevicePrograms();
            foreach (var programKey in devicePrograms)
            {
                if (programId == programKey.Key)
                {
                    weekProgram.DayOfWeek = programKey.Value.Day;
                    programToEdit.Add(programKey.Key, programKey.Value);
                }
            }
            DeleteWeekProgram(programId);
            
            Output.PrintEditWeekProgramByProgramIdContent(programToEdit, programId);
            Console.WriteLine("Enter new values for selected week program:");
            weekProgram.ReadEditProgramValues();
            
            bool isValid = await weekProgram.IsTimeValid();
            if (isValid)
            {
                string programKey = FindProgramKey(weekProgram.DayOfWeek, weekProgram.FromTime);
                string payloadContent = weekProgramPayload.SerializeWeekProgramParamsAsJsonPayload(weekProgram, programKey);

                deviceSettings.PublishMessage(convector, TesyConstants.MessageRequestType, command, payloadContent);
            }
            else
            {
                Console.WriteLine("Invalid program!");
            }
        }
        
        public async void DeleteWeekProgram(string? programId = default)
        {
            textToShow = "delete";
            string command = "deleteProgram";
            string payloadContent = "";
            if (programId == default)
            {
                programId = Input.ReadProgramIdFromConsole(textToShow);
            }
            
            var devicePrograms = await myDevices.GetDevicePrograms();
            foreach (var programKey in devicePrograms)
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