using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleNoteKeeper.Startup))]
namespace SimpleNoteKeeper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
