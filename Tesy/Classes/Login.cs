using Tesy.Clients;

namespace Tesy.Classes
{
    public class Login
    {
        private string userEmail = "";
        private string userPassword = "";
        private Http httpClient = new();

        public Login(string userEmail, string userPassword)
        {
            this.userEmail = userEmail;
            this.userPassword = userPassword;
        }

        public Http SignIn()
        {
            httpClient = new(userEmail, userPassword);
            return httpClient;
        }
    }
}