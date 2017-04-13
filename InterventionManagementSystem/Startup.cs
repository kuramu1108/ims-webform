using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterventionManagementSystem.Startup))]
namespace InterventionManagementSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
