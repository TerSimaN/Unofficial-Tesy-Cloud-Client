using System.Text.Json;
using Tesy.Classes;

namespace Tesy.Commands
{
    public class UpdateUserPasswordSettings
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly TesyUserClass tesyUserClass;
        private readonly FileEditor fileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public UpdateUserPasswordSettings(TesyHttpClient tesyHttpClient, TesyUserClass tesyUserClass)
        {
            this.tesyHttpClient = tesyHttpClient;
            this.tesyUserClass = tesyUserClass;
        }

        public async void PostUpdateUserPasswordSettings()
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Post(
                TesyConstants.AppUserPasswordSettingsUrl,
                new Dictionary<string, string>(
                    new[] {
                        KeyValuePair.Create("newPassword", tesyUserClass.NewPassword),
                        KeyValuePair.Create("confirmPassword", tesyUserClass.ConfirmPassword),
                        KeyValuePair.Create("userID", inputQueryParams["userID"])
                    }
                )
            );

            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("success"))
            {
                fileEditor.WriteUserCredentialsToFile(tesyUserClass.Email, tesyUserClass.NewPassword, TesyConstants.PathToCredentialsJsonFile);
                var updateUserPasswordSettingsContentResponse = JsonSerializer.Deserialize<UpdateUserPasswordSettingsContent>(stream) ?? new(false);
                contentToWrite = ContentBuilder.BuildUpdateUserPasswordSettingsContentString(updateUserPasswordSettingsContentResponse);
            }
            else if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else if (!responseMessageContent.Contains("newPassword") && responseMessageContent.Contains("confirmPassword"))
            {
                var confirmPasswordErrorResponse = JsonSerializer.Deserialize<Dictionary<string, ConfirmPasswordError>>(stream) ?? new();
                contentToWrite = ContentBuilder.BuildConfirmPasswordErrorString(confirmPasswordErrorResponse);
            }
            else if (responseMessageContent.Contains("newPassword") && responseMessageContent.Contains("confirmPassword"))
            {
                var passwordDetailsErrorResponse = JsonSerializer.Deserialize<Dictionary<string, PasswordDetailsError>>(stream) ?? new();
                contentToWrite = ContentBuilder.BuildPasswordDetailsErrorString(passwordDetailsErrorResponse);
            }
            fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}