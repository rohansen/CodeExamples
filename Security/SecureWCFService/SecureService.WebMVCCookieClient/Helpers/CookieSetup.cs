using SecureService.Clients.WebMVCClientWithCookie.Controllers;
using SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces;
using SecureService.Clients.WebMVCClientWithCookie.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers
{
    public class CookieSetup : ICookieSetup
    {
        public void ClearAuthenticationCookie()
        {
            FormsAuthentication.SignOut();
        }

        public HttpCookie CreateEncryptedAuthenticationCookie(string username, string password)
        {
            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
            serializeModel.Id = 1;
            serializeModel.FirstName = username;
            serializeModel.LastName = password;

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serializeModel);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,
                        username,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(15),
                        false,
                        userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            return faCookie;
        }

        public CustomPrincipal RetrieveUserFromCookie(HttpCookie authCookie)
        {

            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

            CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
            newUser.Id = serializeModel.Id;
            newUser.FirstName = serializeModel.FirstName;
            newUser.LastName = serializeModel.LastName;
            return newUser;
        }

      
    }
}