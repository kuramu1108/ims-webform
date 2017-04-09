using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterventionManageSystem2.Startup))]
namespace InterventionManageSystem2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
