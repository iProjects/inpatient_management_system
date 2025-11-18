using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inpatient_management_system.ui.web.Startup))]
namespace inpatient_management_system.ui.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
