using Tesy.Commands;

namespace Tesy.Classes
{
    public class User
    {
        private string userEmail = "";
        private string userFirstName = "";
        private string userLastName = "";
        private string userLang = "";
        private string userNewPassword = "";
        private string userConfirmPassword = "";
        private readonly UserInfo userInfo;
        private readonly Dictionary<string, string> languages = TesyConstants.Languages;

        public User(UserInfo userInfo)
        {
            this.userInfo = userInfo;
            GetUserInformation();
        }
        
        private async void GetUserInformation()
        {
            var userInformation = await userInfo.GetUserInfo();
            userEmail = userInformation.Email;
            userFirstName = userInformation.FirstName;
            userLastName = userInformation.LastName;
            userLang = userInformation.Language;
        }

        public void ChangeUserEmail()
        {
            Console.WriteLine($"Current Email: {userEmail}");
            do
            {
                Console.Write("Please enter a valid email: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    userEmail = inputValue.Trim();
                }
            } while (userEmail.Length < 1);
        }

        public void ChangeUserFirstName()
        {
            Console.WriteLine($"Current First name: {userFirstName}");
            do
            {
                Console.Write("Enter a value for first name: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    userFirstName = inputValue.Trim();
                }
            } while (userFirstName.Length < 1);
        }

        public void ChangeUserLastName()
        {
            Console.WriteLine($"Current Last name: {userLastName}");
            do
            {
                Console.Write("Enter a value for last name: ");
                var inputValue = Console.ReadLine();

                if (inputValue != null)
                {
                    userLastName = inputValue.Trim();
                }
            } while (userLastName.Length < 1);
        }

        public void ChangeUserLang()
        {
            foreach (var language in languages)
            {
                if (language.Value.Equals(userLang))
                {
                    Console.WriteLine($"Current Language: {language.Key}");
                }
            }

            do
            {
                Output.PrintAvailableLanguages(languages);
                Console.Write("Enter a value for language: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && languages.ContainsKey(inputValue.Trim()))
                {
                    userLang = languages[inputValue];
                }
            } while (userLang.Length < 1);
        }

        public void ChangeUserPassword()
        {
            do
            {
                do
                {
                    Console.Write("Enter a new password: ");
                    var inputValue = Console.ReadLine();

                    if (inputValue != null)
                    {
                        userNewPassword = inputValue.Trim();
                    }
                } while (userNewPassword.Length < 1);

                do
                {
                    Console.Write("Confirm password: ");
                    var inputValue = Console.ReadLine();

                    if (inputValue != null)
                    {
                        userConfirmPassword = inputValue.Trim();
                    }
                } while (userConfirmPassword.Length < 1);

            } while (!userNewPassword.Equals(userConfirmPassword));
        }

        public string Email
        {
            get { return userEmail; }
        }

        public string FirstName
        {
            get { return userFirstName; }
        }

        public string LastName
        {
            get { return userLastName; }
        }

        public string Lang
        {
            get { return userLang; }
        }

        public string NewPassword
        {
            get { return userNewPassword; }
        }

        public string ConfirmPassword
        {
            get { return userConfirmPassword; }
        }
    }
}