using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoDBExample.Startup))]
namespace MongoDBExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
