using SecureService.Clients.ConsoleClient.SecureAuthServiceReference;
using SecureService.Clients.ConsoleClient.SecureUserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.Clients.ConsoleClient
{
    class Program
    {
        public static bool IsUserLoggedIn { get; set; } = false;
        private static AuthServiceClient authClient;
        private static SecureUserServiceClient secureClient;

        private static void Configure()
        {
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;

        }
        
        static void Main(string[] args)
        {
            Configure();
            //authClient = new AuthServiceClient("NetTcpBinding_IAuthService");
            authClient = new AuthServiceClient("WSHttpBinding_IAuthService");
            //secureClient = new SecureServiceClient("NetTcpBinding_ISecureUserService");
            secureClient = new SecureUserServiceClient("WSHttpBinding_ISecureUserService");



            Tuple<string, string> usernamepw = PromptUserNamePassword();
            Login(usernamepw.Item1, usernamepw.Item2);

            if (IsUserLoggedIn)
            {
                GetDataWithValidCredentials(usernamepw.Item1, usernamepw.Item2);
            }
            else
            {
                Console.WriteLine("User credentials not valid");
            }

            Console.ReadLine();
        }
        private static Tuple<string, string> PromptUserNamePassword()
        {
            Console.WriteLine("Please enter username and password");
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            return new Tuple<string, string>(username, password);
        }
        private static void Login(string username, string password)
        {
            IsUserLoggedIn = authClient.Login(username, password);
        }
        private static void GetDataWithValidCredentials(string username, string pw)
        {
            secureClient.ClientCredentials.UserName.UserName = username;
            secureClient.ClientCredentials.UserName.Password = pw;

            try
            {
                var data = secureClient.GetData(1337);
                Console.WriteLine("Here is some very secret information");
                Console.WriteLine(data);
            }
            catch (SecurityAccessDeniedException accessDenied)
            {
                Console.WriteLine("You do not have access to this method");
                Console.WriteLine(accessDenied.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
