namespace Tesy.Commands
{
    public class UpdateUserAccountSettings
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly TesyUserClass tesyUserClass;
        private readonly StreamDeserializer deserializer = new();
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public UpdateUserAccountSettings(TesyHttpClient tesyHttpClient, TesyUserClass tesyUserClass)
        {
            this.tesyHttpClient = tesyHttpClient;
            this.tesyUserClass = tesyUserClass;
        }

        public async void PostUpdateUserAccountSettings()
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Post(
                TesyConstants.AppUserAccountSettingsUrl,
                new Dictionary<string, string>(
                    new[] {
                        KeyValuePair.Create("email", tesyUserClass.Email),
                        KeyValuePair.Create("name", tesyUserClass.FirstName),
                        KeyValuePair.Create("lastName", tesyUserClass.LastName),
                        KeyValuePair.Create("newLang", tesyUserClass.Lang),
                        KeyValuePair.Create("userID", inputQueryParams["userID"])
                    }
                )
            );

            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("success"))
            {
                tesyFileEditor.WriteUserCredentialsToFile(tesyUserClass.Email, tesyUserClass.NewPassword, TesyConstants.PathToCredentialsJsonFile);
                var updateUserAccountSettingsContentResponse = deserializer.GetUpdateUserAccountSettingsContent(stream);
                contentToWrite = ContentBuilder.BuildUpdateUserAccountSettingsContentString(updateUserAccountSettingsContentResponse);
            }
            else if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            }
            else if (responseMessageContent.Contains("email") && !responseMessageContent.Contains("name") && !responseMessageContent.Contains("lastName"))
            {
                var emailErrorResponse = deserializer.GetEmailError(stream);
                contentToWrite = ContentBuilder.BuildEmailErrorString(emailErrorResponse);
            }
            else if (!responseMessageContent.Contains("email") && responseMessageContent.Contains("name") && !responseMessageContent.Contains("lastName"))
            {
                var nameErrorResponse = deserializer.GetNameError(stream);
                contentToWrite = ContentBuilder.BuildNameErrorString(nameErrorResponse);
            }
            else if (!responseMessageContent.Contains("email") && !responseMessageContent.Contains("name") && responseMessageContent.Contains("lastName"))
            {
                var lastNameErrorResponse = deserializer.GetLastNameError(stream);
                contentToWrite = ContentBuilder.BuildLastNameErrorString(lastNameErrorResponse);
            }
            else if (responseMessageContent.Contains("email") && responseMessageContent.Contains("name") && responseMessageContent.Contains("lastName"))
            {
                var accountDetailsErrorResponse = deserializer.GetAccountDetailsError(stream);
                contentToWrite = ContentBuilder.BuildAccountDetailsErrorString(accountDetailsErrorResponse);
            }
            tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
        }
    }
}