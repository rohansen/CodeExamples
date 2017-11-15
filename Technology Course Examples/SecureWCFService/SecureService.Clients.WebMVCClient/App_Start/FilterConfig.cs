using System.Web;
using System.Web.Mvc;

namespace SecureService.Clients.WebMVCClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
