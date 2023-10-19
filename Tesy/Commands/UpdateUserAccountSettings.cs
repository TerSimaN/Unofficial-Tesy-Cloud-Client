using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;

namespace Tesy.Commands
{
    public class UpdateUserAccountSettings
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public UpdateUserAccountSettings(Http httpClient)
        {
            this.httpClient = httpClient;
        }

        public async void PostUpdateUserAccountSettings(User user)
        {
            HttpResponseMessage responseMessage = httpClient.Post(
                TesyConstants.AppUserAccountSettingsUrl,
                new Dictionary<string, string>(
                    new[] {
                        KeyValuePair.Create("email", user.Email),
                        KeyValuePair.Create("name", user.FirstName),
                        KeyValuePair.Create("lastName", user.LastName),
                        KeyValuePair.Create("newLang", user.Lang),
                        KeyValuePair.Create("userID", inputQueryParams["userID"])
                    }
                )
            );

            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("success"))
            {
                fileEditor.WriteUserCredentialsToFile(user.Email, user.NewPassword, TesyConstants.PathToCredentialsJsonFile);
                var updateUserAccountSettingsContentResponse = JsonSerializer.Deserialize<UpdateUserAccountSettingsContent>(stream) ?? new(false);
                contentToWrite = ContentBuilder.BuildUpdateUserAccountSettingsContentString(updateUserAccountSettingsContentResponse);
            }
            else if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else if (responseMessageContent.Contains("email") && !responseMessageContent.Contains("name") && !responseMessageContent.Contains("lastName"))
            {
                var emailErrorResponse = JsonSerializer.Deserialize<Dictionary<string, EmailError>>(stream) ?? new();
                contentToWrite = ContentBuilder.BuildEmailErrorString(emailErrorResponse);
            }
            else if (!responseMessageContent.Contains("email") && responseMessageContent.Contains("name") && !responseMessageContent.Contains("lastName"))
            {
                var nameErrorResponse = JsonSerializer.Deserialize<Dictionary<string, NameError>>(stream) ?? new();
                contentToWrite = ContentBuilder.BuildNameErrorString(nameErrorResponse);
            }
            else if (!responseMessageContent.Contains("email") && !responseMessageContent.Contains("name") && responseMessageContent.Contains("lastName"))
            {
                var lastNameErrorResponse = JsonSerializer.Deserialize<Dictionary<string, LastNameError>>(stream) ?? new();
                contentToWrite = ContentBuilder.BuildLastNameErrorString(lastNameErrorResponse);
            }
            else if (responseMessageContent.Contains("email") && responseMessageContent.Contains("name") && responseMessageContent.Contains("lastName"))
            {
                var accountDetailsErrorResponse = JsonSerializer.Deserialize<Dictionary<string, AccountDetailsError>>(stream) ?? new();
                contentToWrite = ContentBuilder.BuildAccountDetailsErrorString(accountDetailsErrorResponse);
            }
            fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}