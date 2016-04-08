using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospital_asp.Startup))]
namespace Hospital_asp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
