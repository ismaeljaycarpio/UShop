using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UShop.Startup))]
namespace UShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
