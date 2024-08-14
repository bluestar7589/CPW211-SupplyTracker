using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SupplyTracker.Util
{
    public class PasswordHasher
    {
        /// <summary>
        /// Encrypts users password and stores the User's salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// Generates a User's salt
        /// </summary>
        /// <returns>Returns the generated salt string</returns>
        public static string GenerateSalt()
        {
            int size = 32;
            // Create a byte array to hold the salt
            byte[] saltBytes = new byte[size];

            // Fill the array with secure random bytes
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            // Convert the byte array to a Base64 string for storage
            return Convert.ToBase64String(saltBytes);
        }
    }
}
