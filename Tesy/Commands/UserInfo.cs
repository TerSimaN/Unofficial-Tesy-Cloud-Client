using System.Text.Json;
using Tesy.Classes;
using Tesy.Clients;
using Tesy.Content;

namespace Tesy.Commands
{
    public class UserInfo
    {
        private string contentToWrite = "";
        private readonly Http httpClient;
        private readonly FileEditor fileEditor = new();
        private readonly Dictionary<string, string> inputQueryParams;

        public UserInfo(Http httpClient, Dictionary<string, string> inputQueryParams)
        {
            this.httpClient = httpClient;
            this.inputQueryParams = inputQueryParams;
        }

        public async Task<UserInfoContent> GetUserInfo()
        {
            HttpResponseMessage responseMessage = httpClient.Get(Constants.UserInfoUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
                fileEditor.WriteToFile(Constants.PathToHttpResponseMessagesFile, contentToWrite);
            }
            else
            {
                var userInfoContentResponse = JsonSerializer.Deserialize<UserInfoContent>(stream) ?? new("Email not found", "FirstName not found", "LastName not found", "Lang not found");
                contentToWrite = ContentBuilder.BuildUserInfoContentString(userInfoContentResponse);
                fileEditor.WriteToFile(Constants.PathToHttpResponseMessagesFile, contentToWrite);

                return userInfoContentResponse;
            }

            return new("Email not found!", "FirstName not found!", "LastName not found!", "Language not found!");
        }
    }
}