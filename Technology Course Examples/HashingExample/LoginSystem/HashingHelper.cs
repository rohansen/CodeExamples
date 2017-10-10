using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
    public class HashingHelper
    {

        private static int amountOfIterations = 10000;
        private static int saltSize = 16; //16 Bytes = 128 bits
        private static int hashSize = 20; //20bytes = 160bits

        public static string GenerateSalt()
        {
            //Empty array, ready to be filled with random salt bytes
            byte[] salt = new byte[saltSize];
            //RNGCryptoProvider is used to generate cryptographically strong random numbers
            var cryptoProvider = new RNGCryptoServiceProvider();
            //Use the cryptoprovider to fill the empty array with random bytes
            cryptoProvider.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
        public static string HashPassword(string password, string salt)
        {
      
            //Instantiate Rfc2898.. containing the password, the salt and the amount of times to iterate
            var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), amountOfIterations);
            //Use the instance of Rfc2898... to generate a 20 byte (160 bit) hash, and save it in a byte[] 
            byte[] hash = pbkdf2.GetBytes(hashSize);
            //Show information in Form1
            return Convert.ToBase64String(hash);
        }
        private static string ToHexString(byte[] input)
        {
            string tmp = "";
            foreach (var item in input)
            {
                tmp += item.ToString("x2");
            }
            return tmp;
        }
        public static bool CheckPassword(string password, string storedSalt, string currentSaltedHash)
        {
            //Salt already stored in "Database", retrieve salt.. hash and salt cleartext password. check with saltedHash from DB
            
            var hashedValue = HashPassword(password, storedSalt);
            return hashedValue == currentSaltedHash;
        }
    }
}
