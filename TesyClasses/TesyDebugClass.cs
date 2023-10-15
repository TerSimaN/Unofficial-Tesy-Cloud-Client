public class TesyDebugClass
{
    private readonly string credentialsJsonFilePath = TesyConstants.PathToCredentialsJsonFile;
    private readonly string httpResponseMessagesFilePath = TesyConstants.PathToHttpResponseMessagesFile;
    private string debugUserEmail = "";
    private string debugUserPassword = "";
    private string contentToWrite = "";
    private TesyHttpClient debugTesyHttpClient = new();
    // private Dictionary<string, string> debugInputQueryParams = new();
    private readonly StreamDeserializer debugDeserializer = new();
    private readonly TesyFileEditorClass debugTesyFileEditor = new();

    private CredentialsContent? debugCredentialsContentResponse;
    private LoginContent? debugLoginContentResponse;

    // private NoMatchFoundInRecordsError? debugNoMatchFoundInRecordsErrorResponse;
    private Dictionary<string, CredentialsError>? debugCredentialsErrorResponse;
    private Dictionary<string, EmailError>? debugEmailErrorResponse;
    private Dictionary<string, PasswordError>? debugPasswordErrorResponse;
    private Dictionary<string, GlobalError>? debugGlobalErrorResponse;

    private void DebugReadUserCredentialsFromFile()
    {
        string readContent = debugTesyFileEditor.ReadFromFile(credentialsJsonFilePath);

        debugCredentialsContentResponse = debugDeserializer.GetUserCredentialsContent(readContent);
        debugUserEmail = debugCredentialsContentResponse.Email;
        debugUserPassword = debugCredentialsContentResponse.Password;
    }

    public void DebugLogin()
    {
        if (File.Exists(credentialsJsonFilePath))
        {
            DebugReadUserCredentialsFromFile();
        }

        debugTesyHttpClient = new(debugUserEmail, debugUserPassword);
        DebugPostTesyLoginData();
    }

    public async void DebugPostTesyLoginData()
    {
        HttpResponseMessage responseMessage = debugTesyHttpClient.Post(
            TesyConstants.LoginUrl,
            new Dictionary<string, string>(
                new[] {
                    KeyValuePair.Create("email", debugUserEmail),
                    KeyValuePair.Create("password", debugUserPassword)
                }
            )
        );

        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("userID"))
        {
            debugLoginContentResponse = debugDeserializer.GetTesyLoginContent(stream);
            contentToWrite = ContentBuilder.BuildLoginContentString(debugLoginContentResponse);
        }
        else if (responseMessageContent.Contains("global"))
        {
            debugGlobalErrorResponse = debugDeserializer.GetGlobalError(stream);
            contentToWrite = ContentBuilder.BuildGlobalErrorString(debugGlobalErrorResponse);
        }
        else if (responseMessageContent.Contains("email") && !responseMessageContent.Contains("password"))
        {
            debugEmailErrorResponse = debugDeserializer.GetEmailError(stream);
            contentToWrite = ContentBuilder.BuildEmailErrorString(debugEmailErrorResponse);
        }
        else if (!responseMessageContent.Contains("email") && responseMessageContent.Contains("password"))
        {
            debugPasswordErrorResponse = debugDeserializer.GetPasswordError(stream);
            contentToWrite = ContentBuilder.BuildPasswordErrorString(debugPasswordErrorResponse);
        }
        else if (responseMessageContent.Contains("email") && responseMessageContent.Contains("password"))
        {
            debugCredentialsErrorResponse = debugDeserializer.GetCredentialsError(stream);
            contentToWrite = ContentBuilder.BuildCredentialsErrorString(debugCredentialsErrorResponse);
        }
        debugTesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }
}