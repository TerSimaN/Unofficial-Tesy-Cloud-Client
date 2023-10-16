namespace Tesy.Commands
{
    public class UserInfo
    {
        private string contentToWrite = "";
        private readonly TesyHttpClient tesyHttpClient;
        private readonly StreamDeserializer deserializer = new();
        private readonly TesyFileEditor tesyFileEditor = new();
        private Dictionary<string, string> inputQueryParams = new();

        public UserInfo(TesyHttpClient tesyHttpClient)
        {
            this.tesyHttpClient = tesyHttpClient;
        }

        public async Task<UserInfoContent> GetUserInfo()
        {
            HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.UserInfoUrl, inputQueryParams);
            Stream stream = responseMessage.Content.ReadAsStream();
            string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessageContent.Contains("error"))
            {
                var noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
                contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
                tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);
            }
            else
            {
                var userInfoContentResponse = deserializer.GetUserInfoContent(stream);
                contentToWrite = ContentBuilder.BuildUserInfoContentString(userInfoContentResponse);
                tesyFileEditor.WriteToFile(TesyConstants.PathToHttpResponseMessagesFile, contentToWrite);

                return userInfoContentResponse;
            }

            return new("Email not found!", "FirstName not found!", "LastName not found!", "Language not found!");
        }
    }
}