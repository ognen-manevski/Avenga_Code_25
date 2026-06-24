using System.Security.Cryptography; 
using System.Text;

namespace TimeTrackingApp.Helpers;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = SHA256.HashData(passwordBytes);

        return Convert.ToHexString(hashBytes);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        return HashPassword(password) == storedHash;
    }
}
