using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetAdopt.Web.Startup))]
namespace PetAdopt.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
