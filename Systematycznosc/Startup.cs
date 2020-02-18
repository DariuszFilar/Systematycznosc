using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Systematycznosc.Startup))]
namespace Systematycznosc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
