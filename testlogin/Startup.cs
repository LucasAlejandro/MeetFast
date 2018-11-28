using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testlogin.Startup))]
namespace testlogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
