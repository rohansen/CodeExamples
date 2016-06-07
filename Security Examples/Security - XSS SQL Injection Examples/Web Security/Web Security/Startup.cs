using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Security.Startup))]
namespace Web_Security
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
