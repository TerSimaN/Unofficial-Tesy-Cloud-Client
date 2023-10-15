public class TesyUserClass
{
    private string userEmail = "";
    private string userFirstName = "";
    private string userLastName = "";
    private string userLang = "";
    private string userNewPassword = "";
    private string userConfirmPassword = "";
    private readonly Dictionary<string, string> languages = TesyConstants.Languages;

    public TesyUserClass(TesyHttpClass tesyHttpClass)
    {
        tesyHttpClass.GetTesyUserInfo();
        Email = tesyHttpClass.UserInfoContent.Email;
        FirstName = tesyHttpClass.UserInfoContent.FirstName;
        LastName = tesyHttpClass.UserInfoContent.LastName;
        Lang = tesyHttpClass.UserInfoContent.Language;
    }

    public void ChangeUserEmail()
    {
        Console.WriteLine($"Current Email: {Email}");
        Email = Input.ReadEmailFromConsole();
    }

    public void ChangeUserFirstName()
    {
        Console.WriteLine($"Current First name: {FirstName}");
        FirstName = Input.ReadFirstNameFromConsole();
    }

    public void ChangeUserLastName()
    {
        Console.WriteLine($"Current Last name: {LastName}");
        LastName = Input.ReadLastNameFromConsole();
    }

    public void ChangeUserLang()
    {
        foreach (var language in languages)
        {
            if (language.Value.Equals(Lang))
            {
                Console.WriteLine($"Current Language: {language.Key}");
            }
        }
        Lang = Input.ReadLanguageFromConsole();
    }

    public void ChangeUserPassword()
    {
        string newPasswordValue;
        string confirmPasswordValue;
        do
        {
            newPasswordValue = Input.ReadNewPasswordFromConsole();
            confirmPasswordValue = Input.ReadConfirmNewPasswordFromConsole();
        } while (!newPasswordValue.Equals(confirmPasswordValue));

        NewPassword = newPasswordValue;
        ConfirmPassword = confirmPasswordValue;
    }

    public string Email
    {
        get { return userEmail; }
        private set { userEmail = value; }
    }

    public string FirstName
    {
        get { return userFirstName; }
        private set { userFirstName = value; }
    }

    public string LastName
    {
        get { return userLastName; }
        private set { userLastName = value; }
    }

    public string Lang
    {
        get { return userLang; }
        private set { userLang = value; }
    }

    public string NewPassword
    {
        get { return userNewPassword; }
        private set { userNewPassword = value; }
    }

    public string ConfirmPassword
    {
        get { return userConfirmPassword; }
        private set { userConfirmPassword = value; }
    }
}