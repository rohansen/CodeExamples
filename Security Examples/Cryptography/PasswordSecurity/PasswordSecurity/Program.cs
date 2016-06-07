using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSecurity
{
    class Program
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        public static int Main(string[] args)
        {
    
                
                Console.WriteLine("Login please - Enter username");
                var email = Console.ReadLine();
                Console.WriteLine("Enter Password");
                var pw = Console.ReadLine();
                var user = db.Users.Where(x => x.Email == email).FirstOrDefault();
                var xxx = db.Users.Count();
                Console.WriteLine("Total users in system: {0}",xxx);
                if (user!= null && user.PasswordHash == SecurityHelpers.GetSaltedHash(pw, user.PasswordSalt))
                {
                    Console.WriteLine("Correct!");
                    return 1;
                }
                else
                {
                    Console.WriteLine("Incorrect email or password!");
                    return -1;
                }

           
            
        }
    }
}
