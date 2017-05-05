using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Store.Identity.Startup))]

namespace Store.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
