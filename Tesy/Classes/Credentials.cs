namespace Tesy.Classes
{
    public class Credentials
    {
        private readonly string credentialsJsonFilePath = TesyConstants.PathToCredentialsJsonFile;
        private readonly FileEditor fileEditor = new();

        public Credentials() {}

        public string[] GetCredentials()
        {
            string userEmail = "";
            string userPassword = "";

            if (File.Exists(credentialsJsonFilePath))
            {
                var credentialsContent = fileEditor.ReadUserCredentialsFromFile(credentialsJsonFilePath);
                userEmail = credentialsContent.Email;
                userPassword = credentialsContent.Password;
            }
            else
            {
                do
                {
                    Console.Write("Please enter a valid email: ");
                    var inputValue = Console.ReadLine();

                    if (inputValue != null)
                    {
                        userEmail = inputValue.Trim();
                    }
                } while (userEmail.Length < 1);

                do
                {
                    Console.Write("Please enter a valid password: ");
                    var inputValue = Console.ReadLine();

                    if (inputValue != null)
                    {
                        userPassword = inputValue.Trim();
                    }
                } while (userPassword.Length < 1);

                fileEditor.WriteUserCredentialsToFile(userEmail, userPassword, credentialsJsonFilePath);
            }

            return new[] {userEmail, userPassword};
        }
    }
}