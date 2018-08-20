using SecureService.Clients.WebMVCClientWithCookie.Models.Authorization;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces
{
    public interface ICookieSetup
    {
        HttpCookie CreateEncryptedAuthenticationCookie(string username, string password);
        void ClearAuthenticationCookie();
        CustomPrincipal RetrieveUserFromCookie(HttpCookie authCookie);
    }
}