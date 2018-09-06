using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OauthExample
{
    public class AuthorizationHelper
    {
        private static readonly HttpClient client = new HttpClient();
        public Uri LoginDialogUri { get; private set; }
        private const string clientToken = "2143c81845944b6ec16c7a70d019f49a";
        public AuthorizationHelper(string appid, string redirecturl, string state, string[] parameters)
        {
            LoginDialogUri = new Uri($@"https://www.facebook.com/v3.1/dialog/oauth?client_id={235731147074166}&redirect_uri={{{"\""+redirecturl+"\""}}}&state={{{state}}}");
        }
        public void GetLoginDialog()
        {
            client.GetStreamAsync(LoginDialogUri);
        }

       

    }
}
