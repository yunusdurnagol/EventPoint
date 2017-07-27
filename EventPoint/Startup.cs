using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventPoint.Startup))]
namespace EventPoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
