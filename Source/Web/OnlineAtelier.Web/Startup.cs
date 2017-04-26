using Microsoft.Owin;

[assembly: OwinStartup(typeof(OnlineAtelier.Web.Startup))]
namespace OnlineAtelier.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
