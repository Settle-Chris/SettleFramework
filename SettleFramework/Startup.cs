using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SettleFramework.Startup))]
namespace SettleFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
