using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;

namespace Tesy.Commands
{
    public class LoginData
    {
        private string contentToWrite = "";
        private string userEmail = "";
        private string userPasswword = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public LoginData(Http httpClient, string userEmail, string userPasswword)
        {
            this.httpClient = httpClient;
            this.userEmail = userEmail;
            this.userPasswword = userPasswword;
        }

        public async Task<Dictionary<string, string>> PostLoginData()
        {
            HttpResponseMessage responseMessage = httpClient.Post(
                Constants.LoginUrl,
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
                var loginContentResponse = JsonSerializer.Deserialize<LoginContent>(stream) ?? new(
                    -1, "Password not found", "Email not found", "FirstName not found", 
                    "LastName not found", "Lang not found", "DebugMenu not found", "Token not found"
                );
                inputQueryParams.TryAdd("userID", loginContentResponse.UserID.ToString());
                contentToWrite = ContentBuilder.BuildLoginContentString(loginContentResponse);
                fileEditor.WriteContentToHttpResponseMessagesFile(contentToWrite);

                return inputQueryParams;
            }
            else if (responseMessageContent.Contains("global"))
            {
                var globalErrorResponse = JsonSerializer.Deserialize<Dictionary<string, GlobalError>>(stream) ?? new();
                Output.PrintGlobalError(globalErrorResponse);
                contentToWrite = ContentBuilder.BuildGlobalErrorString(globalErrorResponse);
            }
            else if (responseMessageContent.Contains("email") && !responseMessageContent.Contains("password"))
            {
                var emailErrorResponse = JsonSerializer.Deserialize<Dictionary<string, EmailError>>(stream) ?? new();
                Output.PrintEmailError(emailErrorResponse);
                contentToWrite = ContentBuilder.BuildEmailErrorString(emailErrorResponse);
            }
            else if (!responseMessageContent.Contains("email") && responseMessageContent.Contains("password"))
            {
                var passwordErrorResponse = JsonSerializer.Deserialize<Dictionary<string, PasswordError>>(stream) ?? new();
                Output.PrintPasswordError(passwordErrorResponse);
                contentToWrite = ContentBuilder.BuildPasswordErrorString(passwordErrorResponse);
            }
            else if (responseMessageContent.Contains("email") && responseMessageContent.Contains("password"))
            {
                var credentialsErrorResponse = JsonSerializer.Deserialize<Dictionary<string, CredentialsError>>(stream) ?? new();
                Output.PrintCredentialsError(credentialsErrorResponse);
                contentToWrite = ContentBuilder.BuildCredentialsErrorString(credentialsErrorResponse);
            }
            fileEditor.WriteContentToHttpResponseMessagesFile(contentToWrite);

            return new();
        }
    }
}