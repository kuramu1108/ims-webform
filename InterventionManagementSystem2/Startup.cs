using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterventionManagementSystem2.Startup))]
namespace InterventionManagementSystem2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
