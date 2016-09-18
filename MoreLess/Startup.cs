using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoreLess.Startup))]
namespace MoreLess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
