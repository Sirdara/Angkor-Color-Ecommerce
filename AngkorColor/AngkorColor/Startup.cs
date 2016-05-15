using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngkorColor.Startup))]
namespace AngkorColor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
