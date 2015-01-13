using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigsFirstAdminWebForms.Startup))]
namespace GigsFirstAdminWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
