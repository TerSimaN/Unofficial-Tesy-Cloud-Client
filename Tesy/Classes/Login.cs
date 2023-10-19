using Tesy.Clients;

namespace Tesy.Classes
{
    public static class Login
    {
        public static Http SignIn(string userEmail, string userPassword)
        {
            Http httpClient = new(userEmail, userPassword);
            return httpClient;
        }
    }
}