
namespace OnlinerSpecFlow.Models
{
    class User
    {
        public static string UserName { get; private set; }

        public static string Password { get; private set; }

        public static void SetCredentials(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}