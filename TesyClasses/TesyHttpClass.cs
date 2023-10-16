public class TesyHttpClass
{
    private readonly string credentialsJsonFilePath = TesyConstants.PathToCredentialsJsonFile;
    private readonly string httpResponseMessagesFilePath = TesyConstants.PathToHttpResponseMessagesFile;
    private string userEmail = "";
    private string userPassword = "";
    private string contentToWrite = "";
    private bool hasLoginError = false;
    private TesyHttpClient tesyHttpClient = new();
    private Dictionary<string, string> inputQueryParams = new();
    private Dictionary<string, string> updateDeviceSettingsQueryParams = new();
    private Dictionary<string, DeviceProgram> deviceProgramsDictionary = new();
    private readonly StreamDeserializer deserializer = new();
    private readonly TesyFileEditor tesyFileEditor = new();

    private LoginContent? loginContentResponse;
    private UpdateDeviceSettingsContent? updateDeviceSettingsContentResponse;
    private UpdateUserAccountSettingsContent? updateUserAccountSettingsContentResponse;
    private UpdateUserPasswordSettingsContent? updateUserPasswordSettingsContentResponse;
    private UserInfoContent? userInfoContentResponse;
    private Dictionary<string, MyDevicesContent>? myDevicesContentResponse;
    private DeviceTime? deviceTimeContentResponse;
    private DeviceTempStatContent? deviceTempStatContentResponse;
    private DevicePowerStatContent[]? devicePowerStatContentResponse;
    private Dictionary<string, Documents>? documentsResponse;

    private NoMatchFoundInRecordsError? noMatchFoundInRecordsErrorResponse;
    private Dictionary<string, CredentialsError>? credentialsErrorResponse;
    private Dictionary<string, EmailError>? emailErrorResponse;
    private Dictionary<string, PasswordError>? passwordErrorResponse;
    private Dictionary<string, GlobalError>? globalErrorResponse;
    private Dictionary<string, AccountDetailsError>? accountDetailsErrorResponse;
    private Dictionary<string, NameError>? nameErrorResponse;
    private Dictionary<string, LastNameError>? lastNameErrorResponse;
    private Dictionary<string, PasswordDetailsError>? passwordDetailsErrorResponse;
    private Dictionary<string, ConfirmPasswordError>? confirmPasswordErrorResponse;

    public void Login()
    {
        if (File.Exists(credentialsJsonFilePath))
        {
            var credentials = tesyFileEditor.ReadUserCredentialsFromFile(credentialsJsonFilePath);
            userEmail = credentials.Email;
            userPassword = credentials.Password;
        }
        else
        {
            userEmail = Input.ReadEmailFromConsole();
            userPassword = Input.ReadPasswordFromConsole();

            tesyFileEditor.WriteUserCredentialsToFile(userEmail, userPassword, credentialsJsonFilePath);
        }

        tesyHttpClient = new(userEmail, userPassword);
        PostTesyLoginData();
        GetTesyMyDevices();
    }

    public async void PostTesyLoginData()
    {
        HttpResponseMessage responseMessage = tesyHttpClient.Post(
            TesyConstants.LoginUrl,
            new Dictionary<string, string>(
                new[] {
                    KeyValuePair.Create("email", userEmail),
                    KeyValuePair.Create("password", userPassword)
                }
            )
        );

        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("userID"))
        {
            loginContentResponse = deserializer.GetTesyLoginContent(stream);
            inputQueryParams.TryAdd("userID", loginContentResponse.UserID.ToString());
            updateDeviceSettingsQueryParams.TryAdd("userID", loginContentResponse.UserID.ToString());
            // Output.PrintLoginContent(loginContentResponse);
            contentToWrite = ContentBuilder.BuildLoginContentString(loginContentResponse);
        }
        else if (responseMessageContent.Contains("global"))
        {
            HasLoginError = true;
            globalErrorResponse = deserializer.GetGlobalError(stream);
            Output.PrintGlobalError(globalErrorResponse);
            contentToWrite = ContentBuilder.BuildGlobalErrorString(globalErrorResponse);
        }
        else if (responseMessageContent.Contains("email") && !responseMessageContent.Contains("password"))
        {
            HasLoginError = true;
            emailErrorResponse = deserializer.GetEmailError(stream);
            Output.PrintEmailError(emailErrorResponse);
            contentToWrite = ContentBuilder.BuildEmailErrorString(emailErrorResponse);
        }
        else if (!responseMessageContent.Contains("email") && responseMessageContent.Contains("password"))
        {
            HasLoginError = true;
            passwordErrorResponse = deserializer.GetPasswordError(stream);
            Output.PrintPasswordError(passwordErrorResponse);
            contentToWrite = ContentBuilder.BuildPasswordErrorString(passwordErrorResponse);
        }
        else if (responseMessageContent.Contains("email") && responseMessageContent.Contains("password"))
        {
            HasLoginError = true;
            credentialsErrorResponse = deserializer.GetCredentialsError(stream);
            Output.PrintCredentialsError(credentialsErrorResponse);
            contentToWrite = ContentBuilder.BuildCredentialsErrorString(credentialsErrorResponse);
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void PostTesyUpdateDeviceSettings(Dictionary<string, string> queryParams)
    {
        foreach (var queryParam in queryParams)
        {
            if (updateDeviceSettingsQueryParams.ContainsKey(queryParam.Key))
            {
                updateDeviceSettingsQueryParams[queryParam.Key] = queryParam.Value;
            }
            else
            {
                updateDeviceSettingsQueryParams.TryAdd(queryParam.Key, queryParam.Value);
            }
        }

        HttpResponseMessage responseMessage = tesyHttpClient.Post(
            TesyConstants.UpdateDeviceSettingsUrl,
            updateDeviceSettingsQueryParams
        );

        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            updateDeviceSettingsContentResponse = deserializer.GetUpdateDeviceSettingsContent(stream);
            contentToWrite = ContentBuilder.BuildUpdateDeviceSettingsContentString(updateDeviceSettingsContentResponse);
            // Output.PrintUpdateDeviceSettingsContent(updateDeviceSettingsResponse);
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void PostUpdateUserAccountSettings(TesyUserClass tesyUserClass)
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
            tesyFileEditor.WriteUserCredentialsToFile(tesyUserClass.Email, tesyUserClass.NewPassword, credentialsJsonFilePath);
            updateUserAccountSettingsContentResponse = deserializer.GetUpdateUserAccountSettingsContent(stream);
            // Output.PrintUpdateUserAccountSettingsContent(updateUserAccountSettingsContentResponse);
            contentToWrite = ContentBuilder.BuildUpdateUserAccountSettingsContentString(updateUserAccountSettingsContentResponse);
        }
        else if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
        }
        else if (responseMessageContent.Contains("email") && !responseMessageContent.Contains("name") && !responseMessageContent.Contains("lastName"))
        {
            emailErrorResponse = deserializer.GetEmailError(stream);
            // Output.PrintEmailError(emailErrorResponse);
            contentToWrite = ContentBuilder.BuildEmailErrorString(emailErrorResponse);
        }
        else if (!responseMessageContent.Contains("email") && responseMessageContent.Contains("name") && !responseMessageContent.Contains("lastName"))
        {
            nameErrorResponse = deserializer.GetNameError(stream);
            // Output.PrintNameError(nameErrorResponse);
            contentToWrite = ContentBuilder.BuildNameErrorString(nameErrorResponse);
        }
        else if (!responseMessageContent.Contains("email") && !responseMessageContent.Contains("name") && responseMessageContent.Contains("lastName"))
        {
            lastNameErrorResponse = deserializer.GetLastNameError(stream);
            // Output.PrintLastNameError(lastNameErrorResponse);
            contentToWrite = ContentBuilder.BuildLastNameErrorString(lastNameErrorResponse);
        }
        else if (responseMessageContent.Contains("email") && responseMessageContent.Contains("name") && responseMessageContent.Contains("lastName"))
        {
            accountDetailsErrorResponse = deserializer.GetAccountDetailsError(stream);
            // Output.PrintAccountDetailsError(accountDetailsErrorResponse);
            contentToWrite = ContentBuilder.BuildAccountDetailsErrorString(accountDetailsErrorResponse);
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void PostUpdateUserPasswordSettings(TesyUserClass tesyUserClass)
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
            tesyFileEditor.WriteUserCredentialsToFile(tesyUserClass.Email, tesyUserClass.NewPassword, credentialsJsonFilePath);
            updateUserPasswordSettingsContentResponse = deserializer.GetUpdateUserPasswordSettingsContent(stream);
            // Output.PrintUpdateUserPasswordSettingsContent(updateUserPasswordSettingsContentResponse);
            contentToWrite = ContentBuilder.BuildUpdateUserPasswordSettingsContentString(updateUserPasswordSettingsContentResponse);
        }
        else if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
        }
        else if (!responseMessageContent.Contains("newPassword") && responseMessageContent.Contains("confirmPassword"))
        {
            confirmPasswordErrorResponse = deserializer.GetConfirmPasswordError(stream);
            // Output.PrintConfirmPasswordError(confirmPasswordErrorResponse);
            contentToWrite = ContentBuilder.BuildConfirmPasswordErrorString(confirmPasswordErrorResponse);
        }
        else if (responseMessageContent.Contains("newPassword") && responseMessageContent.Contains("confirmPassword"))
        {
            passwordDetailsErrorResponse = deserializer.GetPasswordDetailsError(stream);
            // Output.PrintPasswordDetailsError(passwordDetailsErrorResponse);
            contentToWrite = ContentBuilder.BuildPasswordDetailsErrorString(passwordDetailsErrorResponse);
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void GetTesyUserHasAccessToCloud()
    {
        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.UserHasAccessToCloud, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            contentToWrite = $"UserHasAccessToCloud: {responseMessageContent}\n\n";
            // Console.WriteLine($"UserHasAccessToCloud: {responseMessageContent}");
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void GetTesyUserInfo()
    {
        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.UserInfoUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            userInfoContentResponse = deserializer.GetUserInfoContent(stream);
            contentToWrite = ContentBuilder.BuildUserInfoContentString(userInfoContentResponse);
            // Output.PrintUserInfoContent(userInfoContentResponse);
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void GetTesyMyDevices()
    {
        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.MyDevicesUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            myDevicesContentResponse = deserializer.GetMyDevicesContent(stream);
            foreach (var deviceParam in myDevicesContentResponse)
            {
                deviceProgramsDictionary = deviceParam.Value.State.DeviceProgram;
                deviceTimeContentResponse = deserializer.GetDeviceTimeContent(deviceParam.Value.Time);
                // Output.PrintMyDevicesContent(myDevicesContentResponse, deviceTimeContentResponse);
                contentToWrite = ContentBuilder.BuildMyDevicesContentString(myDevicesContentResponse, deviceTimeContentResponse);
            }
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void GetTesyMyGroups()
    {
        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.MyGroupsUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            contentToWrite = $"MyGroupsResponse: {responseMessageContent}\n\n";
            // Console.WriteLine($"MyGroupsResponse: {responseMessageContent}");
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void GetTesyMyMessages()
    {
        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.MyMessagesUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            contentToWrite = $"MyMessagesResponse: {responseMessageContent}\n\n";
            // Console.WriteLine($"MyMessagesResponse: {responseMessageContent}");
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void GetTesyTestDevices()
    {
        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.TestDevicesUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();
        
        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            contentToWrite = $"TestDevicesResponse: {responseMessageContent}\n\n";
            // Console.WriteLine($"TestDevicesResponse: {responseMessageContent}");
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void GetTesyDeviceTempStat()
    {
        string activity = Input.ReadActivityFromConsole();

        foreach (var deviceParam in MyDevicesContentResponse)
        {
            inputQueryParams.TryAdd("model", $"{deviceParam.Value.Model_Id}");
            inputQueryParams.TryAdd("timezone", deviceParam.Value.Timezone);
            inputQueryParams.TryAdd("mac", deviceParam.Value.State.Mac);
        }

        if (!inputQueryParams.ContainsKey("activity"))
        {
            inputQueryParams.TryAdd("activity", activity);
        }
        else
        {
            inputQueryParams["activity"] = activity;
        }

        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.DeviceTempStatUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            deviceTempStatContentResponse = deserializer.GetDeviceTempStatContent(stream);
            contentToWrite = ContentBuilder.BuildDeviceTempStatContentString(deviceTempStatContentResponse);
            // Output.PrintDeviceTempStatContent(deviceTempStatContentResponse);
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public async void GetTesyDevicePowerStat()
    {
        string activity = Input.ReadActivityFromConsole();

        foreach (var deviceParam in MyDevicesContentResponse)
        {
            inputQueryParams.TryAdd("model", $"{deviceParam.Value.Model_Id}");
            inputQueryParams.TryAdd("timezone", deviceParam.Value.Timezone);
            inputQueryParams.TryAdd("mac", deviceParam.Value.State.Mac);
        }

        if (!inputQueryParams.ContainsKey("activity"))
        {
            inputQueryParams.TryAdd("activity", activity);
        }
        else
        {
            inputQueryParams["activity"] = activity;
        }

        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.DevicePowerStatUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();
        string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessageContent.Contains("error"))
        {
            noMatchFoundInRecordsErrorResponse = deserializer.GetNoMatchFoundInRecordsError(stream);
            contentToWrite = ContentBuilder.BuildNoMatchFoundInRecordsErrorString(noMatchFoundInRecordsErrorResponse);
            // Output.PrintNoMatchFoundInRecordsError(noMatchFoundInRecordsErrorResponse);
        }
        else
        {
            devicePowerStatContentResponse = deserializer.GetDevicePowerStatContent(stream);
            contentToWrite = ContentBuilder.BuildDevicePowerStatContentString(devicePowerStatContentResponse);
            // Output.PrintDevicePowerStatContent(devicePowerStatContentResponse);
        }
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
    }

    public void GetTesyDocuments()
    {
        HttpResponseMessage responseMessage = tesyHttpClient.Get(TesyConstants.DocumentsUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();

        documentsResponse = deserializer.GetTesyDocumentsContent(stream);
        contentToWrite = ContentBuilder.BuildTesyDocumentsContentString(documentsResponse);
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
        // Output.PrintTesyDocuments(documentsResponse);
    }

    public bool HasLoginError
    {
        get { return hasLoginError; }
        private set { hasLoginError = value; }
    }

    public Dictionary<string, MyDevicesContent> MyDevicesContentResponse
    {
        get { return myDevicesContentResponse ?? new(); }
    }

    public DeviceTime DeviceTimeContentResponse
    {
        get { return deviceTimeContentResponse ?? new("Date not found!", "Time not found!"); }
    }

    public Dictionary<string, DeviceProgram> DeviceProgramsDictionary
    {
        get { return deviceProgramsDictionary; }
    }

    public UserInfoContent UserInfoContent
    {
        get { return userInfoContentResponse ?? new("Email not found!", "FirstName not found!", "LastName not found!", "Language not found!"); }
    }
}