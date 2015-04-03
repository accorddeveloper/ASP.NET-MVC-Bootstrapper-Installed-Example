using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PureMVC.Startup))]
namespace PureMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
