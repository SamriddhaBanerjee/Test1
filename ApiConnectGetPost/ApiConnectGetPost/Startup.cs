using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApiConnectGetPost.Startup))]
namespace ApiConnectGetPost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
