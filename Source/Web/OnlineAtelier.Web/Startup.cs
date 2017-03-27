using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineAtelier.Web.Startup))]
namespace OnlineAtelier.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
