using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class HashingHelper
    {
        private static int saltSize = 16;
        public static string HashPassword(string password, string salt)
        {
            //Choose hashing algorithm
            HashAlgorithm algo = SHA512.Create(HashAlgorithmName.SHA512.Name);
            //Convert input string (password) to bytes
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            //Salt the password
            byte[] saltedPassword = SaltPassword(passwordBytes, Encoding.Unicode.GetBytes(salt)); 
            //Hash the salted password
            byte[] hashedAndSaltedPassword = algo.ComputeHash(saltedPassword);
            
            return Convert.ToBase64String(hashedAndSaltedPassword);
        }

        private static byte[] SaltPassword(byte[] password, byte[] salt)
        {
            byte[] saltedPassword = new byte[password.Length+salt.Length];
            Array.Copy(password, saltedPassword, password.Length);
            Array.Copy(salt,0, saltedPassword, password.Length-1,salt.Length);
            return saltedPassword;
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[saltSize];
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public static bool CheckPassword(string password, string storedSalt, string currentSaltedHash)
        {

            var hashedValue = HashPassword(password, storedSalt);
            return hashedValue == currentSaltedHash;
        }
    }
}
