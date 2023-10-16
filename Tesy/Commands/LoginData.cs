namespace Tesy.Commands
{
    public class LoginData
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly StreamDeserializer deserializer = new();
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public LoginData(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public async Task<Dictionary<string, string>> PostLoginData(string userEmail, string userPasswword)
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Post(
                TesyConstants.LoginUrl,
                new Dictionary<string, string>(
                    new[] {
                        KeyValuePair.Create("email", userEmail),
                        KeyValuePair.Create("password", userPasswword)
                    }
                )
            );

            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("userID"))
            {
                var loginContentResponse = deserializer.GetTesyLoginContent(stream);
                inputQueryParams.TryAdd("userID", loginContentResponse.UserID.ToString());
                contentToWrite = ContentBuilder.BuildLoginContentString(loginContentResponse);
                tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);

                return inputQueryParams;
            }
            else if (responseMessageContent.Contains("global"))
            {
                var globalErrorResponse = deserializer.GetGlobalError(stream);
                Output.PrintGlobalError(globalErrorResponse);
                contentToWrite = ContentBuilder.BuildGlobalErrorString(globalErrorResponse);
            }
            else if (responseMessageContent.Contains("email") && !responseMessageContent.Contains("password"))
            {
                var emailErrorResponse = deserializer.GetEmailError(stream);
                Output.PrintEmailError(emailErrorResponse);
                contentToWrite = ContentBuilder.BuildEmailErrorString(emailErrorResponse);
            }
            else if (!responseMessageContent.Contains("email") && responseMessageContent.Contains("password"))
            {
                var passwordErrorResponse = deserializer.GetPasswordError(stream);
                Output.PrintPasswordError(passwordErrorResponse);
                contentToWrite = ContentBuilder.BuildPasswordErrorString(passwordErrorResponse);
            }
            else if (responseMessageContent.Contains("email") && responseMessageContent.Contains("password"))
            {
                var credentialsErrorResponse = deserializer.GetCredentialsError(stream);
                Output.PrintCredentialsError(credentialsErrorResponse);
                contentToWrite = ContentBuilder.BuildCredentialsErrorString(credentialsErrorResponse);
            }
            tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);

            return new();
        }
    }
}