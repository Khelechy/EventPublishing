using System.Diagnostics;

namespace EventMessenger.Helpers
{
    public static class EmailHelper
    {
        public static void SendWelcomeEmail(string email)
        {
            Debug.WriteLine("Welcome email sent to: " + email);
        }
    }
}
