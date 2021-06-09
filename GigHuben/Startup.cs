using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigHuben.Startup))]
namespace GigHuben
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
