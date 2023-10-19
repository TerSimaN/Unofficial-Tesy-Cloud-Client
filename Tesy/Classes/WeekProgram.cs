using System.Text.Json;
using Tesy.Commands;
using Tesy.Content;
using Tesy.Content.MyDevices;
using Tesy.Convectors;
using Tesy.Programs;
using Tesy.Serializers;

namespace Tesy.Classes
{
    public class WeekProgram
    {
        private readonly string deviceProgramDataJsonFilePath = Constants.PathToCorrectDeviceProgramDataJsonFile;
        private string textToShow = "";
        
        private readonly MyDevices myDevices;
        private readonly Cn05uv convector;
        private readonly DeviceSettings deviceSettings;
        private readonly WeekProgramPayload weekProgramPayload = new();
        private readonly ProgramKeyPayload programKeyPayload = new();
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
                string payloadContent = weekProgramPayload.SerializeParamsAsJsonPayload(weekProgram, programKey);

                deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
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
            string programId = ReadProgramIdFromConsole(textToShow);
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
                string payloadContent = weekProgramPayload.SerializeParamsAsJsonPayload(weekProgram, programKey);

                deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
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
                programId = ReadProgramIdFromConsole(textToShow);
            }
            
            var devicePrograms = await myDevices.GetDevicePrograms();
            foreach (var programKey in devicePrograms)
            {
                if (programId == programKey.Key)
                {
                    payloadContent = programKeyPayload.SerializeParamsAsJsonPayload(programKey.Key);
                    break;
                }
            }

            deviceSettings.PublishMessage(convector, Constants.MessageRequestType, command, payloadContent);
        }

        /// <summary>
        /// Reads <c>programId</c> value from the Console.
        /// </summary>
        /// <param name="textToShow"><c>edit</c> or <c>delete</c> text to show.</param>
        /// <returns>The read <c>programId</c>.</returns>
        private string ReadProgramIdFromConsole(string textToShow)
        {
            string selectedId = "";
            do
            {
                Console.Write($"Enter \"Id\" of the week program you wish to {textToShow}: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    selectedId = inputValue.Trim();
                }
            } while (selectedId.Length < 1);

            return selectedId;
        }
    }
}