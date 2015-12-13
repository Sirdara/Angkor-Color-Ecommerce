using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Angkor_Color_Ecommerce.Startup))]
namespace Angkor_Color_Ecommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
