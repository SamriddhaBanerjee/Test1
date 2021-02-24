using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfoTrial.Startup))]
namespace InfoTrial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
