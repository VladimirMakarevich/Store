using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Store.Web.Startup))]

namespace Store.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
