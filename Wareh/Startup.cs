using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wareh.Startup))]
namespace Wareh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
