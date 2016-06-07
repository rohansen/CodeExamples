using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSecurity
{
    public class SecurityHelpers
    {

        public static User CreateUser(string email, string password)
        {
            User user = new User();
            user.Email = email;
            var salt = CreateSalt(password);
            user.PasswordSalt = salt;
            user.PasswordHash = GetSaltedHash(password, salt);
            return user;
        }
        //What if we dont salt the password? What is the implication?
        private static string CreateSalt(string password)
        {
            
            byte[] buffer = new byte[1024];
            
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        //I am saving the salt, since it is the only way i know how that pw was hashed. and 
        //i need to rehash+salt the password to compare login info.
        public static string GetSaltedHash(string password, string salt)
        {
            var toHash = password + salt;
            HashAlgorithm hash = new SHA1CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(toHash);
            byte[] hashBytes = hash.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        //public CheckPassword(string password, string salt)
        //{
        //    GetSaltedHash(password, salt);
        //}

    }
}
