namespace Tesy.Commands
{
    public class UpdateUserPasswordSettings
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly TesyUserClass tesyUserClass;
        private readonly StreamDeserializer deserializer = new();
        private readonly TesyFileEditor tesyFileEditor = new();
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
                // TODO: Add WriteUserCredentialsToFile(tesyUserClass.Email, tesyUserClass.NewPassword);
                var updateUserPasswordSettingsContentResponse = deserializer.GetUpdateUserPasswordSettingsContent(stream);
                contentToWrite = ContentBuilder.BuildUpdateUserPasswordSettingsContentString(updateUserPasswordSettingsContentResponse);
            }
            else if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else if (!responseMessageContent.Contains("newPassword") && responseMessageContent.Contains("confirmPassword"))
            {
                var confirmPasswordErrorResponse = deserializer.GetConfirmPasswordError(stream);
                contentToWrite = ContentBuilder.BuildConfirmPasswordErrorString(confirmPasswordErrorResponse);
            }
            else if (responseMessageContent.Contains("newPassword") && responseMessageContent.Contains("confirmPassword"))
            {
                var passwordDetailsErrorResponse = deserializer.GetPasswordDetailsError(stream);
                contentToWrite = ContentBuilder.BuildPasswordDetailsErrorString(passwordDetailsErrorResponse);
            }
            tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}