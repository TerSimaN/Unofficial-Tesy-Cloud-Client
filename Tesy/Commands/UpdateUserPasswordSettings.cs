using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;

namespace Tesy.Commands
{
    public class UpdateUserPasswordSettings
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private readonly Dictionary<string, string> inputQueryParams;

        public UpdateUserPasswordSettings(Http httpClient, Dictionary<string, string> inputQueryParams)
        {
            this.httpClient = httpClient;
            this.inputQueryParams = inputQueryParams;
        }

        public async void PostUpdateUserPasswordSettings(User user)
        {
            HttpResponseMessage responseMessage = httpClient.Post(
                Constants.AppUserPasswordSettingsUrl,
                new Dictionary<string, string>(
                    new[] {
                        KeyValuePair.Create("newPassword", user.NewPassword),
                        KeyValuePair.Create("confirmPassword", user.ConfirmPassword),
                        KeyValuePair.Create("userID", inputQueryParams["userID"])
                    }
                )
            );

            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("success"))
            {
                fileEditor.WriteUserCredentialsToFile(user.Email, user.NewPassword, Constants.PathToCredentialsJsonFile);
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
            fileEditor.WriteToFile(Constants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}