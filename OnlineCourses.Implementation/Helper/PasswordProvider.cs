using OnlineCourses.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace OnlineCourses.Implementation.Helper
{
    public class PasswordProvider : IPasswordProvider
    {
        private const int SaltSize = 0x10;
        private const int PBKDF2IterCount = 0x3e8;
        private const int PBKDF2SubkeyLength = 0x20;

        public string Hash(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            byte[] salt;
            byte[] subkey;

            using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }

            byte[] outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        public bool VerifyHashedPassword(string password, string hashedPassword)
        {
            if (hashedPassword == null)
                throw new ArgumentNullException("hashedPassword");

            if (password == null)
                throw new ArgumentNullException("password");


            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);


            if (hashedPasswordBytes.Length != (1 + SaltSize + PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
            {
                // Wrong length or version header.
                return false;
            }

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
            byte[] storedSubkey = new byte[PBKDF2SubkeyLength];
            Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, PBKDF2SubkeyLength);

            byte[] generatedSubkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, PBKDF2IterCount))
            {
                generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }
            return storedSubkey.SequenceEqual(generatedSubkey);
        }
    }
}
