using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppGeneric.Startup))]
namespace WebAppGeneric
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
