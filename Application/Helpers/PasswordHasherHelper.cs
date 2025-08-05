using System;
using System.Security.Cryptography;
using System.Text;

namespace Application.Helpers
{
    public static class PasswordHasherHelper
    {
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedPassword = password + salt;
                var bytes = Encoding.UTF8.GetBytes(combinedPassword);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string password, string salt, string hashedPassword)
        {
            var hashOfInput = HashPassword(password, salt);
            return hashOfInput == hashedPassword;
        }

        public static string GenerateSalt(int size = 16)
        {
            var randomBytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }
    }
}
