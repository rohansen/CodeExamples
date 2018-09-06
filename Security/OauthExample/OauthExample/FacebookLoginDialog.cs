using Facebook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OauthExample
{
    public partial class FacebookLoginDialog : Form
    {
        private FacebookClient cl;
        public FacebookOAuthResult OAuthResult { get; private set; }
        public FacebookLoginDialog()
        {
            InitializeComponent();
            webBrowser1.Navigated += WebBrowser1_Navigated;
            cl = new FacebookClient();

            
          //  object myLogonObject = new {client_id= "235731147074166", redirect_uri= "https://www.facebook.com/connect/login_success.html", state=111111};
          //  var myLogoutObj = cl.GetLogoutUrl(myLogonObject);
            
          //  var fbLoginUrl = cl.GetLoginUrl(myLogonObject); ;
          //  //webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
          ////  webBrowser1.Navigate(myURL);
        }
        public void Login()
        {
            string nonce = new Random().Next(int.MinValue, int.MaxValue).ToString();
            var loginUrl = "https://www.facebook.com/v3.1/dialog/oauth?client_id=235731147074166&redirect_uri=https://www.facebook.com/connect/login_success.html&state=" + nonce;
         
            webBrowser1.Navigate(loginUrl);
            ShowDialog();
        }
        public void Logout()
        {
            string nonce = new Random().Next(int.MinValue, int.MaxValue).ToString();
            var logoutUrl = "https://www.facebook.com/logout.php?client_id=235731147074166&redirect_uri=https://www.facebook.com/connect/login_success.html&state=" + nonce;
            
            webBrowser1.Navigate(logoutUrl);
            ShowDialog();
        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var url = e.Url;
            FacebookOAuthResult oauthResult;
            if (cl.TryParseOAuthCallbackUrl(e.Url, out oauthResult))
            {
                // The url is the result of OAuth 2.0 authentication
                OAuthResult  = oauthResult;
                DialogResult = OAuthResult.IsSuccess ? DialogResult.OK : DialogResult.No;
            }
            else
            {
                // The url is NOT the result of OAuth 2.0 authentication.
                OAuthResult = null;
            }
        }
    }
}
