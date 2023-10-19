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
        private Dictionary<string, string> inputQueryParams = new();

        public UserInfo(Http httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserInfoContent> GetUserInfo()
        {
            HttpResponseMessage responseMessage = httpClient.Get(TesyConstants.UserInfoUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = JsonSerializer.Deserialize<NoMatchFoundInRecordsError>(stream) ?? new("Error not found");
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
                fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
            }
            else
            {
                var userInfoContentResponse = JsonSerializer.Deserialize<UserInfoContent>(stream) ?? new("Email not found", "FirstName not found", "LastName not found", "Lang not found");
                contentToWrite = ContentBuilder.BuildUserInfoContentString(userInfoContentResponse);
                fileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);

                return userInfoContentResponse;
            }

            return new("Email not found!", "FirstName not found!", "LastName not found!", "Language not found!");
        }
    }
}